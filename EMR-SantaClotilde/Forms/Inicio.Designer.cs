namespace EMR_SantaClotilde
{
    partial class Inicio
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
            lstAgenda = new ListView();
            clmHora = new ColumnHeader();
            clmPaciente = new ColumnHeader();
            clmDetalle = new ColumnHeader();
            panel1 = new Panel();
            BtnResultados = new Button();
            BtnCitas = new Button();
            btnPacientes = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            lblBienvenido = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // lstAgenda
            // 
            lstAgenda.Columns.AddRange(new ColumnHeader[] { clmHora, clmPaciente, clmDetalle });
            lstAgenda.Font = new Font("Ebrima", 9F);
            lstAgenda.FullRowSelect = true;
            lstAgenda.Location = new Point(287, 141);
            lstAgenda.Margin = new Padding(3, 2, 3, 2);
            lstAgenda.Name = "lstAgenda";
            lstAgenda.Size = new Size(364, 128);
            lstAgenda.TabIndex = 4;
            lstAgenda.UseCompatibleStateImageBehavior = false;
            lstAgenda.View = View.Details;
            // 
            // clmHora
            // 
            clmHora.Text = "Hora";
            clmHora.Width = 90;
            // 
            // clmPaciente
            // 
            clmPaciente.Text = "Paciente";
            clmPaciente.Width = 90;
            // 
            // clmDetalle
            // 
            clmDetalle.Text = "Detalle";
            clmDetalle.Width = 180;
            // 
            // panel1
            // 
            panel1.BackColor = Color.CadetBlue;
            panel1.Controls.Add(BtnResultados);
            panel1.Controls.Add(BtnCitas);
            panel1.Controls.Add(btnPacientes);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(234, 338);
            panel1.TabIndex = 0;
            // 
            // BtnResultados
            // 
            BtnResultados.Font = new Font("Ebrima", 11.25F, FontStyle.Bold);
            BtnResultados.Location = new Point(29, 209);
            BtnResultados.Name = "BtnResultados";
            BtnResultados.Size = new Size(162, 43);
            BtnResultados.TabIndex = 3;
            BtnResultados.Text = "RESULTADOS";
            BtnResultados.UseVisualStyleBackColor = true;
            BtnResultados.Click += BtnResultados_Click;
            // 
            // BtnCitas
            // 
            BtnCitas.Font = new Font("Ebrima", 11.25F, FontStyle.Bold);
            BtnCitas.Location = new Point(29, 126);
            BtnCitas.Name = "BtnCitas";
            BtnCitas.Size = new Size(162, 43);
            BtnCitas.TabIndex = 2;
            BtnCitas.Text = "CITAS";
            BtnCitas.UseVisualStyleBackColor = true;
            BtnCitas.Click += BtnCitas_Click;
            // 
            // btnPacientes
            // 
            btnPacientes.Font = new Font("Ebrima", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPacientes.ForeColor = SystemColors.ControlText;
            btnPacientes.Location = new Point(29, 45);
            btnPacientes.Margin = new Padding(3, 2, 3, 2);
            btnPacientes.Name = "btnPacientes";
            btnPacientes.Size = new Size(162, 44);
            btnPacientes.TabIndex = 1;
            btnPacientes.Text = "PACIENTES";
            btnPacientes.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.user_128;
            pictureBox1.Location = new Point(620, 9);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(62, 44);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.user_128;
            pictureBox2.Location = new Point(648, 9);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(42, 34);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // lblBienvenido
            // 
            lblBienvenido.AutoSize = true;
            lblBienvenido.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBienvenido.ForeColor = Color.CadetBlue;
            lblBienvenido.Location = new Point(373, 56);
            lblBienvenido.Name = "lblBienvenido";
            lblBienvenido.Size = new Size(105, 21);
            lblBienvenido.TabIndex = 2;
            lblBienvenido.Text = "Bienvenido, ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Ebrima", 10F);
            label1.Location = new Point(441, 109);
            label1.Name = "label1";
            label1.Size = new Size(46, 19);
            label1.TabIndex = 3;
            label1.Text = "Tu dia";
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(700, 338);
            Controls.Add(lstAgenda);
            Controls.Add(label1);
            Controls.Add(lblBienvenido);
            Controls.Add(pictureBox2);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Inicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Button btnPacientes;
        private PictureBox pictureBox2;
        private Label lblBienvenido;
        private Label label1;
        private ListView lstAgenda;
        private ColumnHeader clmHora;
        private ColumnHeader clmPaciente;
        private ColumnHeader clmDetalle;
        private Button BtnResultados;
        private Button BtnCitas;
    }
}

