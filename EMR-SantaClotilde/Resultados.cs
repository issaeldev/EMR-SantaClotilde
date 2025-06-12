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

        private void btnLeer_Click(object sender, EventArgs e)
        {
            // Lógica de interfaz al hacer clic en Leer (a implementar luego)
            MessageBox.Show("Leer resultados...");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Lógica de interfaz al hacer clic en Actualizar (a implementar luego)
            MessageBox.Show("Actualizar resultado...");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Lógica de interfaz al hacer clic en Eliminar (a implementar luego)
            MessageBox.Show("Eliminar resultado...");
        }
        private void btnResultados_Click(object sender, EventArgs e)
        {
            Resultados resultados = new Resultados();
            resultados.Show();
            this.Hide(); // Si deseas ocultar el formulario actual
        }
    }
}
