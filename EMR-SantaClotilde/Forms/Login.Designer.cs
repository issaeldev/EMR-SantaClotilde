namespace EMR_SantaClotilde
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            lbl_ingreso = new Label();
            pct_empleadoid = new PictureBox();
            txtUsuario = new TextBox();
            txtPwd = new TextBox();
            lblUsuario = new Label();
            lblPwd = new Label();
            btnLogin = new Button();
            ((System.ComponentModel.ISupportInitialize)pct_empleadoid).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.CadetBlue;
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(427, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(273, 338);
            panel1.TabIndex = 0;
            // 
            // lbl_ingreso
            // 
            lbl_ingreso.AutoSize = true;
            lbl_ingreso.Font = new Font("Ebrima", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_ingreso.ForeColor = Color.CadetBlue;
            lbl_ingreso.Location = new Point(163, 22);
            lbl_ingreso.Name = "lbl_ingreso";
            lbl_ingreso.Size = new Size(91, 30);
            lbl_ingreso.TabIndex = 1;
            lbl_ingreso.Text = "Ingreso";
            // 
            // pct_empleadoid
            // 
            pct_empleadoid.BackColor = Color.White;
            pct_empleadoid.Image = Properties.Resources.Id_Card_79;
            pct_empleadoid.Location = new Point(163, 52);
            pct_empleadoid.Margin = new Padding(3, 2, 3, 2);
            pct_empleadoid.Name = "pct_empleadoid";
            pct_empleadoid.Size = new Size(94, 47);
            pct_empleadoid.SizeMode = PictureBoxSizeMode.Zoom;
            pct_empleadoid.TabIndex = 2;
            pct_empleadoid.TabStop = false;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(124, 150);
            txtUsuario.Margin = new Padding(3, 2, 3, 2);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PlaceholderText = "ej: pepito";
            txtUsuario.Size = new Size(177, 23);
            txtUsuario.TabIndex = 3;
            // 
            // txtPwd
            // 
            txtPwd.Location = new Point(124, 225);
            txtPwd.Margin = new Padding(3, 2, 3, 2);
            txtPwd.Name = "txtPwd";
            txtPwd.PasswordChar = '*';
            txtPwd.PlaceholderText = "ej: yu2rhje";
            txtPwd.Size = new Size(177, 23);
            txtPwd.TabIndex = 4;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.BackColor = Color.White;
            lblUsuario.Font = new Font("Ebrima", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuario.ForeColor = Color.CadetBlue;
            lblUsuario.Location = new Point(124, 117);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(60, 19);
            lblUsuario.TabIndex = 5;
            lblUsuario.Text = "Usuario";
            // 
            // lblPwd
            // 
            lblPwd.AutoSize = true;
            lblPwd.Font = new Font("Ebrima", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPwd.ForeColor = Color.CadetBlue;
            lblPwd.Location = new Point(125, 202);
            lblPwd.Name = "lblPwd";
            lblPwd.Size = new Size(84, 19);
            lblPwd.TabIndex = 6;
            lblPwd.Text = "Contraseña";
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Ebrima", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.CadetBlue;
            btnLogin.Location = new Point(163, 274);
            btnLogin.Margin = new Padding(3, 2, 3, 2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(103, 29);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(700, 338);
            Controls.Add(btnLogin);
            Controls.Add(lblPwd);
            Controls.Add(lblUsuario);
            Controls.Add(txtPwd);
            Controls.Add(txtUsuario);
            Controls.Add(pct_empleadoid);
            Controls.Add(lbl_ingreso);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pct_empleadoid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lbl_ingreso;
        private PictureBox pct_empleadoid;
        private TextBox txtUsuario;
        private TextBox txtPwd;
        private Label lblUsuario;
        private Label lblPwd;
        private Button btnLogin;
    }
}
