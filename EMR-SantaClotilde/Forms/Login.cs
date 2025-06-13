using EMR_SantaClotilde.Services;

namespace EMR_SantaClotilde
{
    public partial class Login : Form
    {
        private readonly ICitaService _citaService;

        public Login(ICitaService citaService)
        {
            _citaService = citaService;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio(_citaService);

            inicio.Show();
            this.Hide();
        }
    }
}
