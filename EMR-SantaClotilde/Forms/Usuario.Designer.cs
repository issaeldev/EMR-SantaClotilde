namespace EMR_SantaClotilde.Forms
{
    partial class Usuario
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
            txtEspecialidad = new TextBox();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            txtNombre = new TextBox();
            btnEliminar = new Button();
            lblArchivoAdjunto = new Label();
            lblListaResultadosMedicos = new Label();
            btnModificar = new Button();
            btnBuscar = new Button();
            lblEspecialidad = new Label();
            lblDireccion = new Label();
            cmbRol = new ComboBox();
            lblGenero = new Label();
            lblPassword = new Label();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            lblCitas = new Label();
            pcbInicio = new PictureBox();
            lblPacientes = new Label();
            lblInicio = new Label();
            pcbPacientes = new PictureBox();
            dgvUsuarios = new DataGridView();
            btnAgregar = new Button();
            lblUsername = new Label();
            lbNombreId = new Label();
            lblTitulo = new Label();
            chkActivo = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbInicio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbPacientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // txtEspecialidad
            // 
            txtEspecialidad.Location = new Point(295, 299);
            txtEspecialidad.Name = "txtEspecialidad";
            txtEspecialidad.Size = new Size(163, 27);
            txtEspecialidad.TabIndex = 100;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(65, 383);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(163, 27);
            txtPassword.TabIndex = 98;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(65, 304);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(163, 27);
            txtUsername.TabIndex = 97;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(65, 221);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(163, 27);
            txtNombre.TabIndex = 96;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.IndianRed;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(440, 521);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(106, 60);
            btnEliminar.TabIndex = 94;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // lblArchivoAdjunto
            // 
            lblArchivoAdjunto.AutoSize = true;
            lblArchivoAdjunto.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblArchivoAdjunto.ForeColor = Color.CadetBlue;
            lblArchivoAdjunto.Location = new Point(65, 444);
            lblArchivoAdjunto.Name = "lblArchivoAdjunto";
            lblArchivoAdjunto.Size = new Size(138, 23);
            lblArchivoAdjunto.TabIndex = 95;
            lblArchivoAdjunto.Text = "Archivo adjunto";
            // 
            // lblListaResultadosMedicos
            // 
            lblListaResultadosMedicos.AutoSize = true;
            lblListaResultadosMedicos.Font = new Font("Ebrima", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblListaResultadosMedicos.ForeColor = Color.Teal;
            lblListaResultadosMedicos.Location = new Point(743, 149);
            lblListaResultadosMedicos.Name = "lblListaResultadosMedicos";
            lblListaResultadosMedicos.Size = new Size(156, 23);
            lblListaResultadosMedicos.TabIndex = 93;
            lblListaResultadosMedicos.Text = "Listado de usuarios";
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.LightSeaGreen;
            btnModificar.FlatAppearance.BorderColor = Color.Teal;
            btnModificar.FlatAppearance.BorderSize = 0;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnModificar.ForeColor = Color.White;
            btnModificar.Location = new Point(314, 521);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(106, 60);
            btnModificar.TabIndex = 92;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.PaleTurquoise;
            btnBuscar.FlatAppearance.BorderColor = Color.Teal;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBuscar.ForeColor = SystemColors.ControlText;
            btnBuscar.Location = new Point(189, 521);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(106, 60);
            btnBuscar.TabIndex = 91;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            // 
            // lblEspecialidad
            // 
            lblEspecialidad.AutoSize = true;
            lblEspecialidad.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblEspecialidad.ForeColor = Color.CadetBlue;
            lblEspecialidad.Location = new Point(295, 266);
            lblEspecialidad.Name = "lblEspecialidad";
            lblEspecialidad.Size = new Size(109, 23);
            lblEspecialidad.TabIndex = 87;
            lblEspecialidad.Text = "Especialidad";
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblDireccion.ForeColor = Color.CadetBlue;
            lblDireccion.Location = new Point(65, 454);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(0, 23);
            lblDireccion.TabIndex = 85;
            // 
            // cmbRol
            // 
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(295, 220);
            cmbRol.Margin = new Padding(3, 4, 3, 4);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(163, 28);
            cmbRol.TabIndex = 84;
            // 
            // lblGenero
            // 
            lblGenero.AutoSize = true;
            lblGenero.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblGenero.ForeColor = Color.CadetBlue;
            lblGenero.Location = new Point(295, 190);
            lblGenero.Name = "lblGenero";
            lblGenero.Size = new Size(36, 23);
            lblGenero.TabIndex = 83;
            lblGenero.Text = "Rol";
            lblGenero.Click += lblGenero_Click;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblPassword.ForeColor = Color.CadetBlue;
            lblPassword.Location = new Point(65, 345);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(85, 23);
            lblPassword.TabIndex = 82;
            lblPassword.Text = "Password";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.resultado;
            pictureBox2.Location = new Point(199, 89);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(53, 45);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 81;
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
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1119, 69);
            panel1.TabIndex = 80;
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
            // dgvUsuarios
            // 
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(566, 187);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.Size = new Size(532, 394);
            dgvUsuarios.TabIndex = 79;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.DarkCyan;
            btnAgregar.FlatAppearance.BorderColor = Color.Teal;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(65, 521);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(106, 60);
            btnAgregar.TabIndex = 78;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblUsername.ForeColor = Color.CadetBlue;
            lblUsername.Location = new Point(65, 266);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(89, 23);
            lblUsername.TabIndex = 77;
            lblUsername.Text = "Username";
            // 
            // lbNombreId
            // 
            lbNombreId.AutoSize = true;
            lbNombreId.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lbNombreId.ForeColor = Color.CadetBlue;
            lbNombreId.Location = new Point(65, 190);
            lbNombreId.Name = "lbNombreId";
            lbNombreId.Size = new Size(76, 23);
            lbNombreId.TabIndex = 76;
            lbNombreId.Text = "Nombre";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.Teal;
            lblTitulo.Location = new Point(502, 106);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(93, 28);
            lblTitulo.TabIndex = 75;
            lblTitulo.Text = "Usuarios";
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(295, 346);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(73, 24);
            chkActivo.TabIndex = 101;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // Usuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1119, 694);
            Controls.Add(chkActivo);
            Controls.Add(txtEspecialidad);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtNombre);
            Controls.Add(btnEliminar);
            Controls.Add(lblArchivoAdjunto);
            Controls.Add(lblListaResultadosMedicos);
            Controls.Add(btnModificar);
            Controls.Add(btnBuscar);
            Controls.Add(lblEspecialidad);
            Controls.Add(lblDireccion);
            Controls.Add(cmbRol);
            Controls.Add(lblGenero);
            Controls.Add(lblPassword);
            Controls.Add(pictureBox2);
            Controls.Add(panel1);
            Controls.Add(dgvUsuarios);
            Controls.Add(btnAgregar);
            Controls.Add(lblUsername);
            Controls.Add(lbNombreId);
            Controls.Add(lblTitulo);
            Name = "Usuario";
            Text = "Usuario";
            Load += Usuario_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbInicio).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbPacientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtEspecialidad;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private TextBox txtNombre;
        private Button btnEliminar;
        private Label lblArchivoAdjunto;
        private Label lblListaResultadosMedicos;
        private Button btnModificar;
        private Button btnBuscar;
        private Label lblEspecialidad;
        private Label lblDireccion;
        private ComboBox cmbRol;
        private Label lblGenero;
        private Label lblPassword;
        private PictureBox pictureBox2;
        private Panel panel1;
        private PictureBox pictureBox3;
        private Label lblCitas;
        private PictureBox pcbInicio;
        private Label lblPacientes;
        private Label lblInicio;
        private PictureBox pcbPacientes;
        private DataGridView dgvUsuarios;
        private Button btnAgregar;
        private Label lblUsername;
        private Label lbNombreId;
        private Label lblTitulo;
        private CheckBox chkActivo;
    }
}