using System;
using System.Windows.Forms;

namespace EMR_SantaClotilde
{
    public partial class Resultados : Form
    {
        public Resultados()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            // Lógica de interfaz al hacer clic en Crear (a implementar luego)
            MessageBox.Show("Crear resultado...");
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Actualizar resultado...");
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Modificar resultado...");
        }

        private void btnResultados_Click(object sender, EventArgs e)
        {
            Resultados resultados = new Resultados();
            resultados.Show();
            this.Hide();
        }

        private void lblInicio_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio();
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
            Citas citas = new Citas();
            citas.Show();
            this.Hide();
        }


    }
}
