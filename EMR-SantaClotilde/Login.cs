namespace EMR_SantaClotilde
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void lbl_login_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {


			// Crear una nueva instancia del segundo formulario
			Inicio inicio = new Inicio();

			// Mostrar el segundo formulario
			inicio.Show();  // Muestra el formulario sin cerrar el formulario actual

			// Si quieres abrir el formulario y cerrar el actual:
			inicio.Show();
			this.Hide();  // Oculta el formulario actual
		}
	}
}
