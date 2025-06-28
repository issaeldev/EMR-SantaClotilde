namespace EMR_SantaClotilde.Forms
{
    partial class Usuarios
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
            btnLimpiar = new Button();
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
            txtEspecialidad.Location = new Point(258, 224);
            txtEspecialidad.Margin = new Padding(3, 2, 3, 2);
            txtEspecialidad.Name = "txtEspecialidad";
            txtEspecialidad.Size = new Size(143, 23);
            txtEspecialidad.TabIndex = 100;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(57, 287);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(143, 23);
            txtPassword.TabIndex = 98;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(57, 228);
            txtUsername.Margin = new Padding(3, 2, 3, 2);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(143, 23);
            txtUsername.TabIndex = 97;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(57, 166);
            txtNombre.Margin = new Padding(3, 2, 3, 2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(143, 23);
            txtNombre.TabIndex = 96;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.IndianRed;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(385, 391);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(93, 45);
            btnEliminar.TabIndex = 94;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // lblListaResultadosMedicos
            // 
            lblListaResultadosMedicos.AutoSize = true;
            lblListaResultadosMedicos.Font = new Font("Ebrima", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblListaResultadosMedicos.ForeColor = Color.Teal;
            lblListaResultadosMedicos.Location = new Point(650, 112);
            lblListaResultadosMedicos.Name = "lblListaResultadosMedicos";
            lblListaResultadosMedicos.Size = new Size(122, 17);
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
            btnModificar.Location = new Point(275, 391);
            btnModificar.Margin = new Padding(3, 2, 3, 2);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(93, 45);
            btnModificar.TabIndex = 92;
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
            btnBuscar.Location = new Point(165, 391);
            btnBuscar.Margin = new Padding(3, 2, 3, 2);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(93, 45);
            btnBuscar.TabIndex = 91;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblEspecialidad
            // 
            lblEspecialidad.AutoSize = true;
            lblEspecialidad.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblEspecialidad.ForeColor = Color.CadetBlue;
            lblEspecialidad.Location = new Point(258, 200);
            lblEspecialidad.Name = "lblEspecialidad";
            lblEspecialidad.Size = new Size(92, 19);
            lblEspecialidad.TabIndex = 87;
            lblEspecialidad.Text = "Especialidad";
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblDireccion.ForeColor = Color.CadetBlue;
            lblDireccion.Location = new Point(57, 340);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(0, 19);
            lblDireccion.TabIndex = 85;
            // 
            // cmbRol
            // 
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(258, 165);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(143, 23);
            cmbRol.TabIndex = 84;
            // 
            // lblGenero
            // 
            lblGenero.AutoSize = true;
            lblGenero.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblGenero.ForeColor = Color.CadetBlue;
            lblGenero.Location = new Point(258, 142);
            lblGenero.Name = "lblGenero";
            lblGenero.Size = new Size(31, 19);
            lblGenero.TabIndex = 83;
            lblGenero.Text = "Rol";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblPassword.ForeColor = Color.CadetBlue;
            lblPassword.Location = new Point(57, 259);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(73, 19);
            lblPassword.TabIndex = 82;
            lblPassword.Text = "Password";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.user_128;
            pictureBox2.Location = new Point(179, 80);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(46, 34);
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
            panel1.Name = "panel1";
            panel1.Size = new Size(979, 52);
            panel1.TabIndex = 80;
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
            // dgvUsuarios
            // 
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(495, 140);
            dgvUsuarios.Margin = new Padding(3, 2, 3, 2);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.Size = new Size(466, 296);
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
            btnAgregar.Location = new Point(57, 391);
            btnAgregar.Margin = new Padding(3, 2, 3, 2);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(93, 45);
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
            lblUsername.Location = new Point(57, 200);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(76, 19);
            lblUsername.TabIndex = 77;
            lblUsername.Text = "Username";
            // 
            // lbNombreId
            // 
            lbNombreId.AutoSize = true;
            lbNombreId.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lbNombreId.ForeColor = Color.CadetBlue;
            lbNombreId.Location = new Point(57, 142);
            lbNombreId.Name = "lbNombreId";
            lbNombreId.Size = new Size(65, 19);
            lbNombreId.TabIndex = 76;
            lbNombreId.Text = "Nombre";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.Teal;
            lblTitulo.Location = new Point(439, 80);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(76, 21);
            lblTitulo.TabIndex = 75;
            lblTitulo.Text = "Usuarios";
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(258, 287);
            chkActivo.Margin = new Padding(3, 2, 3, 2);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(60, 19);
            chkActivo.TabIndex = 101;
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
            btnLimpiar.Location = new Point(222, 452);
            btnLimpiar.Margin = new Padding(3, 2, 3, 2);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(96, 34);
            btnLimpiar.TabIndex = 102;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // Usuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(979, 520);
            Controls.Add(btnLimpiar);
            Controls.Add(chkActivo);
            Controls.Add(txtEspecialidad);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtNombre);
            Controls.Add(btnEliminar);
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
            Margin = new Padding(3, 2, 3, 2);
            Name = "Usuarios";
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
        private Button btnLimpiar;
    }
}