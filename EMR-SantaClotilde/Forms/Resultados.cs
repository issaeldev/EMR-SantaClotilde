using EMR_SantaClotilde.Services;
using EMR_SantaClotilde.Models;
using EMR_SantaClotilde.Forms;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace EMR_SantaClotilde
{
    public partial class Resultados : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IResultadoService _resultadoService;
        private List<Resultado> _resultadosOriginales = new List<Resultado>();

        public Resultados(IResultadoService resultadoService, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _resultadoService = resultadoService;

            InitializeComponent();

            // Inicializar combos con valores predeterminados
            InicializarCombos();

            this.Load += Resultados_Load;
        }

        private void InicializarCombos()
        {
            // Combo Tipo de Examen
            cmbTipoExamen.Items.Clear();
            cmbTipoExamen.Items.AddRange(new[] {
                "Laboratorio",
                "Imagenología",
                "Cardiología",
                "Endoscopia",
                "Patología",
                "Microbiología"
            });
            cmbTipoExamen.SelectedIndex = 0;

            // Combo Nombre de Examen
            cmbNombreExamen.Items.Clear();
            cmbNombreExamen.Items.AddRange(new[] {
                "Hemograma completo",
                "Glicemia",
                "Perfil lipídico",
                "Rayos X",
                "Ecografía",
                "Electrocardiograma",
                "Urocultivo",
                "Examen de orina",
                "Creatinina",
                "Hemoglobina glicosilada"
            });
            cmbNombreExamen.SelectedIndex = 0;

            // Combo Unidad de Medida
            cmbUnidadMedida.Items.Clear();
            cmbUnidadMedida.Items.AddRange(new[] {
                "mg/dL",
                "g/dL",
                "mmol/L",
                "UI/L",
                "ng/mL",
                "µg/dL",
                "mEq/L",
                "mm/hr",
                "Normal/Anormal",
                "Positivo/Negativo"
            });
            cmbUnidadMedida.SelectedIndex = 0;
        }

        private async void Resultados_Load(object sender, EventArgs e)
        {
            await CargarCombosAsync();
            await CargarResultadosAsync();
            dgvResultados.SelectionChanged += dgvResultados_SelectionChanged;
        }

        private async Task CargarCombosAsync()
        {
            try
            {
                var pacienteService = _serviceProvider.GetRequiredService<IPacienteService>();
                var usuarioService = _serviceProvider.GetRequiredService<IUsuarioService>();
                var citaService = _serviceProvider.GetRequiredService<ICitaService>();

                // Cargar pacientes
                var pacientes = await pacienteService.ObtenerTodosAsync();
                cmbPaciente.DataSource = null;
                cmbPaciente.DataSource = pacientes;
                cmbPaciente.DisplayMember = "Nombres";
                cmbPaciente.ValueMember = "Id";
                cmbPaciente.SelectedIndex = -1;

                // Cargar médicos
                var medicos = (await usuarioService.ObtenerMedicosAsync()).ToList();
                cmbMedico.DataSource = null;
                cmbMedico.DataSource = medicos;
                cmbMedico.DisplayMember = "NombreCompleto";
                cmbMedico.ValueMember = "Id";
                cmbMedico.SelectedIndex = -1;

                // Cargar citas
                var citas = (await citaService.ObtenerTodasAsync())
                .Where(c => !string.Equals(c.Estado, "cancelada", StringComparison.OrdinalIgnoreCase))
                .Select(c => new
                {
                    Id = c.Id,
                    Motivo = char.ToUpper(c.Motivo[0]) + c.Motivo.Substring(1)
                })
                .ToList();

                cmbCita.DataSource = null;
                cmbCita.DataSource = citas;
                cmbCita.DisplayMember = "Motivo";
                cmbCita.ValueMember = "Id";
                cmbCita.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }
            cmbPaciente.SelectedIndexChanged += FiltroCitas_Changed;
            cmbMedico.SelectedIndexChanged += FiltroCitas_Changed;
        }

        private async void FiltroCitas_Changed(object sender, EventArgs e)
        {
            try
            {
                var citaService = _serviceProvider.GetRequiredService<ICitaService>();
                int? pacienteId = cmbPaciente.SelectedValue is int pid && pid > 0 ? pid : (int?)null;
                int? medicoId = cmbMedico.SelectedValue is int mid && mid > 0 ? mid : (int?)null;

                var todasCitas = (await citaService.ObtenerTodasAsync())
                .Where(c => !string.Equals(c.Estado, "cancelada", StringComparison.OrdinalIgnoreCase))
                .ToList();

                var citasFiltradas = todasCitas
                .Where(c =>
                    (!pacienteId.HasValue || c.PacienteId == pacienteId) &&
                    (!medicoId.HasValue || c.MedicoId == medicoId)
                )
                .Select(c => new Cita
                {
                    Id = c.Id,
                    PacienteId = c.PacienteId,
                    MedicoId = c.MedicoId,
                    FechaHora = c.FechaHora,
                    Estado = c.Estado,
                    Activo = c.Activo,
                    // Capitalizar motivo
                    Motivo = !string.IsNullOrWhiteSpace(c.Motivo)
                        ? char.ToUpper(c.Motivo[0]) + c.Motivo.Substring(1).ToLower()
                        : c.Motivo
                })
                .ToList();

                cmbCita.DataSource = null;
                cmbCita.DataSource = citasFiltradas;
                cmbCita.DisplayMember = "Motivo";
                cmbCita.ValueMember = "Id";
                cmbCita.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar citas: " + ex.Message);
            }
        }

        private async Task CargarResultadosAsync()
        {
            try
            {
                var resultados = (await _resultadoService.ObtenerTodosAsync()).ToList();
                _resultadosOriginales = resultados;

                var resultadosAMostrar = resultados.Select(r => new
                {
                    r.Id,
                    Paciente = r.Paciente != null ? $"{r.Paciente.Nombres} {r.Paciente.Apellidos}" : "N/A",
                    Medico = r.MedicoSolicitanteNavigation?.NombreCompleto ?? "N/A",
                    Cita = r.Cita != null ? string.IsNullOrWhiteSpace(r.Cita.Motivo) ? string.Empty : char.ToUpper(r.Cita.Motivo[0]) + r.Cita.Motivo.Substring(1) : "N/A",
                    r.NombreExamen,
                    r.TipoExamen,
                    r.FechaSolicitud,
                    r.FechaResultado,
                    r.UnidadMedida,
                    r.Resultado1,
                    r.ArchivoAdjunto
                }).ToList();

                dgvResultados.DataSource = resultadosAMostrar;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar resultados: {ex.Message}");
            }
        }

        private void dgvResultados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvResultados.CurrentRow?.DataBoundItem != null)
            {
                // Obtener el Id de la fila seleccionada
                int resultadoId = (int)dgvResultados.CurrentRow.Cells["Id"].Value;

                // Buscar el resultado original en la lista
                var resultado = _resultadosOriginales.FirstOrDefault(x => x.Id == resultadoId);
                if (resultado != null)
                {
                    cmbPaciente.SelectedValue = resultado.PacienteId;
                    cmbCita.SelectedValue = resultado.CitaId ?? -1;
                    cmbMedico.SelectedValue = resultado.MedicoSolicitante;
                    cmbTipoExamen.Text = resultado.TipoExamen ?? "";
                    cmbNombreExamen.Text = resultado.NombreExamen ?? "";
                    dtFechaSolicitud.Value = resultado.FechaSolicitud;
                    dtFechaResultado.Value = resultado.FechaResultado ?? DateTime.Today;
                    rtbResultado.Text = resultado.Resultado1 ?? "";
                    cmbUnidadMedida.Text = resultado.UnidadMedida ?? "";
                    txtArchivoAdjunto.Text = resultado.ArchivoAdjunto ?? "pendiente";
                }
            }
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (cmbPaciente.SelectedValue == null)
            {
                MessageBox.Show("Por favor seleccione un paciente.");
                return;
            }

            if (cmbMedico.SelectedValue == null)
            {
                MessageBox.Show("Por favor seleccione un médico.");
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbTipoExamen.Text))
            {
                MessageBox.Show("Por favor seleccione un tipo de examen.");
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbNombreExamen.Text))
            {
                MessageBox.Show("Por favor seleccione un nombre de examen.");
                return;
            }

            try
            {
                var nuevoResultado = new Resultado
                {
                    PacienteId = (int)cmbPaciente.SelectedValue,
                    CitaId = cmbCita.SelectedValue != null && (int)cmbCita.SelectedValue > 0 ? (int?)cmbCita.SelectedValue : null,
                    MedicoSolicitante = (int)cmbMedico.SelectedValue,
                    TipoExamen = cmbTipoExamen.Text,
                    NombreExamen = cmbNombreExamen.Text,
                    FechaSolicitud = dtFechaSolicitud.Value,
                    FechaResultado = dtFechaResultado.Value,
                    Resultado1 = rtbResultado.Text,
                    UnidadMedida = cmbUnidadMedida.Text,
                    ArchivoAdjunto = string.IsNullOrWhiteSpace(rtbResultado.Text) ? "pendiente" : "completado"
                };

                var operacion = await _resultadoService.AgregarAsync(nuevoResultado);

                if (!operacion.Exito)
                {
                    string errores = operacion.Errores != null && operacion.Errores.Any()
                        ? "\n" + string.Join("\n", operacion.Errores)
                        : "";
                    MessageBox.Show("Error al guardar resultado: " + operacion.Mensaje + errores);
                    return;
                }

                MessageBox.Show("Resultado guardado correctamente.");
                await CargarResultadosAsync();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            // Verificar que haya una fila seleccionada
            if (dgvResultados.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un resultado para modificar.");
                return;
            }

            // Obtener el Id del resultado seleccionado
            if (dgvResultados.CurrentRow.Cells["Id"].Value is not int resultadoId)
            {
                MessageBox.Show("No se pudo obtener el Id del resultado.");
                return;
            }

            // Validaciones completas
            if (cmbPaciente.SelectedValue == null)
            {
                MessageBox.Show("Por favor seleccione un paciente.");
                return;
            }

            if (cmbMedico.SelectedValue == null)
            {
                MessageBox.Show("Por favor seleccione un médico.");
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbTipoExamen.Text))
            {
                MessageBox.Show("Por favor seleccione un tipo de examen.");
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbNombreExamen.Text))
            {
                MessageBox.Show("Por favor seleccione un nombre de examen.");
                return;
            }

            // Confirmación antes de modificar
            var confirmacion = MessageBox.Show(
                "¿Está seguro que desea modificar este resultado?",
                "Confirmar modificación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion != DialogResult.Yes)
                return;

            try
            {
                /*
                // Debug: Mostrar qué se está intentando modificar
                MessageBox.Show($"DEBUG: Modificando resultado ID: {resultadoId}\n" +
                               $"Paciente: {cmbPaciente.Text}\n" +
                               $"Médico: {cmbMedico.Text}\n" +
                               $"Tipo: {cmbTipoExamen.Text}\n" +
                               $"Nombre: {cmbNombreExamen.Text}");
                */

                // Crear un nuevo objeto Resultado con los datos del formulario
                var resultadoModificado = new Resultado
                {
                    Id = resultadoId, // Asignar el ID del resultado existente
                    PacienteId = (int)cmbPaciente.SelectedValue,
                    CitaId = cmbCita.SelectedValue != null && (int)cmbCita.SelectedValue > 0 ? (int?)cmbCita.SelectedValue : null,
                    MedicoSolicitante = (int)cmbMedico.SelectedValue,
                    TipoExamen = cmbTipoExamen.Text,
                    NombreExamen = cmbNombreExamen.Text,
                    FechaSolicitud = dtFechaSolicitud.Value,
                    FechaResultado = dtFechaResultado.Value,
                    Resultado1 = rtbResultado.Text,
                    UnidadMedida = cmbUnidadMedida.Text,
                    ArchivoAdjunto = string.IsNullOrWhiteSpace(rtbResultado.Text) ? "pendiente" : "completado"
                };

                /*
                MessageBox.Show("DEBUG: Llamando al servicio ModificarAsync...");
                */
                var operacion = await _resultadoService.ModificarAsync(resultadoModificado);

                /*
                MessageBox.Show($"DEBUG: Operación completada. Éxito: {operacion.Exito}");
                */

                if (!operacion.Exito)
                {
                    string errores = operacion.Errores != null && operacion.Errores.Any()
                        ? "\n" + string.Join("\n", operacion.Errores)
                        : "";
                    MessageBox.Show("Error al modificar resultado: " + operacion.Mensaje + errores);
                    return;
                }

                MessageBox.Show("Resultado modificado correctamente.");
                await CargarResultadosAsync();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al modificar: " + ex.Message);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvResultados.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un resultado para eliminar.");
                return;
            }

            // Obtener el Id del resultado seleccionado
            if (dgvResultados.CurrentRow.Cells["Id"].Value is not int resultadoId)
            {
                MessageBox.Show("No se pudo obtener el Id del resultado.");
                return;
            }

            // Buscar el resultado real en la lista original
            var resultado = _resultadosOriginales.FirstOrDefault(r => r.Id == resultadoId);
            if (resultado == null)
            {
                MessageBox.Show("No se encontró el resultado en la lista original.");
                return;
            }

            var confirm = MessageBox.Show("¿Desea eliminar este resultado?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var exito = await _resultadoService.EliminarAsync(resultado.Id);
                    if (exito)
                    {
                        MessageBox.Show("Resultado eliminado correctamente.");
                        await CargarResultadosAsync();
                        LimpiarFormulario();
                    }
                    else
                    {
                        MessageBox.Show("Error: No se pudo eliminar el resultado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar resultado: " + ex.Message);
                }
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int? pacienteId = null;
                int? medicoId = null;

                if (cmbPaciente.SelectedItem is Paciente paciente)
                    pacienteId = paciente.Id;

                if (cmbMedico.SelectedItem is Usuario medico)
                    medicoId = medico.Id;

                // Criterios adicionales de búsqueda
                string tipoExamenCriterio = !string.IsNullOrWhiteSpace(cmbTipoExamen.Text) ? cmbTipoExamen.Text.Trim() : null;
                string nombreExamenCriterio = !string.IsNullOrWhiteSpace(cmbNombreExamen.Text) ? cmbNombreExamen.Text.Trim() : null;
                DateTime? fechaSolicitudCriterio = dtFechaSolicitud.Checked ? dtFechaSolicitud.Value.Date : (DateTime?)null;

                // Obtener todos los resultados
                var resultados = (await _resultadoService.ObtenerTodosAsync()).ToList();

                // Filtrar por criterios
                var filtrados = resultados.Where(r =>
                    (!pacienteId.HasValue || r.PacienteId == pacienteId) &&
                    (!medicoId.HasValue || r.MedicoSolicitante == medicoId) &&
                    (string.IsNullOrWhiteSpace(tipoExamenCriterio) || (r.TipoExamen != null && r.TipoExamen.Contains(tipoExamenCriterio, StringComparison.OrdinalIgnoreCase))) &&
                    (string.IsNullOrWhiteSpace(nombreExamenCriterio) || (r.NombreExamen != null && r.NombreExamen.Contains(nombreExamenCriterio, StringComparison.OrdinalIgnoreCase))) &&
                    (!fechaSolicitudCriterio.HasValue || r.FechaSolicitud.Date == fechaSolicitudCriterio.Value)
                ).ToList();

                // Actualizar la lista de resultados originales con los filtrados
                _resultadosOriginales = filtrados;

                // Proyectar a objeto anónimo para mostrar
                var resultadosAMostrar = filtrados.Select(r => new
                {
                    r.Id,
                    Paciente = r.Paciente != null ? $"{r.Paciente.Nombres} {r.Paciente.Apellidos}" : "N/A",
                    Medico = r.MedicoSolicitanteNavigation?.NombreCompleto ?? "N/A",
                    r.NombreExamen,
                    r.TipoExamen,
                    r.FechaSolicitud,
                    r.FechaResultado,
                    r.UnidadMedida,
                    r.Resultado1,
                    r.ArchivoAdjunto
                }).ToList();

                dgvResultados.DataSource = resultadosAMostrar;

                // Mensaje si no hay resultados
                if (!resultadosAMostrar.Any())
                    MessageBox.Show("No se encontraron resultados con los criterios seleccionados.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la búsqueda: " + ex.Message);
            }
        }

        private async void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            LimpiarFormulario();

            // Recargar la lista completa de resultados
            await CargarResultadosAsync();
        }

        private void LimpiarFormulario()
        {
            cmbPaciente.SelectedIndex = -1;
            cmbMedico.SelectedIndex = -1;
            cmbCita.SelectedIndex = -1;
            cmbTipoExamen.SelectedIndex = 0;
            cmbNombreExamen.SelectedIndex = 0;
            cmbUnidadMedida.SelectedIndex = 0;

            dtFechaSolicitud.Value = DateTime.Today;
            dtFechaResultado.Value = DateTime.Today;

            rtbResultado.Clear();
        }

        // Navegación entre formularios
        private void btnResultados_Click(object sender, EventArgs e)
        {
            // Ya estamos en resultados, no hacer nada
        }

        private void lblInicio_Click(object sender, EventArgs e)
        {
            var inicio = _serviceProvider.GetRequiredService<Inicio>();
            inicio.Show();
            this.Hide();
        }

        private void lblPacientes_Click(object sender, EventArgs e)
        {
            var pacientes = _serviceProvider.GetRequiredService<Pacientes>();
            pacientes.Show();
            this.Hide();
        }

        private void lblCitas_Click(object sender, EventArgs e)
        {
            var citas = _serviceProvider.GetRequiredService<Citas>();
            citas.Show();
            this.Hide();
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            if (cmbPaciente.SelectedItem is not Paciente paciente)
            {
                MessageBox.Show("Seleccione un paciente para exportar sus resultados.");
                return;
            }
            // Filtra resultados del paciente seleccionado
            var resultadosPaciente = _resultadosOriginales.Where(r => r.PacienteId == paciente.Id).ToList();
            if (!resultadosPaciente.Any())
            {
                MessageBox.Show("No hay resultados para exportar de este paciente.");
                return;
            }

            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Archivo PDF|*.pdf";
                saveFileDialog.Title = "Guardar Resultados en PDF";
                saveFileDialog.FileName = $"Resultados_{paciente.Nombres}_{paciente.Apellidos}_{DateTime.Now:yyyyMMdd}.pdf";
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                var doc = new Document(PageSize.A4, 40, 40, 40, 40);
                using (var stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    PdfWriter.GetInstance(doc, stream);
                    doc.Open();

                    // Logo
                    var logo = iTextSharp.text.Image.GetInstance("../../../img/logo.png");
                    float availableWidth = doc.PageSize.Width - doc.LeftMargin - doc.RightMargin;
                    logo.ScaleToFit(availableWidth, 120);
                    logo.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                    doc.Add(logo);

                    // Título
                    var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                    var subFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                    doc.Add(new Paragraph("Resultados de Laboratorio", titleFont) { Alignment = Element.ALIGN_CENTER });
                    doc.Add(new Paragraph($"Paciente: {paciente.Nombres} {paciente.Apellidos}", subFont));
                    doc.Add(new Paragraph($"DNI: {paciente.Dni}", subFont));
                    doc.Add(new Paragraph($"Fecha de Exportación: {DateTime.Now:dd/MM/yyyy}", subFont));
                    doc.Add(new Paragraph(" "));

                    // Tabla de resultados
                    var table = new PdfPTable(6) { WidthPercentage = 100 };
                    table.SetWidths(new float[] { 2, 2, 2, 2, 2, 2 });
                    table.AddCell("Fecha");
                    table.AddCell("Examen");
                    table.AddCell("Tipo");
                    table.AddCell("Resultado");
                    table.AddCell("Unidad");
                    table.AddCell("Médico");

                    foreach (var r in resultadosPaciente)
                    {
                        table.AddCell(r.FechaSolicitud.ToString("dd/MM/yyyy"));
                        table.AddCell(r.NombreExamen);
                        table.AddCell(r.TipoExamen);
                        table.AddCell(r.Resultado1 ?? "");
                        table.AddCell(r.UnidadMedida ?? "");
                        table.AddCell(r.MedicoSolicitanteNavigation?.NombreCompleto ?? "");
                    }
                    doc.Add(table);

                    doc.Close();
                }
                MessageBox.Show("PDF exportado correctamente.", "Exportación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
