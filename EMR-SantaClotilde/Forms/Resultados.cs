using EMR_SantaClotilde.Services;
using System;
using System.Windows.Forms;

namespace EMR_SantaClotilde
{
    public partial class Resultados : Form
    {
        private readonly ICitaService _citaService;
        private readonly IResultadoService _resultadoService;

        public Resultados(ICitaService citaService, IResultadoService resultadoService)
        {
            _citaService = citaService;
            _resultadoService = resultadoService;
        
            InitializeComponent();
        
            this.Load += Resultados_Load;
        }

        private void Resultados_Load(object sender, EventArgs e)
        {
            CargarResultados();
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
                    MessageBox.Show("Error al guardar: " + operacion.MensajeError);
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


                private void CargarResultados()
        {
            var resultados = _resultadoService.ObtenerTodos();
            dgvResultados.DataSource = resultados.ToList();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbPaciente.SelectedItem is Paciente paciente)
            {
                var resultados = _resultadoService.BuscarPorPaciente(paciente.Id);
                dgvResultados.DataSource = resultados.ToList();
            }
            else
            {
                MessageBox.Show("Seleccione un paciente.");
            }
        }
        
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvResultados.CurrentRow?.DataBoundItem is Resultado resultado)
            {
                var confirm = MessageBox.Show("¿Desea eliminar este resultado?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    _resultadoService.Eliminar(resultado.Id);
                    MessageBox.Show("Resultado eliminado correctamente.");
                    CargarResultados();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un resultado para eliminar.");
            }
        }

        private void btnResultados_Click(object sender, EventArgs e)
        {
            Resultados resultados = new Resultados(_citaService);
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
