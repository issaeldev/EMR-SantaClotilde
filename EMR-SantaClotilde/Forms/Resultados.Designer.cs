namespace EMR_SantaClotilde
{
    partial class Resultados
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblConsultaId = new Label();
            lblDiagnostico = new Label();
            btnAgregar = new Button();
            dgvResultados = new DataGridView();
            pictureBox2 = new PictureBox();
            cmbPaciente = new ComboBox();
            cmbCita = new ComboBox();
            cmbMedico = new ComboBox();
            lblMedico = new Label();
            cmbTipoExamen = new ComboBox();
            lblTipoExamen = new Label();
            cmbNombreExamen = new ComboBox();
            lblNombreExamen = new Label();
            lblFechaSolicitud = new Label();
            lblFechaResultado = new Label();
            dtFechaSolicitud = new DateTimePicker();
            dtFechaResultado = new DateTimePicker();
            cmbUnidadMedida = new ComboBox();
            lblUnidadMedida = new Label();
            lblResultado = new Label();
            rtbResultado = new RichTextBox();
            btnBuscar = new Button();
            btnModificar = new Button();
            lblListaResultadosMedicos = new Label();
            pcbPacientes = new PictureBox();
            lblInicio = new Label();
            lblPacientes = new Label();
            pcbInicio = new PictureBox();
            lblCitas = new Label();
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            lblArchivoAdjunto = new Label();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbPacientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbInicio).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.Teal;
            lblTitulo.Location = new Point(486, 77);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(199, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Resultados médicos";
            // 
            // lblConsultaId
            // 
            lblConsultaId.AutoSize = true;
            lblConsultaId.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblConsultaId.ForeColor = Color.CadetBlue;
            lblConsultaId.Location = new Point(42, 144);
            lblConsultaId.Name = "lblConsultaId";
            lblConsultaId.Size = new Size(77, 23);
            lblConsultaId.TabIndex = 1;
            lblConsultaId.Text = "Paciente";
            // 
            // lblDiagnostico
            // 
            lblDiagnostico.AutoSize = true;
            lblDiagnostico.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblDiagnostico.ForeColor = Color.CadetBlue;
            lblDiagnostico.Location = new Point(42, 220);
            lblDiagnostico.Name = "lblDiagnostico";
            lblDiagnostico.Size = new Size(42, 23);
            lblDiagnostico.TabIndex = 2;
            lblDiagnostico.Text = "Cita";
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.DarkCyan;
            btnAgregar.FlatAppearance.BorderColor = Color.Teal;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(42, 619);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(106, 60);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dgvResultados
            // 
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Location = new Point(555, 173);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.RowHeadersWidth = 51;
            dgvResultados.Size = new Size(506, 413);
            dgvResultados.TabIndex = 9;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.resultado;
            pictureBox2.Location = new Point(198, 77);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(53, 45);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // cmbPaciente
            // 
            cmbPaciente.FormattingEnabled = true;
            cmbPaciente.Location = new Point(42, 173);
            cmbPaciente.Margin = new Padding(3, 4, 3, 4);
            cmbPaciente.Name = "cmbPaciente";
            cmbPaciente.Size = new Size(163, 28);
            cmbPaciente.TabIndex = 18;
            // 
            // cmbCita
            // 
            cmbCita.FormattingEnabled = true;
            cmbCita.Location = new Point(42, 249);
            cmbCita.Margin = new Padding(3, 4, 3, 4);
            cmbCita.Name = "cmbCita";
            cmbCita.Size = new Size(163, 28);
            cmbCita.TabIndex = 19;
            // 
            // cmbMedico
            // 
            cmbMedico.FormattingEnabled = true;
            cmbMedico.Location = new Point(42, 328);
            cmbMedico.Margin = new Padding(3, 4, 3, 4);
            cmbMedico.Name = "cmbMedico";
            cmbMedico.Size = new Size(163, 28);
            cmbMedico.TabIndex = 21;
            // 
            // lblMedico
            // 
            lblMedico.AutoSize = true;
            lblMedico.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblMedico.ForeColor = Color.CadetBlue;
            lblMedico.Location = new Point(42, 299);
            lblMedico.Name = "lblMedico";
            lblMedico.Size = new Size(69, 23);
            lblMedico.TabIndex = 20;
            lblMedico.Text = "Medico";
            // 
            // cmbTipoExamen
            // 
            cmbTipoExamen.FormattingEnabled = true;
            cmbTipoExamen.Location = new Point(42, 407);
            cmbTipoExamen.Margin = new Padding(3, 4, 3, 4);
            cmbTipoExamen.Name = "cmbTipoExamen";
            cmbTipoExamen.Size = new Size(163, 28);
            cmbTipoExamen.TabIndex = 23;
            // 
            // lblTipoExamen
            // 
            lblTipoExamen.AutoSize = true;
            lblTipoExamen.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblTipoExamen.ForeColor = Color.CadetBlue;
            lblTipoExamen.Location = new Point(42, 377);
            lblTipoExamen.Name = "lblTipoExamen";
            lblTipoExamen.Size = new Size(138, 23);
            lblTipoExamen.TabIndex = 22;
            lblTipoExamen.Text = "Tipo de examen";
            // 
            // cmbNombreExamen
            // 
            cmbNombreExamen.FormattingEnabled = true;
            cmbNombreExamen.Location = new Point(42, 487);
            cmbNombreExamen.Margin = new Padding(3, 4, 3, 4);
            cmbNombreExamen.Name = "cmbNombreExamen";
            cmbNombreExamen.Size = new Size(163, 28);
            cmbNombreExamen.TabIndex = 25;
            // 
            // lblNombreExamen
            // 
            lblNombreExamen.AutoSize = true;
            lblNombreExamen.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblNombreExamen.ForeColor = Color.CadetBlue;
            lblNombreExamen.Location = new Point(42, 457);
            lblNombreExamen.Name = "lblNombreExamen";
            lblNombreExamen.Size = new Size(168, 23);
            lblNombreExamen.TabIndex = 24;
            lblNombreExamen.Text = "Nombre de examen";
            // 
            // lblFechaSolicitud
            // 
            lblFechaSolicitud.AutoSize = true;
            lblFechaSolicitud.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblFechaSolicitud.ForeColor = Color.CadetBlue;
            lblFechaSolicitud.Location = new Point(291, 144);
            lblFechaSolicitud.Name = "lblFechaSolicitud";
            lblFechaSolicitud.Size = new Size(153, 23);
            lblFechaSolicitud.TabIndex = 26;
            lblFechaSolicitud.Text = "Fecha de solicitud";
            // 
            // lblFechaResultado
            // 
            lblFechaResultado.AutoSize = true;
            lblFechaResultado.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblFechaResultado.ForeColor = Color.CadetBlue;
            lblFechaResultado.Location = new Point(291, 225);
            lblFechaResultado.Name = "lblFechaResultado";
            lblFechaResultado.Size = new Size(160, 23);
            lblFechaResultado.TabIndex = 28;
            lblFechaResultado.Text = "Fecha de resultado";
            // 
            // dtFechaSolicitud
            // 
            dtFechaSolicitud.Location = new Point(291, 173);
            dtFechaSolicitud.Margin = new Padding(3, 4, 3, 4);
            dtFechaSolicitud.Name = "dtFechaSolicitud";
            dtFechaSolicitud.Size = new Size(163, 27);
            dtFechaSolicitud.TabIndex = 30;
            // 
            // dtFechaResultado
            // 
            dtFechaResultado.Location = new Point(291, 251);
            dtFechaResultado.Margin = new Padding(3, 4, 3, 4);
            dtFechaResultado.Name = "dtFechaResultado";
            dtFechaResultado.Size = new Size(163, 27);
            dtFechaResultado.TabIndex = 31;
            // 
            // cmbUnidadMedida
            // 
            cmbUnidadMedida.FormattingEnabled = true;
            cmbUnidadMedida.Location = new Point(291, 487);
            cmbUnidadMedida.Margin = new Padding(3, 4, 3, 4);
            cmbUnidadMedida.Name = "cmbUnidadMedida";
            cmbUnidadMedida.Size = new Size(163, 28);
            cmbUnidadMedida.TabIndex = 33;
            // 
            // lblUnidadMedida
            // 
            lblUnidadMedida.AutoSize = true;
            lblUnidadMedida.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblUnidadMedida.ForeColor = Color.CadetBlue;
            lblUnidadMedida.Location = new Point(291, 457);
            lblUnidadMedida.Name = "lblUnidadMedida";
            lblUnidadMedida.Size = new Size(134, 23);
            lblUnidadMedida.TabIndex = 32;
            lblUnidadMedida.Text = "Unidad medida";
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblResultado.ForeColor = Color.CadetBlue;
            lblResultado.Location = new Point(291, 299);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(89, 23);
            lblResultado.TabIndex = 34;
            lblResultado.Text = "Resultado";
            // 
            // rtbResultado
            // 
            rtbResultado.Location = new Point(291, 328);
            rtbResultado.Margin = new Padding(3, 4, 3, 4);
            rtbResultado.Name = "rtbResultado";
            rtbResultado.Size = new Size(163, 108);
            rtbResultado.TabIndex = 35;
            rtbResultado.Text = "";
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.PaleTurquoise;
            btnBuscar.FlatAppearance.BorderColor = Color.Teal;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBuscar.ForeColor = SystemColors.ControlText;
            btnBuscar.Location = new Point(166, 619);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(106, 60);
            btnBuscar.TabIndex = 36;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.LightSeaGreen;
            btnModificar.FlatAppearance.BorderColor = Color.Teal;
            btnModificar.FlatAppearance.BorderSize = 0;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnModificar.ForeColor = Color.White;
            btnModificar.Location = new Point(291, 619);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(106, 60);
            btnModificar.TabIndex = 37;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // lblListaResultadosMedicos
            // 
            lblListaResultadosMedicos.AutoSize = true;
            lblListaResultadosMedicos.Font = new Font("Ebrima", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblListaResultadosMedicos.ForeColor = Color.Teal;
            lblListaResultadosMedicos.Location = new Point(687, 144);
            lblListaResultadosMedicos.Name = "lblListaResultadosMedicos";
            lblListaResultadosMedicos.Size = new Size(239, 23);
            lblListaResultadosMedicos.TabIndex = 38;
            lblListaResultadosMedicos.Text = "Listado de resultados médicos";
            // 
            // pcbPacientes
            // 
            pcbPacientes.Image = Properties.Resources.paciente;
            pcbPacientes.Location = new Point(512, 15);
            pcbPacientes.Margin = new Padding(3, 4, 3, 4);
            pcbPacientes.Name = "pcbPacientes";
            pcbPacientes.Size = new Size(37, 44);
            pcbPacientes.SizeMode = PictureBoxSizeMode.Zoom;
            pcbPacientes.TabIndex = 5;
            pcbPacientes.TabStop = false;
            // 
            // lblInicio
            // 
            lblInicio.AutoSize = true;
            lblInicio.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblInicio.ForeColor = Color.CadetBlue;
            lblInicio.Location = new Point(405, 28);
            lblInicio.Name = "lblInicio";
            lblInicio.Size = new Size(53, 23);
            lblInicio.TabIndex = 11;
            lblInicio.Text = "Inicio";
            lblInicio.Click += lblInicio_Click;
            // 
            // lblPacientes
            // 
            lblPacientes.AutoSize = true;
            lblPacientes.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblPacientes.ForeColor = Color.CadetBlue;
            lblPacientes.Location = new Point(555, 28);
            lblPacientes.Name = "lblPacientes";
            lblPacientes.Size = new Size(84, 23);
            lblPacientes.TabIndex = 12;
            lblPacientes.Text = "Pacientes";
            lblPacientes.Click += lblPacientes_Click;
            // 
            // pcbInicio
            // 
            pcbInicio.Image = Properties.Resources.home;
            pcbInicio.Location = new Point(361, 15);
            pcbInicio.Margin = new Padding(3, 4, 3, 4);
            pcbInicio.Name = "pcbInicio";
            pcbInicio.Size = new Size(37, 44);
            pcbInicio.SizeMode = PictureBoxSizeMode.Zoom;
            pcbInicio.TabIndex = 13;
            pcbInicio.TabStop = false;
            // 
            // lblCitas
            // 
            lblCitas.AutoSize = true;
            lblCitas.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblCitas.ForeColor = Color.CadetBlue;
            lblCitas.Location = new Point(718, 28);
            lblCitas.Name = "lblCitas";
            lblCitas.Size = new Size(49, 23);
            lblCitas.TabIndex = 15;
            lblCitas.Text = "Citas";
            lblCitas.Click += lblCitas_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(lblCitas);
            panel1.Controls.Add(pcbInicio);
            panel1.Controls.Add(lblPacientes);
            panel1.Controls.Add(lblInicio);
            panel1.Controls.Add(pcbPacientes);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1109, 69);
            panel1.TabIndex = 10;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.citas;
            pictureBox3.Location = new Point(674, 11);
            pictureBox3.Margin = new Padding(3, 4, 3, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(47, 55);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 69;
            pictureBox3.TabStop = false;
            // 
            // lblArchivoAdjunto
            // 
            lblArchivoAdjunto.AutoSize = true;
            lblArchivoAdjunto.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblArchivoAdjunto.ForeColor = Color.CadetBlue;
            lblArchivoAdjunto.Location = new Point(42, 535);
            lblArchivoAdjunto.Name = "lblArchivoAdjunto";
            lblArchivoAdjunto.Size = new Size(138, 23);
            lblArchivoAdjunto.TabIndex = 39;
            lblArchivoAdjunto.Text = "Archivo adjunto";
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.IndianRed;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(417, 619);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(106, 60);
            btnEliminar.TabIndex = 38;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // Resultados
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1109, 703);
            Controls.Add(btnEliminar);
            Controls.Add(lblArchivoAdjunto);
            Controls.Add(lblListaResultadosMedicos);
            Controls.Add(btnModificar);
            Controls.Add(btnBuscar);
            Controls.Add(rtbResultado);
            Controls.Add(lblResultado);
            Controls.Add(cmbUnidadMedida);
            Controls.Add(lblUnidadMedida);
            Controls.Add(dtFechaResultado);
            Controls.Add(dtFechaSolicitud);
            Controls.Add(lblFechaResultado);
            Controls.Add(lblFechaSolicitud);
            Controls.Add(cmbNombreExamen);
            Controls.Add(lblNombreExamen);
            Controls.Add(cmbTipoExamen);
            Controls.Add(lblTipoExamen);
            Controls.Add(cmbMedico);
            Controls.Add(lblMedico);
            Controls.Add(cmbCita);
            Controls.Add(cmbPaciente);
            Controls.Add(pictureBox2);
            Controls.Add(panel1);
            Controls.Add(dgvResultados);
            Controls.Add(btnAgregar);
            Controls.Add(lblDiagnostico);
            Controls.Add(lblConsultaId);
            Controls.Add(lblTitulo);
            Name = "Resultados";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Resultados Médicos";
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbPacientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbInicio).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblConsultaId;
        private Label lblDiagnostico;
        private Button btnAgregar;
        private DataGridView dgvResultados;
        private PictureBox pictureBox2;
        private ComboBox cmbPaciente;
        private ComboBox cmbCita;
        private ComboBox cmbMedico;
        private Label lblMedico;
        private ComboBox cmbTipoExamen;
        private Label lblTipoExamen;
        private ComboBox cmbNombreExamen;
        private Label lblNombreExamen;
        private Label lblFechaSolicitud;
        private Label lblFechaResultado;
        private DateTimePicker dtFechaSolicitud;
        private DateTimePicker dtFechaResultado;
        private ComboBox cmbUnidadMedida;
        private Label lblUnidadMedida;
        private Label lblResultado;
        private RichTextBox rtbResultado;
        private Button btnBuscar;
        private Button btnModificar;
        private Button btnEliminar;
        private Label lblListaResultadosMedicos;
        private PictureBox pcbPacientes;
        private Label lblInicio;
        private Label lblPacientes;
        private PictureBox pcbInicio;
        private Label lblCitas;
        private Panel panel1;
        private PictureBox pictureBox3;
        private Label lblArchivoAdjunto;
    }
}
