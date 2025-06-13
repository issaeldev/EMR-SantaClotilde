using EMR_SantaClotilde.Services;
using System;
using System.Windows.Forms;

namespace EMR_SantaClotilde
{
    public partial class Resultados : Form
    {
        private readonly ICitaService _citaService;
        public Resultados(ICitaService citaService)
        {
            _citaService = citaService;
            InitializeComponent();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Agregar resultado...");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Buscando resultado...");
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Modificando resultado...");
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
