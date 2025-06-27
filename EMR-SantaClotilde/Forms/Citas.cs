using EMR_SantaClotilde.Services;
using EMR_SantaClotilde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EMR_SantaClotilde
{
    public partial class Citas : Form
    {
        private readonly ICitaService _citaService;
        private readonly IResultadoService _resultadoService;
        public Citas(ICitaService citaService)
        {
            _citaService = citaService;
            InitializeComponent();
            this.Load += Citas_Load;
        }

        private void Citas_Load(object sender, EventArgs e)
        {
            CargarCitasDelDia();
            dgvCitas.SelectionChanged += dgvCitas_SelectionChanged;
            // TODO: Cargar datos a combos: cmbPaciente, cmbMedico, cmbEstado
        }

        private void CargarCitasDelDia()
        {
            var citas = _citaService.ObtenerPorFechaAsync(DateTime.Today);
            dgvCitas.DataSource = citas;
        }

        private void dgvCitas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCitas.CurrentRow?.DataBoundItem is Cita cita)
            {
                cmbPaciente.SelectedValue = cita.PacienteId;
                cmbMedico.SelectedValue = cita.MedicoId;
                dtFecha.Value = cita.FechaHora;
                cmbEstado.Text = cita.Estado;
                rtbObservaciones.Text = cita.Observaciones;
                richMotivo.Text = cita.Motivo;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbMedico.SelectedItem is Usuario medico)
            {
                var citas = _citaService.ObtenerPorMedicoAsync(medico.Id);
                dgvCitas.DataSource = citas;
            }
            else if (cmbPaciente.SelectedItem is Paciente paciente)
            {
                var citas = _citaService.ObtenerPorPacienteAsync(paciente.Id);
                dgvCitas.DataSource = citas;
            }
            else
            {
                MessageBox.Show("Seleccione un médico o paciente.");
            }
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
                    Estado = cmbEstado.Text,
                    Tipo = "Consulta", // o podrías usar un combo adicional
                    Motivo = richMotivo.Text,
                    Observaciones = rtbObservaciones.Text,
                    Sincronizado = false
                };

                var resultado = await _citaService.CrearAsync(nuevaCita);

                if (!resultado.Exito)
                {
                    MessageBox.Show("Error al crear cita: " + resultado.Mensaje);
                    return;
                }

                MessageBox.Show("Cita registrada correctamente.");
                CargarCitasDelDia();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.CurrentRow?.DataBoundItem is not Cita citaExistente)
            {
                MessageBox.Show("Seleccione una cita para modificar.");
                return;
            }

            try
            {
                citaExistente.PacienteId = (int)cmbPaciente.SelectedValue;
                citaExistente.MedicoId = (int)cmbMedico.SelectedValue;
                citaExistente.FechaHora = dtFecha.Value;
                citaExistente.Estado = cmbEstado.Text;
                citaExistente.Motivo = richMotivo.Text;
                citaExistente.Observaciones = rtbObservaciones.Text;

                var resultado = await _citaService.ActualizarAsync(citaExistente);

                if (!resultado.Exito)
                {
                    MessageBox.Show("Error al modificar la cita: " + resultado.Mensaje);
                    return;
                }

                MessageBox.Show("Cita modificada correctamente.");
                CargarCitasDelDia();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.CurrentRow?.DataBoundItem is Cita cita)
            {
                var motivo = Microsoft.VisualBasic.Interaction.InputBox("Motivo de cancelación:", "Cancelar Cita");
                if (string.IsNullOrWhiteSpace(motivo)) return;

                var resultado = await _citaService.CancelarAsync(cita.Id, motivo);
                if (!resultado.Exito)
                {
                    MessageBox.Show("Error al cancelar cita: " + resultado.Mensaje);
                    return;
                }

                MessageBox.Show("Cita cancelada correctamente.");
                CargarCitasDelDia();
            }
            else
            {
                MessageBox.Show("Seleccione una cita para cancelar.");
            }
        }

        private void lblResultados_Click(object sender, EventArgs e)
        {
            var resultadosForm = new Resultados(_resultadoService);
            resultadosForm.Show();
            this.Hide();
        }

        private void lblInicio_Click(object sender, EventArgs e)
        {
            var inicioForm = new Inicio(_citaService);
            inicioForm.Show();
            this.Hide();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.CurrentRow?.DataBoundItem is Cita cita)
            {
                var confirm = MessageBox.Show("¿Desea eliminar esta cita?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var resultado = await _citaService.CancelarAsync(cita.Id, "Motivo");
                    if (!resultado.Exito)
                    {
                        MessageBox.Show("Error al eliminar cita: " + resultado.Mensaje);
                        return;
                    }

                    MessageBox.Show("Cita eliminada correctamente.");
                    CargarCitasDelDia();
                }
            }
        }
    }
}
