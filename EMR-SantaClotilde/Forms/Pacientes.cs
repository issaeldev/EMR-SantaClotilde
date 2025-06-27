using EMR_SantaClotilde.Models;
using EMR_SantaClotilde.Services;
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
        private readonly ICitaService _citaService;
        private readonly IPacienteService _pacienteService;
        public Pacientes(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;

            InitializeComponent();
            this.Load += Pacientes_Load;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var paciente = new Paciente
            {
                Dni = txtDNI.Text,
                Nombres = txtNombre.Text,
                Apellidos = txtApellido.Text,
                FechaNacimiento = DateOnly.FromDateTime(dtFechaNacimiento.Value),
                Genero = cmbGenero.Text,
                Direccion = txtDireccion.Text, // si no tienes campo, puedes dejarlo vacío o agregar uno
                Telefono = txtTelefono.Text,
                Alergias = txtAlergias.Text,
                Antecedentes = txtAntecedentes.Text
            };

            var resultado = _pacienteService.CrearPaciente(paciente);

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
        private void btnModificar_Click(object sender, EventArgs e)
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
            pacienteSeleccionado.Telefono = txtTelefono.Text;
            pacienteSeleccionado.Alergias = txtAlergias.Text;
            pacienteSeleccionado.Antecedentes = txtAntecedentes.Text;

            var resultado = _pacienteService.ActualizarPaciente(pacienteSeleccionado);

            if (resultado.Exito)
            {
                MessageBox.Show("Paciente actualizado correctamente.");
                CargarPacientes();
            }
            else
            {
                MessageBox.Show("Error: " + resultado.Mensaje);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.CurrentRow?.DataBoundItem is not Paciente pacienteSeleccionado)
            {
                MessageBox.Show("Seleccione un paciente para eliminar.");
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro de eliminar este paciente?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                var resultado = _pacienteService.EliminarPaciente(pacienteSeleccionado.Id);
                if (resultado.Exito)
                {
                    MessageBox.Show("Paciente eliminado correctamente.");
                    CargarPacientes();
                }
                else
                {
                    MessageBox.Show("Error: " + resultado.Mensaje);
                }
            }
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
                txtTelefono.Text = paciente.Telefono;
                txtAlergias.Text = paciente.Alergias;
                txtAntecedentes.Text = paciente.Antecedentes;
            }
        }


        private void Pacientes_Load(object sender, EventArgs e)
        {
            CargarPacientes();
            dgvPacientes.SelectionChanged += dgvPacientes_SelectionChanged;
        }

        private void CargarPacientes()
        {
            var pacientes = _pacienteService.ObtenerTodos();
            dgvPacientes.DataSource = pacientes;
        }

        private void lblPacientes_Click_1(object sender, EventArgs e)
        {
            Pacientes paciente = new Pacientes(_pacienteService); // Reinicia el formulario actual si deseas
            paciente.Show();
            this.Hide();
        }

        private void lblCitas_Click(object sender, EventArgs e)
        {
            Citas citas = new Citas(_citaService);
            citas.Show();
            this.Hide();
        }
        private void lblInicio_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio(_citaService);
            inicio.Show();
            this.Hide();
        }

        private void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
