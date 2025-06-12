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
        public Inicio()
        {
            InitializeComponent();
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            // Crear una nueva instancia del segundo formulario
            // Paciente pacientes = new Paciente();

            // Si quieres abrir el formulario y cerrar el actual:
            // pacientes.Show();
            // this.Hide();  // Oculta el formulario actual
        }

        private void BtnCitas_Click(object sender, EventArgs e)
        {
            // Crear una nueva instancia del segundo formulario
            // Cita citas = new Cita();

            // Si quieres abrir el formulario y cerrar el actual:
            // citas.Show();
            // this.Hide();  // Oculta el formulario actual
        }

        private void BtnResultados_Click(object sender, EventArgs e)
        {
            // Crear una nueva instancia del segundo formulario
            Resultados resultados = new Resultados();

            // Si quieres abrir el formulario y cerrar el actual:
            resultados.Show();
            this.Hide();  // Oculta el formulario actual
        }
    }
}
