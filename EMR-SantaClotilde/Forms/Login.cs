using EMR_SantaClotilde.Services;

namespace EMR_SantaClotilde
{
    public partial class Login : Form
    {
        private readonly ICitaService _citaService;
        private readonly IUsuarioService _usuarioService;

        public Login(ICitaService citaService, IUsuarioService usuarioService)
        {
            _citaService = citaService;
            _usuarioService = usuarioService;
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            // Deshabilitar botón durante login
            btnLogin.Enabled = false;

            try
            {
                string username = txtUsuario.Text.Trim();
                string password = txtPwd.Text;

                // Validación básica
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Por favor ingrese usuario y contraseña",
                        "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Autenticación
                var resultado = await _usuarioService.AutenticarUsuario(username, password);

                if (resultado.Success)
                {
                    // Guardar el usuario en la sesión
                    SesionUsuario.Instance.IniciarSesion(resultado.User);

                    // Verificar si es médico
                    bool esMedico = _usuarioService.EsMedico(resultado.User);

                    if (esMedico)
                    {
                        // Abrir formulario para médicos
                        Inicio inicioMedico = new Inicio(_citaService);
                        inicioMedico.Show();

                        MessageBox.Show($"Bienvenido Dr. {resultado.User.NombreCompleto}\n" +
                                       $"Especialidad: {resultado.User.Especialidad}",
                                       "Acceso médico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Abrir formulario para otros roles (admin, recepcionista, etc.)
                        MessageBox.Show($"Bienvenido {resultado.User.NombreCompleto}\n" +
                                       $"Rol: {resultado.User.Rol}",
                                       "Acceso sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Determina el formulario a mostrar según el rol
                        switch (resultado.User.Rol.ToLower())
                        {
                            case "administrador":
                                // FormularioAdmin admin = new FormularioAdmin(_servicios);
                                // admin.Show();
                                break;

                            case "recepcionista":
                                // FormularioRecepcion recepcion = new FormularioRecepcion(_servicios);
                                // recepcion.Show();
                                break;

                            default:
                                Inicio inicioGeneral = new Inicio(_citaService);
                                inicioGeneral.Show();
                                break;
                        }
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show(resultado.ErrorMessage,
                        "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante la autenticación: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }
    }
}
