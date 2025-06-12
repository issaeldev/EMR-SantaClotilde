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
            btnPaciente = new Button();
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
            lstAgenda.Location = new Point(303, 187);
            lstAgenda.Name = "lstAgenda";
            lstAgenda.Size = new Size(265, 155);
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
            panel1.Controls.Add(btnPaciente);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 450);
            panel1.TabIndex = 0;
            // 
            // btnPaciente
            // 
            btnPaciente.Font = new Font("Ebrima", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPaciente.Location = new Point(33, 29);
            btnPaciente.Name = "btnPaciente";
            btnPaciente.Size = new Size(185, 58);
            btnPaciente.TabIndex = 1;
            btnPaciente.Text = "PACIENTE";
            btnPaciente.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.user_128;
            pictureBox1.Location = new Point(708, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(71, 58);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.user_128;
            pictureBox2.Location = new Point(740, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(48, 45);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // lblBienvenido
            // 
            lblBienvenido.AutoSize = true;
            lblBienvenido.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBienvenido.ForeColor = Color.CadetBlue;
            lblBienvenido.Location = new Point(372, 42);
            lblBienvenido.Name = "lblBienvenido";
            lblBienvenido.Size = new Size(129, 28);
            lblBienvenido.TabIndex = 2;
            lblBienvenido.Text = "Bienvenido, ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Ebrima", 10F);
            label1.Location = new Point(400, 140);
            label1.Name = "label1";
            label1.Size = new Size(57, 23);
            label1.TabIndex = 3;
            label1.Text = "Tu dia";
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(lstAgenda);
            Controls.Add(label1);
            Controls.Add(lblBienvenido);
            Controls.Add(pictureBox2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Inicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void CargarAgendaDelDia()
		{
			// Ejemplo de datos. Reemplaza por tu fuente real.
			var citas = new List<(string hora, string paciente, string detalle)>
			{
				("10:00 AM", "Juan Pérez", "Revisión de control"),
				("11:30 AM", "Ana López", "Consulta por dolor abdominal"),
				("13:00 PM", "Carlos Ruiz", "Examen de sangre")
			};

			lstAgenda.Items.Clear();
			foreach (var cita in citas)
			{
				var item = new ListViewItem(new[] { cita.hora, cita.paciente, cita.detalle });
				item.Tag = cita; // Puedes guardar más detalles aquí si lo necesitas
				lstAgenda.Items.Add(item);
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			CargarAgendaDelDia();
		}

		#endregion

		private Panel panel1;
        private PictureBox pictureBox1;
        private Button btnPaciente;
        private PictureBox pictureBox2;
        private Label lblBienvenido;
        private Label label1;
        private ListView lstAgenda;
        private ColumnHeader clmHora;
        private ColumnHeader clmPaciente;
        private ColumnHeader clmDetalle;
    }
}

