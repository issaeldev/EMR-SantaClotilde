using EMR_SantaClotilde.Forms;
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
        private readonly IResultadoService _resultadoService;
        private readonly IPacienteService _pacienteService;

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

        private void MostrarInformacionUsuario()
        {
            // Obtener el usuario actual de la sesión
            var usuario = SesionUsuario.Instance.UsuarioActual;
            if (usuario != null)
            {
                // Asumiendo que tienes un label llamado lblBienvenido
                lblBienvenido.Text = $"Bienvenido, {usuario.NombreCompleto}";

                // Si es médico, mostrar información adicional o configurar la interfaz específicamente
                if (usuario.Rol.Equals("médico", StringComparison.OrdinalIgnoreCase))
                {
                    this.Text = $"EMR Santa Clotilde - Panel Médico: {usuario.Especialidad}";
                    // Habilitar funciones específicas para médicos
                    // btnFuncionMedica.Visible = true;
                }
                else
                {
                    this.Text = $"EMR Santa Clotilde - {usuario.Rol}";
                    // Configurar para otros roles
                }
            }
        }

        private async void CargarAgendaDelDia()
        {
            try
            {
                // Cargar solo citas del médico si es un usuario médico
                var usuario = SesionUsuario.Instance.UsuarioActual;
                if (usuario != null && usuario.Rol.Equals("médico", StringComparison.OrdinalIgnoreCase))
                {
                    // Cargar solo citas del médico actual
                    var citasMedico = await _citaService.ObtenerPorMedicoAsync(usuario.Id, DateTime.Today);
                    MostrarCitasEnLista(citasMedico.ToList());
                }
                else
                {
                    // Para otros roles, cargar todas las citas del día
                    var todasCitas = await _citaService.ObtenerPorFechaAsync(DateTime.Today);
                    MostrarCitasEnLista(todasCitas.ToList());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar agenda: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarCitasEnLista(List<Cita> citas)
        {
            lstAgenda.Items.Clear();
            foreach (var cita in citas)
            {
                var hora = cita.FechaHora.ToString("hh:mm tt");
                var paciente = cita.Paciente?.Nombres ?? "Paciente no disponible";
                var detalle = cita.Motivo ?? cita.Tipo;

                var item = new ListViewItem(new[] { hora, paciente, detalle });
                item.Tag = cita.Id;
                lstAgenda.Items.Add(item);
            }
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            Pacientes pacientes = new Pacientes(_pacienteService);

            pacientes.Show();
            this.Hide(); 
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
            Resultados resultados = new Resultados(_resultadoService);

            resultados.Show();
            this.Hide();
        }
    }
}
