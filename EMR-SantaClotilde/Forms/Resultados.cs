using EMR_SantaClotilde.Services;
using EMR_SantaClotilde.Models;
using System;
using System.Windows.Forms;

namespace EMR_SantaClotilde
{
    public partial class Resultados : Form
    {
        private readonly ICitaService _citaService;
        private readonly IResultadoService _resultadoService;

        public Resultados(IResultadoService resultadoService)
        {
            _resultadoService = resultadoService;
        
            InitializeComponent();
        
            this.Load += Resultados_Load;
        }

        private void Resultados_Load(object sender, EventArgs e)
        {
            CargarResultados();
            dgvResultados.SelectionChanged += dgvResultados_SelectionChanged;
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbPaciente.SelectedItem == null || cmbMedico.SelectedItem == null)
            {
                MessageBox.Show("Por favor selecciona un paciente y un médico.");
                return;
            }
        
            try
            {
                var nuevoResultado = new Resultado
                {
                    PacienteId = (int)cmbPaciente.SelectedValue,
                    CitaId = cmbCita.SelectedItem != null ? (int?)cmbCita.SelectedValue : null,
                    MedicoSolicitante = (int)cmbMedico.SelectedValue,
                    TipoExamen = cmbTipoExamen.Text,
                    NombreExamen = cmbNombreExamen.Text,
                    FechaSolicitud = dtFechaSolicitud.Value,
                    FechaResultado = dtFechaResultado.Value,
                    Resultado1 = rtbResultado.Text,
                    UnidadMedida = cmbUnidadMedida.Text,
                    ArchivoAdjunto = "pendiente" // se puede reemplazar luego con la ruta del archivo
                };
        
                var operacion = await _resultadoService.AgregarAsync(nuevoResultado);
        
                if (!operacion.Exito)
                {
                    MessageBox.Show("Error al guardar: " + operacion.Mensaje);
                    return;
                }
        
                MessageBox.Show("Resultado guardado correctamente.");
                CargarResultados(); // refresca la grilla
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private async void CargarResultados()
        {
            var resultados = await _resultadoService.ObtenerTodosAsync();
            dgvResultados.DataSource = resultados.ToList();
        }


        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbPaciente.SelectedItem is Paciente paciente)
            {
                var resultados = await _resultadoService.BuscarPorPacienteAsync(paciente.Id);
                dgvResultados.DataSource = resultados.ToList();
            }
            else
            {
                MessageBox.Show("Seleccione un paciente.");
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvResultados.CurrentRow?.DataBoundItem is not Resultado resultadoExistente)
            {
                MessageBox.Show("Seleccione un resultado para modificar.");
                return;
            }
        
            try
            {
                resultadoExistente.PacienteId = (int)cmbPaciente.SelectedValue;
                resultadoExistente.CitaId = cmbCita.SelectedItem != null ? (int?)cmbCita.SelectedValue : null;
                resultadoExistente.MedicoSolicitante = (int)cmbMedico.SelectedValue;
                resultadoExistente.TipoExamen = cmbTipoExamen.Text;
                resultadoExistente.NombreExamen = cmbNombreExamen.Text;
                resultadoExistente.FechaSolicitud = dtFechaSolicitud.Value;
                resultadoExistente.FechaResultado = dtFechaResultado.Value;
                resultadoExistente.Resultado1 = rtbResultado.Text;
                resultadoExistente.UnidadMedida = cmbUnidadMedida.Text;
                resultadoExistente.ArchivoAdjunto = "pendiente"; // ajustar luego si usas archivos
        
                var operacion = await _resultadoService.ModificarAsync(resultadoExistente);
        
                if (!operacion.Exito)
                {
                    MessageBox.Show("Error al modificar: " + operacion.Mensaje);
                    return;
                }
        
                MessageBox.Show("Resultado modificado correctamente.");
                CargarResultados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private void dgvResultados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvResultados.CurrentRow?.DataBoundItem is Resultado resultado)
            {
                cmbPaciente.SelectedValue = resultado.PacienteId;
                cmbCita.SelectedValue = resultado.CitaId ?? -1;
                cmbMedico.SelectedValue = resultado.MedicoSolicitante;
                cmbTipoExamen.Text = resultado.TipoExamen;
                cmbNombreExamen.Text = resultado.NombreExamen;
                dtFechaSolicitud.Value = resultado.FechaSolicitud;
                dtFechaResultado.Value = resultado.FechaResultado ?? DateTime.Today;
                rtbResultado.Text = resultado.Resultado1;
                cmbUnidadMedida.Text = resultado.UnidadMedida;
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvResultados.CurrentRow?.DataBoundItem is Resultado resultado)
            {
                var confirm = MessageBox.Show("¿Desea eliminar este resultado?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var exito = await _resultadoService.EliminarAsync(resultado.Id);
                    if (exito)
                    {
                        MessageBox.Show("Resultado eliminado correctamente.");
                        CargarResultados();
                    }
                    else
                    {
                        MessageBox.Show("Error: No se pudo eliminar el resultado.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un resultado para eliminar.");
            }
        }

        private void btnResultados_Click(object sender, EventArgs e)
        {
            var resultados = new Resultados(_resultadoService);
            resultados.Show();
            this.Hide();
        }

        private void lblInicio_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio(_citaService);
            inicio.Show();
            this.Hide();
        }

        private void lblPacientes_Click(object sender, EventArgs e)
        {
            /*
            Pacientes pacientes = new Pacientes();
            pacientes.Show();
            this.Hide(); 
            */
        }

        private void lblCitas_Click(object sender, EventArgs e)
        {
            Citas citas = new Citas(_citaService);
            citas.Show();
            this.Hide();
        }

    }
}
