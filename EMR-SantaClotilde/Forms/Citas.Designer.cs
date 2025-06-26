namespace EMR_SantaClotilde
{
    partial class Citas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnModificar = new Button();
            btnBuscar = new Button();
            rtbObservaciones = new RichTextBox();
            lblObservaciones = new Label();
            dtFecha = new DateTimePicker();
            lblMotivo = new Label();
            lblFecha = new Label();
            cmbTipo = new ComboBox();
            lblTipo = new Label();
            cmbEstado = new ComboBox();
            lblEstado = new Label();
            cmbMedico = new ComboBox();
            lblMedico = new Label();
            cmbPaciente = new ComboBox();
            panel1 = new Panel();
            lblResultados = new Label();
            pictureBox1 = new PictureBox();
            pcbInicio = new PictureBox();
            lblPacientes = new Label();
            lblInicio = new Label();
            pcbPacientes = new PictureBox();
            dgvCitas = new DataGridView();
            btnAgregar = new Button();
            lblConsultaId = new Label();
            lblTitulo = new Label();
            cmbMotivo = new ComboBox();
            richMotivo = new RichTextBox();
            label2 = new Label();
            pictureBox3 = new PictureBox();
            btnEliminar = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbInicio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbPacientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCitas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Ebrima", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(718, 159);
            label1.Name = "label1";
            label1.Size = new Size(194, 23);
            label1.TabIndex = 64;
            label1.Text = "Listado de citas médicas";
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.LightSeaGreen;
            btnModificar.FlatAppearance.BorderColor = Color.Teal;
            btnModificar.FlatAppearance.BorderSize = 0;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnModificar.ForeColor = Color.White;
            btnModificar.Location = new Point(291, 559);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(106, 60);
            btnModificar.TabIndex = 63;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.PaleTurquoise;
            btnBuscar.FlatAppearance.BorderColor = Color.Teal;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBuscar.ForeColor = SystemColors.ControlText;
            btnBuscar.Location = new Point(173, 559);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(106, 60);
            btnBuscar.TabIndex = 62;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // rtbObservaciones
            // 
            rtbObservaciones.Location = new Point(291, 423);
            rtbObservaciones.Margin = new Padding(3, 4, 3, 4);
            rtbObservaciones.Name = "rtbObservaciones";
            rtbObservaciones.Size = new Size(163, 108);
            rtbObservaciones.TabIndex = 61;
            rtbObservaciones.Text = "";
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblObservaciones.ForeColor = Color.CadetBlue;
            lblObservaciones.Location = new Point(291, 393);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(124, 23);
            lblObservaciones.TabIndex = 60;
            lblObservaciones.Text = "Observaciones";
            // 
            // dtFecha
            // 
            dtFecha.Location = new Point(47, 343);
            dtFecha.Margin = new Padding(3, 4, 3, 4);
            dtFecha.Name = "dtFecha";
            dtFecha.Size = new Size(163, 27);
            dtFecha.TabIndex = 56;
            // 
            // lblMotivo
            // 
            lblMotivo.AutoSize = true;
            lblMotivo.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblMotivo.ForeColor = Color.CadetBlue;
            lblMotivo.Location = new Point(291, 159);
            lblMotivo.Name = "lblMotivo";
            lblMotivo.Size = new Size(67, 23);
            lblMotivo.TabIndex = 55;
            lblMotivo.Text = "Motivo";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblFecha.ForeColor = Color.CadetBlue;
            lblFecha.Location = new Point(47, 313);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(55, 23);
            lblFecha.TabIndex = 54;
            lblFecha.Text = "Fecha";
            // 
            // cmbTipo
            // 
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(47, 501);
            cmbTipo.Margin = new Padding(3, 4, 3, 4);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(163, 28);
            cmbTipo.TabIndex = 53;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblTipo.ForeColor = Color.CadetBlue;
            lblTipo.Location = new Point(47, 472);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(46, 23);
            lblTipo.TabIndex = 52;
            lblTipo.Text = "Tipo";
            // 
            // cmbEstado
            // 
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(47, 421);
            cmbEstado.Margin = new Padding(3, 4, 3, 4);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(163, 28);
            cmbEstado.TabIndex = 51;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblEstado.ForeColor = Color.CadetBlue;
            lblEstado.Location = new Point(47, 392);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(63, 23);
            lblEstado.TabIndex = 50;
            lblEstado.Text = "Estado";
            // 
            // cmbMedico
            // 
            cmbMedico.FormattingEnabled = true;
            cmbMedico.Location = new Point(47, 265);
            cmbMedico.Margin = new Padding(3, 4, 3, 4);
            cmbMedico.Name = "cmbMedico";
            cmbMedico.Size = new Size(163, 28);
            cmbMedico.TabIndex = 49;
            // 
            // lblMedico
            // 
            lblMedico.AutoSize = true;
            lblMedico.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblMedico.ForeColor = Color.CadetBlue;
            lblMedico.Location = new Point(47, 236);
            lblMedico.Name = "lblMedico";
            lblMedico.Size = new Size(69, 23);
            lblMedico.TabIndex = 48;
            lblMedico.Text = "Medico";
            // 
            // cmbPaciente
            // 
            cmbPaciente.FormattingEnabled = true;
            cmbPaciente.Location = new Point(47, 188);
            cmbPaciente.Margin = new Padding(3, 4, 3, 4);
            cmbPaciente.Name = "cmbPaciente";
            cmbPaciente.Size = new Size(163, 28);
            cmbPaciente.TabIndex = 46;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lblResultados);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(pcbInicio);
            panel1.Controls.Add(lblPacientes);
            panel1.Controls.Add(lblInicio);
            panel1.Controls.Add(pcbPacientes);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1126, 69);
            panel1.TabIndex = 44;
            // 
            // lblResultados
            // 
            lblResultados.AutoSize = true;
            lblResultados.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblResultados.ForeColor = Color.CadetBlue;
            lblResultados.Location = new Point(718, 28);
            lblResultados.Name = "lblResultados";
            lblResultados.Size = new Size(96, 23);
            lblResultados.TabIndex = 15;
            lblResultados.Text = "Resultados";
            lblResultados.Click += lblResultados_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.resultado;
            pictureBox1.Location = new Point(674, 15);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(37, 44);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
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
            // dgvCitas
            // 
            dgvCitas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCitas.Location = new Point(587, 188);
            dgvCitas.Name = "dgvCitas";
            dgvCitas.RowHeadersWidth = 51;
            dgvCitas.Size = new Size(479, 343);
            dgvCitas.TabIndex = 43;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.DarkCyan;
            btnAgregar.FlatAppearance.BorderColor = Color.Teal;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(47, 559);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(106, 60);
            btnAgregar.TabIndex = 42;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // lblConsultaId
            // 
            lblConsultaId.AutoSize = true;
            lblConsultaId.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblConsultaId.ForeColor = Color.CadetBlue;
            lblConsultaId.Location = new Point(47, 159);
            lblConsultaId.Name = "lblConsultaId";
            lblConsultaId.Size = new Size(77, 23);
            lblConsultaId.TabIndex = 40;
            lblConsultaId.Text = "Paciente";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.Teal;
            lblTitulo.Location = new Point(490, 92);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(141, 28);
            lblTitulo.TabIndex = 39;
            lblTitulo.Text = "Citas médicas";
            // 
            // cmbMotivo
            // 
            cmbMotivo.FormattingEnabled = true;
            cmbMotivo.Location = new Point(291, 188);
            cmbMotivo.Margin = new Padding(3, 4, 3, 4);
            cmbMotivo.Name = "cmbMotivo";
            cmbMotivo.Size = new Size(163, 28);
            cmbMotivo.TabIndex = 65;
            // 
            // richMotivo
            // 
            richMotivo.Location = new Point(291, 265);
            richMotivo.Margin = new Padding(3, 4, 3, 4);
            richMotivo.Name = "richMotivo";
            richMotivo.Size = new Size(163, 108);
            richMotivo.TabIndex = 67;
            richMotivo.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            label2.ForeColor = Color.CadetBlue;
            label2.Location = new Point(291, 236);
            label2.Name = "label2";
            label2.Size = new Size(147, 23);
            label2.TabIndex = 66;
            label2.Text = "Adicional motivo";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.citas;
            pictureBox3.Location = new Point(191, 92);
            pictureBox3.Margin = new Padding(3, 4, 3, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(65, 57);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 68;
            pictureBox3.TabStop = false;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.IndianRed;
            btnEliminar.FlatAppearance.BorderColor = Color.Teal;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(418, 559);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(106, 60);
            btnEliminar.TabIndex = 69;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // Citas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1126, 711);
            Controls.Add(btnEliminar);
            Controls.Add(pictureBox3);
            Controls.Add(richMotivo);
            Controls.Add(label2);
            Controls.Add(cmbMotivo);
            Controls.Add(label1);
            Controls.Add(btnModificar);
            Controls.Add(btnBuscar);
            Controls.Add(rtbObservaciones);
            Controls.Add(lblObservaciones);
            Controls.Add(dtFecha);
            Controls.Add(lblMotivo);
            Controls.Add(lblFecha);
            Controls.Add(cmbTipo);
            Controls.Add(lblTipo);
            Controls.Add(cmbEstado);
            Controls.Add(lblEstado);
            Controls.Add(cmbMedico);
            Controls.Add(lblMedico);
            Controls.Add(cmbPaciente);
            Controls.Add(panel1);
            Controls.Add(dgvCitas);
            Controls.Add(btnAgregar);
            Controls.Add(lblConsultaId);
            Controls.Add(lblTitulo);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Citas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Citas_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbInicio).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbPacientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCitas).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnModificar;
        private Button btnBuscar;
        private RichTextBox rtbObservaciones;
        private Label lblObservaciones;
        private DateTimePicker dtFecha;
        private Label lblMotivo;
        private Label lblFecha;
        private ComboBox cmbTipo;
        private Label lblTipo;
        private ComboBox cmbEstado;
        private Label lblEstado;
        private ComboBox cmbMedico;
        private Label lblMedico;
        private ComboBox cmbPaciente;
        private Panel panel1;
        private Label lblResultados;
        private PictureBox pictureBox1;
        private PictureBox pcbInicio;
        private Label lblPacientes;
        private Label lblInicio;
        private PictureBox pcbPacientes;
        private DataGridView dgvCitas;
        private Button btnAgregar;
        private Label lblConsultaId;
        private Label lblTitulo;
        private ComboBox cmbMotivo;
        private RichTextBox richMotivo;
        private Label label2;
        private PictureBox pictureBox3;
        private Button btnEliminar;
    }
}