using EMR_SantaClotilde.Models;
using EMR_SantaClotilde.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace EMR_SantaClotilde.Forms
{
    public partial class Usuarios : Form
    {
        private readonly IUsuarioService _usuarioService;

        public Usuarios(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
            InitializeComponent();

            cmbRol.Items.Clear();
            cmbRol.Items.Add("médico");
            cmbRol.Items.Add("admin");
            cmbRol.SelectedIndex = 0; // Selecciona el primero por defecto

            this.Load += Usuario_Load;
        }

        private async void Usuario_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;
        }

        private async Task CargarUsuarios()
        {
            var usuarios = await _usuarioService.ObtenerTodosAsync();
            dgvUsuarios.DataSource = usuarios.ToList();
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow?.DataBoundItem is Usuario usuario)
            {
                txtUsername.Text = usuario.Username;
                txtPassword.Text = ""; // <--- SIEMPRE vacío
                txtNombre.Text = usuario.NombreCompleto;
                cmbRol.Text = usuario.Rol;
                txtEspecialidad.Text = usuario.Especialidad;
                chkActivo.Checked = usuario.Activo;
            }
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            var usuario = new Usuario
            {
                Username = txtUsername.Text,
                PasswordHash = txtPassword.Text,
                NombreCompleto = txtNombre.Text,
                Rol = cmbRol.Text,
                Especialidad = txtEspecialidad.Text,
                Activo = chkActivo.Checked
            };

            var resultado = await _usuarioService.CrearAsync(usuario);

            if (resultado.Exito)
            {
                MessageBox.Show("Usuario agregado correctamente.");
                CargarUsuarios();
            }
            else
            {
                MessageBox.Show("Error: " + resultado.Mensaje);
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            var criterioUsername = txtUsername.Text.Trim();
            var criterioPassword = txtPassword.Text.Trim();
            var criterioNombre = txtNombre.Text.Trim();
            var criterioRol = cmbRol.Text.Trim();
            var criterioEspecialidad = txtEspecialidad.Text.Trim();
            bool? criterioActivo = chkActivo.CheckState != CheckState.Indeterminate ? (bool?)chkActivo.Checked : null;

            var usuarios = await _usuarioService.ObtenerTodosAsync();
            var filtrados = usuarios.Where(u =>
                (string.IsNullOrWhiteSpace(criterioUsername) || u.Username.Contains(criterioUsername, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(criterioPassword) || u.PasswordHash.Contains(criterioPassword, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(criterioNombre) || u.NombreCompleto.Contains(criterioNombre, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(criterioRol) || u.Rol.Contains(criterioRol, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(criterioEspecialidad) || u.Especialidad.Contains(criterioEspecialidad, StringComparison.OrdinalIgnoreCase)) &&
                (!criterioActivo.HasValue || u.Activo == criterioActivo.Value)
            ).ToList();

            dgvUsuarios.DataSource = filtrados;
        }

        private async void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar los campos
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtNombre.Text = "";
            cmbRol.SelectedIndex = 0; // O puedes poner cmbRol.Text = "";
            txtEspecialidad.Text = "";
            chkActivo.CheckState = CheckState.Indeterminate; // O Unchecked si prefieres
                                                             // Si tienes un campo de búsqueda general, también límpialo:
                                                             // txtBuscar.Text = "";

            // Recarga la lista completa de usuarios
            await CargarUsuarios();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow?.DataBoundItem is not Usuario usuarioSeleccionado)
            {
                MessageBox.Show("Seleccione un usuario para eliminar.");
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro de eliminar este usuario?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                var resultado = await _usuarioService.EliminarAsync(usuarioSeleccionado.Id);
                if (resultado.Exito)
                {
                    MessageBox.Show("Usuario eliminado correctamente.");
                    
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show("Error: " + resultado.Mensaje);
                }
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow?.DataBoundItem is not Usuario usuarioSeleccionado)
            {
                MessageBox.Show("Seleccione un usuario para modificar.");
                return;
            }

            usuarioSeleccionado.Username = txtUsername.Text;
            usuarioSeleccionado.NombreCompleto = txtNombre.Text;
            usuarioSeleccionado.Rol = cmbRol.Text;
            usuarioSeleccionado.Especialidad = txtEspecialidad.Text;
            usuarioSeleccionado.Activo = chkActivo.Checked;

            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                usuarioSeleccionado.PasswordHash = txtPassword.Text; // El servicio lo hasheará
            }
            else
            {
                usuarioSeleccionado.PasswordHash = null; // O simplemente no lo cambies
            }

            var resultado = await _usuarioService.ActualizarAsync(usuarioSeleccionado);

            if (resultado.Exito)
            {
                MessageBox.Show("Usuario actualizado correctamente.");
                await CargarUsuarios();
            }
            else
            {
                MessageBox.Show("Error: " + resultado.Mensaje);
            }
        }
    }
}
