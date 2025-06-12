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
            btnIngresar = new Button();
            ((System.ComponentModel.ISupportInitialize)pct_empleadoid).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.CadetBlue;
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(488, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(312, 450);
            panel1.TabIndex = 0;
            // 
            // lbl_ingreso
            // 
            lbl_ingreso.AutoSize = true;
            lbl_ingreso.Font = new Font("Ebrima", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_ingreso.ForeColor = Color.CadetBlue;
            lbl_ingreso.Location = new Point(186, 29);
            lbl_ingreso.Name = "lbl_ingreso";
            lbl_ingreso.Size = new Size(115, 38);
            lbl_ingreso.TabIndex = 1;
            lbl_ingreso.Text = "Ingreso";
            lbl_ingreso.Click += lbl_login_Click;
            // 
            // pct_empleadoid
            // 
            pct_empleadoid.BackColor = Color.White;
            pct_empleadoid.Image = Properties.Resources.Id_Card_79;
            pct_empleadoid.Location = new Point(186, 70);
            pct_empleadoid.Name = "pct_empleadoid";
            pct_empleadoid.Size = new Size(107, 63);
            pct_empleadoid.SizeMode = PictureBoxSizeMode.Zoom;
            pct_empleadoid.TabIndex = 2;
            pct_empleadoid.TabStop = false;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(142, 209);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PlaceholderText = "ej: pepito";
            txtUsuario.Size = new Size(202, 27);
            txtUsuario.TabIndex = 3;
            // 
            // txtPwd
            // 
            txtPwd.Location = new Point(142, 309);
            txtPwd.Name = "txtPwd";
            txtPwd.PlaceholderText = "ej: yu2rhje";
            txtPwd.Size = new Size(202, 27);
            txtPwd.TabIndex = 4;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.BackColor = Color.White;
            lblUsuario.Font = new Font("Ebrima", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuario.ForeColor = Color.CadetBlue;
            lblUsuario.Location = new Point(142, 166);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(70, 23);
            lblUsuario.TabIndex = 5;
            lblUsuario.Text = "Usuario";
            // 
            // lblPwd
            // 
            lblPwd.AutoSize = true;
            lblPwd.Font = new Font("Ebrima", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPwd.ForeColor = Color.CadetBlue;
            lblPwd.Location = new Point(143, 279);
            lblPwd.Name = "lblPwd";
            lblPwd.Size = new Size(99, 23);
            lblPwd.TabIndex = 6;
            lblPwd.Text = "Contraseña";
            // 
            // btnIngresar
            // 
            btnIngresar.Font = new Font("Ebrima", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIngresar.ForeColor = Color.CadetBlue;
            btnIngresar.Location = new Point(186, 365);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(118, 39);
            btnIngresar.TabIndex = 7;
            btnIngresar.Text = "LOGIN";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(btnIngresar);
            Controls.Add(lblPwd);
            Controls.Add(lblUsuario);
            Controls.Add(txtPwd);
            Controls.Add(txtUsuario);
            Controls.Add(pct_empleadoid);
            Controls.Add(lbl_ingreso);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
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
        private Button btnIngresar;
    }
}
