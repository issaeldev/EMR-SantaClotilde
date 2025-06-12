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
            // Pacientes pacientes = new Pacientes();

            // pacientes.Show();
            // this.Hide(); 
        }

        private void BtnCitas_Click(object sender, EventArgs e)
        {
            // Crear una nueva instancia del segundo formulario
            Citas citas = new Citas();

            citas.Show();
            this.Hide();  
        }

        private void BtnResultados_Click(object sender, EventArgs e)
        {
            Resultados resultados = new Resultados();

            resultados.Show();
            this.Hide();
        }
    }
}
