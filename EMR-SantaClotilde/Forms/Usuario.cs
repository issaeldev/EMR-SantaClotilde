using EMR_SantaClotilde.Models;
using EMR_SantaClotilde.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace EMR_SantaClotilde.Forms
{
    public partial class Usuario : Form
    {
        private readonly IUsuarioService _usuarioService;

        public Usuario(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
            InitializeComponent();
            this.Load += Usuario_Load;
        }

        private async void Usuario_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;
        }

        private async void CargarUsuarios()
        {
            var usuarios = await _usuarioService.ObtenerTodosAsync();
            dgvUsuarios.DataSource = usuarios.ToList();
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow?.DataBoundItem is Usuarios usuario)
            {
                txtUsername.Text = usuario.Username;
                txtPassword.Text = usuario.PasswordHash;
                txtNombre.Text = usuario.NombreCompleto;
                cmbRol.Text = usuario.Rol;
                txtEspecialidad.Text = usuario.Especialidad;
                chkActivo.Checked = usuario.Activo;
            }
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            var usuario = new Usuarios
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

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow?.DataBoundItem is not Usuarios usuarioSeleccionado)
            {
                MessageBox.Show("Seleccione un usuario para modificar.");
                return;
            }

            usuarioSeleccionado.Username = txtUsername.Text;
            usuarioSeleccionado.PasswordHash = txtPassword.Text;
            usuarioSeleccionado.NombreCompleto = txtNombre.Text;
            usuarioSeleccionado.Rol = cmbRol.Text;
            usuarioSeleccionado.Especialidad = txtEspecialidad.Text;
            usuarioSeleccionado.Activo = chkActivo.Checked;

            var resultado = await _usuarioService.ActualizarAsync(usuarioSeleccionado);

            if (resultado.Exito)
            {
                MessageBox.Show("Usuario actualizado correctamente.");
                CargarUsuarios();
            }
            else
            {
                MessageBox.Show("Error: " + resultado.Mensaje);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow?.DataBoundItem is not Usuarios usuarioSeleccionado)
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
    }
}
