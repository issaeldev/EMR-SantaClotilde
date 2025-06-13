using EMR_SantaClotilde.Models;
using EMR_SantaClotilde.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMR_SantaClotilde
{
    public partial class Inicio : Form
    {
        private readonly ICitaService _citaService;
        public Inicio(ICitaService citaService)
        {
            _citaService = citaService;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarAgendaDelDia();
        }

        private void CargarAgendaDelDia()
        {
            try
            {
                var citas = _citaService.ObtenerCitasDelDia(DateTime.Today.AddDays(1));
                MostrarCitasEnListView(citas);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la agenda: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarCitasEnListView(List<Cita> citas)
        {
            lstAgenda.Items.Clear();
            foreach (var cita in citas)
            {
                var hora = cita.FechaHora.ToString("hh:mm tt");
                var paciente = cita.Paciente?.ToString() ?? "Paciente no disponible";
                var detalle = cita.Motivo ?? cita.Tipo;

                var item = new ListViewItem(new[] { hora, paciente, detalle });
                item.Tag = cita.Id; // Guardamos el ID para referencia futura
                lstAgenda.Items.Add(item);
            }
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            // Pacientes pacientes = new Pacientes();

            // pacientes.Show();
            // this.Hide(); 
        }

        private void BtnCitas_Click(object sender, EventArgs e)
        {
            // Crear una nueva instancia del segundo formulario
            Citas citas = new Citas(_citaService);

            citas.Show();
            this.Hide();  
        }

        private void BtnResultados_Click(object sender, EventArgs e)
        {
            Resultados resultados = new Resultados(_citaService);

            resultados.Show();
            this.Hide();
        }
    }
}
