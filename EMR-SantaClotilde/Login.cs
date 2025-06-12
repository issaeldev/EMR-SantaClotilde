namespace EMR_SantaClotilde
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio();

            inicio.Show();
            this.Hide();
        }
    }
}
