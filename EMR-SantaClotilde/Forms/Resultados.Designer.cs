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
            btnActualizar = new Button();
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
            lblTitulo.Location = new Point(425, 58);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(161, 21);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Resultados médicos";
            // 
            // lblConsultaId
            // 
            lblConsultaId.AutoSize = true;
            lblConsultaId.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblConsultaId.ForeColor = Color.CadetBlue;
            lblConsultaId.Location = new Point(37, 108);
            lblConsultaId.Name = "lblConsultaId";
            lblConsultaId.Size = new Size(66, 19);
            lblConsultaId.TabIndex = 1;
            lblConsultaId.Text = "Paciente";
            // 
            // lblDiagnostico
            // 
            lblDiagnostico.AutoSize = true;
            lblDiagnostico.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblDiagnostico.ForeColor = Color.CadetBlue;
            lblDiagnostico.Location = new Point(37, 165);
            lblDiagnostico.Name = "lblDiagnostico";
            lblDiagnostico.Size = new Size(35, 19);
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
            btnAgregar.Location = new Point(37, 464);
            btnAgregar.Margin = new Padding(3, 2, 3, 2);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(93, 45);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dgvResultados
            // 
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Location = new Point(444, 130);
            dgvResultados.Margin = new Padding(3, 2, 3, 2);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.RowHeadersWidth = 51;
            dgvResultados.RowTemplate.Height = 29;
            dgvResultados.Size = new Size(485, 359);
            dgvResultados.TabIndex = 9;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.resultado;
            pictureBox2.Location = new Point(173, 58);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(46, 34);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // cmbPaciente
            // 
            cmbPaciente.FormattingEnabled = true;
            cmbPaciente.Location = new Point(37, 130);
            cmbPaciente.Name = "cmbPaciente";
            cmbPaciente.Size = new Size(143, 23);
            cmbPaciente.TabIndex = 18;
            // 
            // cmbCita
            // 
            cmbCita.FormattingEnabled = true;
            cmbCita.Location = new Point(37, 187);
            cmbCita.Name = "cmbCita";
            cmbCita.Size = new Size(143, 23);
            cmbCita.TabIndex = 19;
            // 
            // cmbMedico
            // 
            cmbMedico.FormattingEnabled = true;
            cmbMedico.Location = new Point(37, 246);
            cmbMedico.Name = "cmbMedico";
            cmbMedico.Size = new Size(143, 23);
            cmbMedico.TabIndex = 21;
            // 
            // lblMedico
            // 
            lblMedico.AutoSize = true;
            lblMedico.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblMedico.ForeColor = Color.CadetBlue;
            lblMedico.Location = new Point(37, 224);
            lblMedico.Name = "lblMedico";
            lblMedico.Size = new Size(59, 19);
            lblMedico.TabIndex = 20;
            lblMedico.Text = "Medico";
            // 
            // cmbTipoExamen
            // 
            cmbTipoExamen.FormattingEnabled = true;
            cmbTipoExamen.Location = new Point(37, 305);
            cmbTipoExamen.Name = "cmbTipoExamen";
            cmbTipoExamen.Size = new Size(143, 23);
            cmbTipoExamen.TabIndex = 23;
            // 
            // lblTipoExamen
            // 
            lblTipoExamen.AutoSize = true;
            lblTipoExamen.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblTipoExamen.ForeColor = Color.CadetBlue;
            lblTipoExamen.Location = new Point(37, 283);
            lblTipoExamen.Name = "lblTipoExamen";
            lblTipoExamen.Size = new Size(117, 19);
            lblTipoExamen.TabIndex = 22;
            lblTipoExamen.Text = "Tipo de examen";
            // 
            // cmbNombreExamen
            // 
            cmbNombreExamen.FormattingEnabled = true;
            cmbNombreExamen.Location = new Point(37, 365);
            cmbNombreExamen.Name = "cmbNombreExamen";
            cmbNombreExamen.Size = new Size(143, 23);
            cmbNombreExamen.TabIndex = 25;
            // 
            // lblNombreExamen
            // 
            lblNombreExamen.AutoSize = true;
            lblNombreExamen.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblNombreExamen.ForeColor = Color.CadetBlue;
            lblNombreExamen.Location = new Point(37, 343);
            lblNombreExamen.Name = "lblNombreExamen";
            lblNombreExamen.Size = new Size(143, 19);
            lblNombreExamen.TabIndex = 24;
            lblNombreExamen.Text = "Nombre de examen";
            // 
            // lblFechaSolicitud
            // 
            lblFechaSolicitud.AutoSize = true;
            lblFechaSolicitud.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblFechaSolicitud.ForeColor = Color.CadetBlue;
            lblFechaSolicitud.Location = new Point(205, 108);
            lblFechaSolicitud.Name = "lblFechaSolicitud";
            lblFechaSolicitud.Size = new Size(128, 19);
            lblFechaSolicitud.TabIndex = 26;
            lblFechaSolicitud.Text = "Fecha de solicitud";
            // 
            // lblFechaResultado
            // 
            lblFechaResultado.AutoSize = true;
            lblFechaResultado.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblFechaResultado.ForeColor = Color.CadetBlue;
            lblFechaResultado.Location = new Point(205, 169);
            lblFechaResultado.Name = "lblFechaResultado";
            lblFechaResultado.Size = new Size(135, 19);
            lblFechaResultado.TabIndex = 28;
            lblFechaResultado.Text = "Fecha de resultado";
            // 
            // dtFechaSolicitud
            // 
            dtFechaSolicitud.Location = new Point(205, 130);
            dtFechaSolicitud.Name = "dtFechaSolicitud";
            dtFechaSolicitud.Size = new Size(143, 23);
            dtFechaSolicitud.TabIndex = 30;
            // 
            // dtFechaResultado
            // 
            dtFechaResultado.Location = new Point(205, 188);
            dtFechaResultado.Name = "dtFechaResultado";
            dtFechaResultado.Size = new Size(143, 23);
            dtFechaResultado.TabIndex = 31;
            // 
            // cmbUnidadMedida
            // 
            cmbUnidadMedida.FormattingEnabled = true;
            cmbUnidadMedida.Location = new Point(205, 365);
            cmbUnidadMedida.Name = "cmbUnidadMedida";
            cmbUnidadMedida.Size = new Size(143, 23);
            cmbUnidadMedida.TabIndex = 33;
            // 
            // lblUnidadMedida
            // 
            lblUnidadMedida.AutoSize = true;
            lblUnidadMedida.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblUnidadMedida.ForeColor = Color.CadetBlue;
            lblUnidadMedida.Location = new Point(205, 343);
            lblUnidadMedida.Name = "lblUnidadMedida";
            lblUnidadMedida.Size = new Size(112, 19);
            lblUnidadMedida.TabIndex = 32;
            lblUnidadMedida.Text = "Unidad medida";
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblResultado.ForeColor = Color.CadetBlue;
            lblResultado.Location = new Point(205, 224);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(75, 19);
            lblResultado.TabIndex = 34;
            lblResultado.Text = "Resultado";
            // 
            // rtbResultado
            // 
            rtbResultado.Location = new Point(205, 246);
            rtbResultado.Name = "rtbResultado";
            rtbResultado.Size = new Size(143, 82);
            rtbResultado.TabIndex = 35;
            rtbResultado.Text = "";
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.PaleTurquoise;
            btnActualizar.FlatAppearance.BorderColor = Color.Teal;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizar.ForeColor = SystemColors.ControlText;
            btnActualizar.Location = new Point(145, 464);
            btnActualizar.Margin = new Padding(3, 2, 3, 2);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(93, 45);
            btnActualizar.TabIndex = 36;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.LightSeaGreen;
            btnModificar.FlatAppearance.BorderColor = Color.Teal;
            btnModificar.FlatAppearance.BorderSize = 0;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnModificar.ForeColor = Color.White;
            btnModificar.Location = new Point(255, 464);
            btnModificar.Margin = new Padding(3, 2, 3, 2);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(93, 45);
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
            lblListaResultadosMedicos.Location = new Point(601, 108);
            lblListaResultadosMedicos.Name = "lblListaResultadosMedicos";
            lblListaResultadosMedicos.Size = new Size(187, 17);
            lblListaResultadosMedicos.TabIndex = 38;
            lblListaResultadosMedicos.Text = "Listado de resultados médicos";
            // 
            // pcbPacientes
            // 
            pcbPacientes.Image = Properties.Resources.paciente;
            pcbPacientes.Location = new Point(448, 11);
            pcbPacientes.Name = "pcbPacientes";
            pcbPacientes.Size = new Size(32, 33);
            pcbPacientes.SizeMode = PictureBoxSizeMode.Zoom;
            pcbPacientes.TabIndex = 5;
            pcbPacientes.TabStop = false;
            // 
            // lblInicio
            // 
            lblInicio.AutoSize = true;
            lblInicio.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblInicio.ForeColor = Color.CadetBlue;
            lblInicio.Location = new Point(354, 21);
            lblInicio.Name = "lblInicio";
            lblInicio.Size = new Size(45, 19);
            lblInicio.TabIndex = 11;
            lblInicio.Text = "Inicio";
            lblInicio.Click += lblInicio_Click;
            // 
            // lblPacientes
            // 
            lblPacientes.AutoSize = true;
            lblPacientes.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblPacientes.ForeColor = Color.CadetBlue;
            lblPacientes.Location = new Point(486, 21);
            lblPacientes.Name = "lblPacientes";
            lblPacientes.Size = new Size(72, 19);
            lblPacientes.TabIndex = 12;
            lblPacientes.Text = "Pacientes";
            lblPacientes.Click += lblPacientes_Click;
            // 
            // pcbInicio
            // 
            pcbInicio.Image = Properties.Resources.home;
            pcbInicio.Location = new Point(316, 11);
            pcbInicio.Name = "pcbInicio";
            pcbInicio.Size = new Size(32, 33);
            pcbInicio.SizeMode = PictureBoxSizeMode.Zoom;
            pcbInicio.TabIndex = 13;
            pcbInicio.TabStop = false;
            // 
            // lblCitas
            // 
            lblCitas.AutoSize = true;
            lblCitas.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblCitas.ForeColor = Color.CadetBlue;
            lblCitas.Location = new Point(628, 21);
            lblCitas.Name = "lblCitas";
            lblCitas.Size = new Size(41, 19);
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
            panel1.Name = "panel1";
            panel1.Size = new Size(970, 52);
            panel1.TabIndex = 10;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.citas;
            pictureBox3.Location = new Point(590, 8);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(41, 41);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 69;
            pictureBox3.TabStop = false;
            // 
            // lblArchivoAdjunto
            // 
            lblArchivoAdjunto.AutoSize = true;
            lblArchivoAdjunto.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblArchivoAdjunto.ForeColor = Color.CadetBlue;
            lblArchivoAdjunto.Location = new Point(37, 401);
            lblArchivoAdjunto.Name = "lblArchivoAdjunto";
            lblArchivoAdjunto.Size = new Size(116, 19);
            lblArchivoAdjunto.TabIndex = 39;
            lblArchivoAdjunto.Text = "Archivo adjunto";
            // 
            // Resultados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(970, 527);
            Controls.Add(lblArchivoAdjunto);
            Controls.Add(lblListaResultadosMedicos);
            Controls.Add(btnModificar);
            Controls.Add(btnActualizar);
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
            Margin = new Padding(3, 2, 3, 2);
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
        private Button btnActualizar;
        private Button btnModificar;
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
