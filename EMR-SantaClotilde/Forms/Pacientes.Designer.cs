namespace EMR_SantaClotilde.Forms
{
    partial class Pacientes
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
            btnEliminar = new Button();
            lblArchivoAdjunto = new Label();
            lblListaResultadosMedicos = new Label();
            btnModificar = new Button();
            btnBuscar = new Button();
            lblAlergias = new Label();
            lblAntecedentes = new Label();
            dtFechaNacimiento = new DateTimePicker();
            lblTelefono = new Label();
            lblFechaSolicitud = new Label();
            lblDireccion = new Label();
            cmbGenero = new ComboBox();
            lblGenero = new Label();
            lblDNI = new Label();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            lblCitas = new Label();
            pcbInicio = new PictureBox();
            lblPacientes = new Label();
            lblInicio = new Label();
            pcbPacientes = new PictureBox();
            dgvPacientes = new DataGridView();
            btnAgregar = new Button();
            lblApellido = new Label();
            lbNombreId = new Label();
            lblTitulo = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtDNI = new TextBox();
            txtDireccion = new TextBox();
            txtTelefono = new TextBox();
            txtAlergias = new TextBox();
            txtAntecedentes = new TextBox();
            chkActivo = new CheckBox();
            btnLimpiar = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbInicio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbPacientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPacientes).BeginInit();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.IndianRed;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(364, 441);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(93, 45);
            btnEliminar.TabIndex = 66;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // lblArchivoAdjunto
            // 
            lblArchivoAdjunto.AutoSize = true;
            lblArchivoAdjunto.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblArchivoAdjunto.ForeColor = Color.CadetBlue;
            lblArchivoAdjunto.Location = new Point(36, 390);
            lblArchivoAdjunto.Name = "lblArchivoAdjunto";
            lblArchivoAdjunto.Size = new Size(116, 19);
            lblArchivoAdjunto.TabIndex = 67;
            lblArchivoAdjunto.Text = "Archivo adjunto";
            // 
            // lblListaResultadosMedicos
            // 
            lblListaResultadosMedicos.AutoSize = true;
            lblListaResultadosMedicos.Font = new Font("Ebrima", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblListaResultadosMedicos.ForeColor = Color.Teal;
            lblListaResultadosMedicos.Location = new Point(648, 104);
            lblListaResultadosMedicos.Name = "lblListaResultadosMedicos";
            lblListaResultadosMedicos.Size = new Size(128, 17);
            lblListaResultadosMedicos.TabIndex = 65;
            lblListaResultadosMedicos.Text = "Listado de pacientes";
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.LightSeaGreen;
            btnModificar.FlatAppearance.BorderColor = Color.Teal;
            btnModificar.FlatAppearance.BorderSize = 0;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnModificar.ForeColor = Color.White;
            btnModificar.Location = new Point(254, 441);
            btnModificar.Margin = new Padding(3, 2, 3, 2);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(93, 45);
            btnModificar.TabIndex = 64;
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
            btnBuscar.Location = new Point(144, 441);
            btnBuscar.Margin = new Padding(3, 2, 3, 2);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(93, 45);
            btnBuscar.TabIndex = 63;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblAlergias
            // 
            lblAlergias.AutoSize = true;
            lblAlergias.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblAlergias.ForeColor = Color.CadetBlue;
            lblAlergias.Location = new Point(248, 213);
            lblAlergias.Name = "lblAlergias";
            lblAlergias.Size = new Size(64, 19);
            lblAlergias.TabIndex = 61;
            lblAlergias.Text = "Alergias";
            // 
            // lblAntecedentes
            // 
            lblAntecedentes.AutoSize = true;
            lblAntecedentes.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblAntecedentes.ForeColor = Color.CadetBlue;
            lblAntecedentes.Location = new Point(248, 272);
            lblAntecedentes.Name = "lblAntecedentes";
            lblAntecedentes.Size = new Size(99, 19);
            lblAntecedentes.TabIndex = 59;
            lblAntecedentes.Text = "Antecedentes";
            // 
            // dtFechaNacimiento
            // 
            dtFechaNacimiento.Format = DateTimePickerFormat.Custom;
            dtFechaNacimiento.Location = new Point(248, 118);
            dtFechaNacimiento.Name = "dtFechaNacimiento";
            dtFechaNacimiento.Size = new Size(143, 23);
            dtFechaNacimiento.TabIndex = 57;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblTelefono.ForeColor = Color.CadetBlue;
            lblTelefono.Location = new Point(248, 158);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(68, 19);
            lblTelefono.TabIndex = 56;
            lblTelefono.Text = "Telefono";
            // 
            // lblFechaSolicitud
            // 
            lblFechaSolicitud.AutoSize = true;
            lblFechaSolicitud.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblFechaSolicitud.ForeColor = Color.CadetBlue;
            lblFechaSolicitud.Location = new Point(248, 97);
            lblFechaSolicitud.Name = "lblFechaSolicitud";
            lblFechaSolicitud.Size = new Size(146, 19);
            lblFechaSolicitud.TabIndex = 55;
            lblFechaSolicitud.Text = "Fecha de nacimiento";
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblDireccion.ForeColor = Color.CadetBlue;
            lblDireccion.Location = new Point(36, 332);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(72, 19);
            lblDireccion.TabIndex = 53;
            lblDireccion.Text = "Direccion";
            // 
            // cmbGenero
            // 
            cmbGenero.FormattingEnabled = true;
            cmbGenero.Location = new Point(36, 294);
            cmbGenero.Name = "cmbGenero";
            cmbGenero.Size = new Size(143, 23);
            cmbGenero.TabIndex = 52;
            // 
            // lblGenero
            // 
            lblGenero.AutoSize = true;
            lblGenero.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblGenero.ForeColor = Color.CadetBlue;
            lblGenero.Location = new Point(36, 272);
            lblGenero.Name = "lblGenero";
            lblGenero.Size = new Size(58, 19);
            lblGenero.TabIndex = 51;
            lblGenero.Text = "Genero";
            // 
            // lblDNI
            // 
            lblDNI.AutoSize = true;
            lblDNI.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblDNI.ForeColor = Color.CadetBlue;
            lblDNI.Location = new Point(36, 213);
            lblDNI.Name = "lblDNI";
            lblDNI.Size = new Size(34, 19);
            lblDNI.TabIndex = 49;
            lblDNI.Text = "DNI";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.resultado;
            pictureBox2.Location = new Point(153, 58);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(46, 34);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 46;
            pictureBox2.TabStop = false;
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
            panel1.Size = new Size(988, 52);
            panel1.TabIndex = 45;
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
            lblPacientes.Click += lblPacientes_Click_1;
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
            // dgvPacientes
            // 
            dgvPacientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPacientes.Location = new Point(474, 131);
            dgvPacientes.Margin = new Padding(3, 2, 3, 2);
            dgvPacientes.Name = "dgvPacientes";
            dgvPacientes.RowHeadersWidth = 51;
            dgvPacientes.Size = new Size(466, 296);
            dgvPacientes.TabIndex = 44;
            dgvPacientes.CellContentClick += dgvPacientes_CellContentClick;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.DarkCyan;
            btnAgregar.FlatAppearance.BorderColor = Color.Teal;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(36, 441);
            btnAgregar.Margin = new Padding(3, 2, 3, 2);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(93, 45);
            btnAgregar.TabIndex = 43;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblApellido.ForeColor = Color.CadetBlue;
            lblApellido.Location = new Point(36, 154);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(66, 19);
            lblApellido.TabIndex = 42;
            lblApellido.Text = "Apellido";
            // 
            // lbNombreId
            // 
            lbNombreId.AutoSize = true;
            lbNombreId.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lbNombreId.ForeColor = Color.CadetBlue;
            lbNombreId.Location = new Point(36, 97);
            lbNombreId.Name = "lbNombreId";
            lbNombreId.Size = new Size(65, 19);
            lbNombreId.TabIndex = 41;
            lbNombreId.Text = "Nombre";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.Teal;
            lblTitulo.Location = new Point(418, 70);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(83, 21);
            lblTitulo.TabIndex = 40;
            lblTitulo.Text = "Pacientes";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(36, 120);
            txtNombre.Margin = new Padding(3, 2, 3, 2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(143, 23);
            txtNombre.TabIndex = 68;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(36, 182);
            txtApellido.Margin = new Padding(3, 2, 3, 2);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(143, 23);
            txtApellido.TabIndex = 69;
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(36, 242);
            txtDNI.Margin = new Padding(3, 2, 3, 2);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(143, 23);
            txtDNI.TabIndex = 70;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(36, 358);
            txtDireccion.Margin = new Padding(3, 2, 3, 2);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(143, 23);
            txtDireccion.TabIndex = 71;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(248, 182);
            txtTelefono.Margin = new Padding(3, 2, 3, 2);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(143, 23);
            txtTelefono.TabIndex = 72;
            // 
            // txtAlergias
            // 
            txtAlergias.Location = new Point(248, 242);
            txtAlergias.Margin = new Padding(3, 2, 3, 2);
            txtAlergias.Name = "txtAlergias";
            txtAlergias.Size = new Size(143, 23);
            txtAlergias.TabIndex = 73;
            // 
            // txtAntecedentes
            // 
            txtAntecedentes.Location = new Point(248, 295);
            txtAntecedentes.Margin = new Padding(3, 2, 3, 2);
            txtAntecedentes.Name = "txtAntecedentes";
            txtAntecedentes.Size = new Size(143, 23);
            txtAntecedentes.TabIndex = 74;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Checked = true;
            chkActivo.CheckState = CheckState.Checked;
            chkActivo.Location = new Point(254, 358);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(60, 19);
            chkActivo.TabIndex = 75;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.PaleTurquoise;
            btnLimpiar.FlatAppearance.BorderColor = Color.Teal;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnLimpiar.ForeColor = SystemColors.ControlText;
            btnLimpiar.Location = new Point(193, 495);
            btnLimpiar.Margin = new Padding(3, 2, 3, 2);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(96, 34);
            btnLimpiar.TabIndex = 103;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // Pacientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(988, 540);
            Controls.Add(btnLimpiar);
            Controls.Add(chkActivo);
            Controls.Add(txtAntecedentes);
            Controls.Add(txtAlergias);
            Controls.Add(txtTelefono);
            Controls.Add(txtDireccion);
            Controls.Add(txtDNI);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(btnEliminar);
            Controls.Add(lblArchivoAdjunto);
            Controls.Add(lblListaResultadosMedicos);
            Controls.Add(btnModificar);
            Controls.Add(btnBuscar);
            Controls.Add(lblAlergias);
            Controls.Add(lblAntecedentes);
            Controls.Add(dtFechaNacimiento);
            Controls.Add(lblTelefono);
            Controls.Add(lblFechaSolicitud);
            Controls.Add(lblDireccion);
            Controls.Add(cmbGenero);
            Controls.Add(lblGenero);
            Controls.Add(lblDNI);
            Controls.Add(pictureBox2);
            Controls.Add(panel1);
            Controls.Add(dgvPacientes);
            Controls.Add(btnAgregar);
            Controls.Add(lblApellido);
            Controls.Add(lbNombreId);
            Controls.Add(lblTitulo);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Pacientes";
            Text = "Pacientes";
            Load += Pacientes_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbInicio).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbPacientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPacientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEliminar;
        private Label lblArchivoAdjunto;
        private Label lblListaResultadosMedicos;
        private Button btnModificar;
        private Button btnBuscar;
        private Label lblAlergias;
        private Label lblAntecedentes;
        private DateTimePicker dtFechaNacimiento;
        private Label lblTelefono;
        private Label lblFechaSolicitud;
        private Label lblDireccion;
        private ComboBox cmbGenero;
        private Label lblGenero;
        private Label lblDNI;
        private PictureBox pictureBox2;
        private Panel panel1;
        private PictureBox pictureBox3;
        private Label lblCitas;
        private PictureBox pcbInicio;
        private Label lblPacientes;
        private Label lblInicio;
        private PictureBox pcbPacientes;
        private DataGridView dgvPacientes;
        private Button btnAgregar;
        private Label lblApellido;
        private Label lbNombreId;
        private Label lblTitulo;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtDNI;
        private TextBox txtDireccion;
        private TextBox txtTelefono;
        private TextBox txtAlergias;
        private TextBox txtAntecedentes;
        private CheckBox chkActivo;
        private Button btnLimpiar;
    }
}