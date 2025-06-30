using EMR_SantaClotilde.Services;
using EMR_SantaClotilde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EMR_SantaClotilde.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace EMR_SantaClotilde
{
    public partial class Citas : Form
    {
        private readonly ICitaService _citaService;
        private readonly IServiceProvider _serviceProvider;
        private List<Cita> _citasOriginales = new List<Cita>();


        public Citas(IServiceProvider serviceProvider, ICitaService citaService)
        {
            _serviceProvider = serviceProvider;
            _citaService = citaService;

            InitializeComponent();

            cmbEstado.Items.Clear();
            cmbEstado.Items.AddRange(new[] { "Programada", "Completada", "Cancelada" });
            cmbEstado.SelectedIndex = 0;

            cmbTipo.Items.Clear();
            cmbTipo.Items.AddRange(new[] { "Consulta", "Control", "Emergencia" });
            cmbTipo.SelectedIndex = 0;

            cmbMotivo.Items.Clear();
            cmbMotivo.Items.AddRange(new[] {
                "Dolor general",
                "Síntomas respiratorios",
                "Chequeo general",
                "Resultados de estudios",
                "Renovación de receta",
                "Dolor de cabeza",
                "Problemas digestivos",
                "Seguimiento de tratamiento",
                "Consulta por derivación",
                "Vacunación"
            });
            cmbMotivo.SelectedIndex = 0;

            this.Load += Citas_Load;
        }

        private async void Citas_Load(object sender, EventArgs e)
        {
            await CargarPacientesYMedicosAsync();
            await CargarCitasDelDia();
            dgvCitas.SelectionChanged += dgvCitas_SelectionChanged;
            // TODO: Cargar datos a combos: cmbPaciente, cmbMedico, cmbEstado
        }

        private async Task CargarPacientesYMedicosAsync()
        {
            var pacienteService = _serviceProvider.GetRequiredService<IPacienteService>();
            var usuarioService = _serviceProvider.GetRequiredService<IUsuarioService>();

            var pacientes = await pacienteService.ObtenerTodosAsync();
            cmbPaciente.DataSource = null;
            cmbPaciente.DataSource = pacientes;
            cmbPaciente.DisplayMember = "Nombres"; // o "NombreCompleto"
            cmbPaciente.ValueMember = "Id";
            cmbPaciente.SelectedIndex = -1;

            var medicos = (await usuarioService.ObtenerMedicosAsync()).ToList();
            cmbMedico.DataSource = null;
            cmbMedico.DataSource = medicos;
            cmbMedico.DisplayMember = "NombreCompleto"; // o "Nombres"
            cmbMedico.ValueMember = "Id";
            cmbMedico.SelectedIndex = -1;
        }
        private async Task CargarCitasDelDia()
        {
            var citas = (await _citaService.ObtenerTodasAsync()).ToList();
            _citasOriginales = citas;

            var citasAMostrar = citas.Select(c => new
            {
                c.Id,
                Fecha = c.FechaHora,
                Paciente = c.Paciente != null ? $"{c.Paciente.Nombres} {c.Paciente.Apellidos}" : "",
                Medico = c.Medico != null ? c.Medico.NombreCompleto : "",
                Estado = !string.IsNullOrWhiteSpace(c.Estado)
                     ? char.ToUpper(c.Estado[0]) + c.Estado.Substring(1).ToLower()
                     : "",
                Tipo = !string.IsNullOrWhiteSpace(c.Tipo)
                   ? char.ToUpper(c.Tipo[0]) + c.Tipo.Substring(1).ToLower()
                   : "",
                Motivo = !string.IsNullOrWhiteSpace(c.Motivo)
                   ? char.ToUpper(c.Motivo[0]) + c.Motivo.Substring(1).ToLower()
                   : "",
                AdicionalMotivo = c.AdicionalMotivo,
                Observaciones = c.Observaciones,
                c.Sincronizado,
                c.Activo,
                FechaCreacion = c.FechaCreacion,
                FechaModificacion = c.FechaModificacion
            }).ToList();

            dgvCitas.DataSource = citasAMostrar;
        }

        private void dgvCitas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCitas.CurrentRow?.DataBoundItem != null)
            {
                // Obtén el Id de la fila seleccionada
                int citaId = (int)dgvCitas.CurrentRow.Cells["Id"].Value;

                // Busca la cita original en la lista
                var cita = _citasOriginales.FirstOrDefault(x => x.Id == citaId);
                if (cita != null)
                {
                    cmbPaciente.SelectedValue = cita.PacienteId;
                    cmbMedico.SelectedValue = cita.MedicoId;
                    dtFecha.Value = cita.FechaHora;
                    cmbEstado.Text = string.IsNullOrWhiteSpace(cita.Estado) ? string.Empty : char.ToUpper(cita.Estado[0]) + cita.Estado.Substring(1);
                    cmbTipo.Text = string.IsNullOrWhiteSpace(cita.Tipo) ? string.Empty : char.ToUpper(cita.Tipo[0]) + cita.Tipo.Substring(1);
                    cmbMotivo.Text = string.IsNullOrWhiteSpace(cita.Motivo) ? string.Empty : char.ToUpper(cita.Motivo[0]) + cita.Motivo.Substring(1);
                    rtbObservaciones.Text = cita.Observaciones;
                    richMotivo.Text = cita.AdicionalMotivo;
                }
            }
        }

        private async void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbMedico.SelectedIndex = -1;
            cmbPaciente.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            cmbTipo.SelectedIndex = -1;
            cmbMotivo.SelectedIndex = -1;

            if (dtFecha is { })
            {
                dtFecha.Value = DateTime.Today;
            }

            // Recargar la lista completa de citas
            await CargarCitasDelDia();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            int? medicoId = null;
            int? pacienteId = null;

            if (cmbMedico.SelectedItem is Usuario medico)
                medicoId = medico.Id;

            if (cmbPaciente.SelectedItem is Paciente paciente)
                pacienteId = paciente.Id;

            // Aquí puedes agregar más criterios si lo deseas
            string estadoCriterio = cmbEstado.SelectedIndex > -1 ? cmbEstado.Text.Trim() : null;
            string tipoCriterio = cmbTipo.SelectedIndex > -1 ? cmbTipo.Text.Trim() : null;
            string motivoCriterio = cmbMotivo.SelectedIndex > -1 ? cmbMotivo.Text.Trim() : null;
            DateTime? fechaCriterio = dtFecha.Checked ? dtFecha.Value.Date : (DateTime?)null;

            // Obtener todas las citas
            var citas = (await _citaService.ObtenerTodasAsync()).ToList();

            // Filtrar por criterios
            var filtradas = citas.Where(c =>
                (!medicoId.HasValue || c.MedicoId == medicoId) &&
                (!pacienteId.HasValue || c.PacienteId == pacienteId) &&
                (string.IsNullOrWhiteSpace(estadoCriterio) || c.Estado.Equals(estadoCriterio, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(tipoCriterio) || c.Tipo.Equals(tipoCriterio, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(motivoCriterio) || (c.Motivo != null && c.Motivo.Contains(motivoCriterio, StringComparison.OrdinalIgnoreCase))) &&
                (!fechaCriterio.HasValue || c.FechaHora.Date == fechaCriterio.Value)
            ).ToList();

            // Proyectar a objeto anónimo para mostrar solo los campos que quieras (como en tu método de cargar citas)
            var citasAMostrar = filtradas.Select(c => new
            {
                c.Id,
                Fecha = c.FechaHora,
                Paciente = c.Paciente != null ? $"{c.Paciente.Nombres} {c.Paciente.Apellidos}" : "",
                Medico = c.Medico != null ? c.Medico.NombreCompleto : "",
                c.Estado,
                c.Tipo,
                Motivo = c.Motivo,
                AdicionalMotivo = c.AdicionalMotivo,
                Observaciones = c.Observaciones,
                c.Sincronizado,
                c.Activo,
                FechaCreacion = c.FechaCreacion,
                FechaModificacion = c.FechaModificacion
            }).ToList();

            dgvCitas.DataSource = citasAMostrar;

            // Opcional: mensaje si no hay resultados
            if (!citasAMostrar.Any())
                MessageBox.Show("No se encontraron citas con los criterios seleccionados.");
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var nuevaCita = new Cita
                {
                    PacienteId = (int)cmbPaciente.SelectedValue,
                    MedicoId = (int)cmbMedico.SelectedValue,
                    FechaHora = dtFecha.Value,
                    Estado = cmbEstado.Text.ToLower(),
                    Tipo = cmbTipo.Text.ToLower(),
                    Motivo = cmbMotivo.Text.ToLower(),
                    AdicionalMotivo = richMotivo.Text,
                    Observaciones = rtbObservaciones.Text,
                    FechaCreacion = DateTime.Now,
                    Activo = chkActivo.Checked,
                    Sincronizado = false
                };

                var resultado = await _citaService.CrearAsync(nuevaCita);

                if (!resultado.Exito)
                {
                    string errores = resultado.Errores != null && resultado.Errores.Any()
                    ? "\n" + string.Join("\n", resultado.Errores)
                    : "";
                    MessageBox.Show("Error al crear cita: " + resultado.Mensaje + errores);
                    return;
                }

                MessageBox.Show("Cita registrada correctamente.");
                await CargarCitasDelDia();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            // Verifica que haya una fila seleccionada
            if (dgvCitas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una cita para modificar.");
                return;
            }

            // Obtiene el Id de la cita seleccionada
            if (dgvCitas.CurrentRow.Cells["Id"].Value is not int citaId)
            {
                MessageBox.Show("No se pudo obtener el Id de la cita.");
                return;
            }

            // Busca la cita original en la lista completa
            var citaExistente = _citasOriginales.FirstOrDefault(c => c.Id == citaId);
            if (citaExistente == null)
            {
                MessageBox.Show("No se encontró la cita en la lista original.");
                return;
            }

            try
            {
                citaExistente.PacienteId = (int)cmbPaciente.SelectedValue;
                citaExistente.MedicoId = (int)cmbMedico.SelectedValue;
                citaExistente.FechaHora = dtFecha.Value;
                citaExistente.Estado = cmbEstado.Text.ToLower();
                citaExistente.Tipo = cmbTipo.Text.ToLower();
                citaExistente.Motivo = cmbMotivo.Text.ToLower();
                citaExistente.AdicionalMotivo = richMotivo.Text;
                citaExistente.Observaciones = rtbObservaciones.Text;
                citaExistente.FechaModificacion = DateTime.Now;
                citaExistente.Activo = chkActivo.Checked;

                var resultado = await _citaService.ActualizarAsync(citaExistente);

                if (!resultado.Exito)
                {
                    MessageBox.Show("Error al modificar la cita: " + resultado.Mensaje);
                    return;
                }

                MessageBox.Show("Cita modificada correctamente.");
                await CargarCitasDelDia();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una cita para eliminar.");
                return;
            }

            // Obtener el Id de la cita seleccionada desde la celda "Id"
            if (dgvCitas.CurrentRow.Cells["Id"].Value is not int citaId)
            {
                MessageBox.Show("No se pudo obtener el Id de la cita.");
                return;
            }

            // Buscar la cita real en la lista original
            var cita = _citasOriginales.FirstOrDefault(c => c.Id == citaId);
            if (cita == null)
            {
                MessageBox.Show("No se encontró la cita en la lista original.");
                return;
            }

            var confirm = MessageBox.Show("¿Desea eliminar esta cita?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                string motivoCancelacion = "Cancelada por el usuario"; 
                var resultado = await _citaService.CancelarAsync(cita.Id, motivoCancelacion);
                if (!resultado.Exito)
                {
                    MessageBox.Show("Error al eliminar cita: " + resultado.Mensaje);
                    return;
                }

                MessageBox.Show("Cita eliminada correctamente.");
                await CargarCitasDelDia();
            }
        }

        private void lblResultados_Click(object sender, EventArgs e)
        {
            var resultados = _serviceProvider.GetRequiredService<Resultados>();
            resultados.Show();
            this.Hide();
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
    }
}
