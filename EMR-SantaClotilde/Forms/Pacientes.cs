using EMR_SantaClotilde.Models;
using EMR_SantaClotilde.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMR_SantaClotilde.Forms
{
    public partial class Pacientes : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IPacienteService _pacienteService;
        public Pacientes(IPacienteService pacienteService, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _pacienteService = pacienteService;

            InitializeComponent();

            cmbGenero.Items.Clear();
            cmbGenero.Items.Add("M");
            cmbGenero.Items.Add("F");
            cmbGenero.Items.Add("PND");
            cmbGenero.SelectedIndex = 0; // Selecciona el primero por defecto

            this.Load += Pacientes_Load;
        }
        private void dgvPacientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPacientes.CurrentRow?.DataBoundItem is Paciente paciente)
            {
                txtDNI.Text = paciente.Dni;
                txtNombre.Text = paciente.Nombres;
                txtApellido.Text = paciente.Apellidos;
                dtFechaNacimiento.Value = paciente.FechaNacimiento.ToDateTime(TimeOnly.MinValue);
                cmbGenero.Text = paciente.Genero;
                txtDireccion.Text = paciente.Direccion;
                txtTelefono.Text = paciente.Telefono;
                txtAlergias.Text = paciente.Alergias;
                txtAntecedentes.Text = paciente.Antecedentes;
                chkActivo.Checked = paciente.Activo;
            }
        }


        private void Pacientes_Load(object sender, EventArgs e)
        {
            CargarPacientes();
            dgvPacientes.SelectionChanged += dgvPacientes_SelectionChanged;
        }

        private async Task CargarPacientes()
        {
            if (dgvPacientes == null)
            {
                MessageBox.Show("Error: dgvPacientes es null");
                return;
            }
            if (_pacienteService == null)
            {
                MessageBox.Show("Error: _pacienteService es null");
                return;
            }

            var pacientes = await _pacienteService.ObtenerTodosAsync();
            if (pacientes == null)
            {
                MessageBox.Show("Error: pacientes es null");
                pacientes = new List<Paciente>();
            }
            dgvPacientes.DataSource = pacientes;
        }

        private void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblInicio_Click(object sender, EventArgs e)
        {
            var inicio = _serviceProvider.GetRequiredService<Inicio>();
            inicio.Show();
            this.Hide();
        }

        private void lblPacientes_Click_1(object sender, EventArgs e)
        {
            var pacientes = _serviceProvider.GetRequiredService<Pacientes>();
            pacientes.Show();
            this.Hide();
        }
        private void lblCitas_Click(object sender, EventArgs e)
        {
            var citas = _serviceProvider.GetRequiredService<Citas>();
            citas.Show();
            this.Hide();
        }
        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            var paciente = new Paciente
            {
                Dni = txtDNI.Text,
                Nombres = txtNombre.Text,
                Apellidos = txtApellido.Text,
                FechaNacimiento = DateOnly.FromDateTime(dtFechaNacimiento.Value),
                Genero = cmbGenero.Text,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
                Alergias = txtAlergias.Text,
                Antecedentes = txtAntecedentes.Text
            };

            var resultado = await _pacienteService.CrearPacienteAsync(paciente);

            if (resultado.Exito)
            {
                MessageBox.Show("Paciente agregado correctamente.");
                CargarPacientes();
            }
            else
            {
                MessageBox.Show("Error: " + resultado.Mensaje);
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            var criterioDni = txtDNI.Text.Trim();
            var criterioNombre = txtNombre.Text.Trim();
            var criterioApellido = txtApellido.Text.Trim();
            var criterioGenero = cmbGenero.Text.Trim();
            var criterioTelefono = txtTelefono.Text.Trim();
            var criterioAlergias = txtAlergias.Text.Trim();
            var criterioAntecedentes = txtAntecedentes.Text.Trim();
            bool? criterioActivo = chkActivo.CheckState != CheckState.Indeterminate ? (bool?)chkActivo.Checked : null;

            var pacientes = await _pacienteService.ObtenerTodosAsync();
            var filtrados = pacientes.Where(p =>
                (string.IsNullOrWhiteSpace(criterioDni) || p.Dni.Contains(criterioDni, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(criterioNombre) || p.Nombres.Contains(criterioNombre, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(criterioApellido) || p.Apellidos.Contains(criterioApellido, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(criterioGenero) || p.Genero.Contains(criterioGenero, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(criterioTelefono) || (p.Telefono != null && p.Telefono.Contains(criterioTelefono, StringComparison.OrdinalIgnoreCase))) &&
                (string.IsNullOrWhiteSpace(criterioAlergias) || (p.Alergias != null && p.Alergias.Contains(criterioAlergias, StringComparison.OrdinalIgnoreCase))) &&
                (string.IsNullOrWhiteSpace(criterioAntecedentes) || (p.Antecedentes != null && p.Antecedentes.Contains(criterioAntecedentes, StringComparison.OrdinalIgnoreCase))) &&
                (!criterioActivo.HasValue || p.Activo == criterioActivo.Value)
            ).ToList();

            dgvPacientes.DataSource = filtrados;
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.CurrentRow?.DataBoundItem is not Paciente pacienteSeleccionado)
            {
                MessageBox.Show("Seleccione un paciente para modificar.");
                return;
            }

            pacienteSeleccionado.Dni = txtDNI.Text;
            pacienteSeleccionado.Nombres = txtNombre.Text;
            pacienteSeleccionado.Apellidos = txtApellido.Text;
            pacienteSeleccionado.FechaNacimiento = DateOnly.FromDateTime(dtFechaNacimiento.Value);
            pacienteSeleccionado.Genero = cmbGenero.Text;
            pacienteSeleccionado.Direccion = txtDireccion.Text;
            pacienteSeleccionado.Telefono = txtTelefono.Text;
            pacienteSeleccionado.Alergias = txtAlergias.Text;
            pacienteSeleccionado.Antecedentes = txtAntecedentes.Text;
            pacienteSeleccionado.Activo = chkActivo.Checked;

            var resultado = await _pacienteService.ActualizarPacienteAsync(pacienteSeleccionado);

            if (resultado.Exito)
            {
                MessageBox.Show("Paciente actualizado correctamente.");
                await CargarPacientes();
            }
            else
            {
                MessageBox.Show("Error: " + resultado.Mensaje);
            }
        }

        private async void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar los campos de búsqueda de pacientes
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            dtFechaNacimiento.Value = DateTime.Today;
            cmbGenero.SelectedIndex = 0;
            txtTelefono.Text = "";
            txtAlergias.Text = "";
            txtAntecedentes.Text = "";
            chkActivo.CheckState = CheckState.Indeterminate;

            // Recarga la lista completa de pacientes
            await CargarPacientes();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.CurrentRow?.DataBoundItem is not Paciente pacienteSeleccionado)
            {
                MessageBox.Show("Seleccione un paciente para eliminar.");
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro de eliminar este paciente?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                var resultado = await _pacienteService.EliminarPacienteAsync(pacienteSeleccionado.Id);
                if (resultado.Exito)
                {
                    MessageBox.Show("Paciente eliminado correctamente.");
                    await CargarPacientes();
                }
                else
                {
                    MessageBox.Show("Error: " + resultado.Mensaje);
                }
            }
        }
    }
}
