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
    public partial class Citas : Form
    {
        private readonly ICitaService _citaService;
        public Citas(ICitaService citaService)
        {
            _citaService = citaService;
            InitializeComponent();
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
            pacientes.Hide();
            */
        }

        private void lblResultados_Click(object sender, EventArgs e)
        {
            Resultados resultados = new Resultados(_citaService);
            resultados.Show();
            this.Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Agregar cita...");
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Buscando cita...");
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Modificar cita...");
        }


    }
}
