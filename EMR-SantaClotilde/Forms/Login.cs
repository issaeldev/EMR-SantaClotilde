using EMR_SantaClotilde.Forms;
using EMR_SantaClotilde.Models;
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

            // PRUEBA
            var usuario = new Usuario
            {
                Username = "mariaadmin",
                PasswordHash = "admin123", // Solo para pruebas. No usar en producci�n sin hash.
                NombreCompleto = "Mar�a Gonz�lez",
                Rol = "admin",
                Especialidad = "Sistemas",
                Activo = true
            };

            var resultade = await _usuarioService.CrearAsync(usuario);
            if (resultade.Exito)
            {
                MessageBox.Show("Usuario agregado correctamente.");
            }
            else
            {
                string errores = resultade.Errores != null && resultade.Errores.Any()
                    ? "\n" + string.Join("\n", resultade.Errores)
                    : "";
                MessageBox.Show("Error: " + resultade.Mensaje + errores);
            }
            // PRUEBA

            // Deshabilitar bot�n durante login
            btnLogin.Enabled = false;

            try
            {
                string username = txtUsuario.Text.Trim();
                string password = txtPwd.Text;

                // Validaci�n b�sica
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Por favor ingrese usuario y contrase�a",
                        "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Autenticaci�n
                var resultado = await _usuarioService.AutenticarUsuario(username, password);

                if (resultado.Exito)
                {
                    // Guardar el usuario en la sesi�n
                    SesionUsuario.Instance.IniciarSesion(resultado.Usuario);

                    // Verificar si es m�dico
                    bool esMedico = _usuarioService.EsMedico(resultado.Usuario);

                    if (esMedico)
                    {
                        // Abrir formulario para m�dicos
                        Inicio inicioMedico = new Inicio(_citaService);
                        inicioMedico.Show();

                        MessageBox.Show($"Bienvenido Dr. {resultado.Usuario.NombreCompleto}\n" +
                                       $"Especialidad: {resultado.Usuario.Especialidad}",
                                       "Acceso m�dico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Abrir formulario para otros roles (admin, recepcionista, etc.)
                        MessageBox.Show($"Bienvenido {resultado.Usuario.NombreCompleto}\n" +
                                       $"Rol: {resultado.Usuario.Rol}",
                                       "Acceso sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Determina el formulario a mostrar seg�n el rol
                        switch (resultado.Usuario.Rol.ToLower())
                        {
                            case "admin":
                                Usuarios usuarios = new Usuarios(_usuarioService);
                                usuarios.Show();
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
                    MessageBox.Show(resultado.Mensaje,
                        "Error de autenticaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante la autenticaci�n: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }
    }
}
