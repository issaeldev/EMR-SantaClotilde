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
            txtConsultaId = new TextBox();
            txtDiagnostico = new TextBox();
            btnCrear = new Button();
            btnLeer = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            dgvResultados = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Ebrima", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.CadetBlue;
            lblTitulo.Location = new Point(236, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(242, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Resultados Médicos";
            // 
            // lblConsultaId
            // 
            lblConsultaId.AutoSize = true;
            lblConsultaId.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblConsultaId.ForeColor = Color.CadetBlue;
            lblConsultaId.Location = new Point(44, 68);
            lblConsultaId.Name = "lblConsultaId";
            lblConsultaId.Size = new Size(88, 19);
            lblConsultaId.TabIndex = 1;
            lblConsultaId.Text = "ID Consulta:";
            // 
            // lblDiagnostico
            // 
            lblDiagnostico.AutoSize = true;
            lblDiagnostico.Font = new Font("Ebrima", 10.2F, FontStyle.Bold);
            lblDiagnostico.ForeColor = Color.CadetBlue;
            lblDiagnostico.Location = new Point(44, 105);
            lblDiagnostico.Name = "lblDiagnostico";
            lblDiagnostico.Size = new Size(92, 19);
            lblDiagnostico.TabIndex = 2;
            lblDiagnostico.Text = "Diagnóstico:";
            // 
            // txtConsultaId
            // 
            txtConsultaId.Location = new Point(158, 68);
            txtConsultaId.Margin = new Padding(3, 2, 3, 2);
            txtConsultaId.Name = "txtConsultaId";
            txtConsultaId.Size = new Size(176, 23);
            txtConsultaId.TabIndex = 3;
            // 
            // txtDiagnostico
            // 
            txtDiagnostico.Location = new Point(158, 105);
            txtDiagnostico.Margin = new Padding(3, 2, 3, 2);
            txtDiagnostico.Name = "txtDiagnostico";
            txtDiagnostico.Size = new Size(438, 23);
            txtDiagnostico.TabIndex = 4;
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(44, 150);
            btnCrear.Margin = new Padding(3, 2, 3, 2);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(82, 22);
            btnCrear.TabIndex = 5;
            btnCrear.Text = "Crear";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // btnLeer
            // 
            btnLeer.Location = new Point(140, 150);
            btnLeer.Margin = new Padding(3, 2, 3, 2);
            btnLeer.Name = "btnLeer";
            btnLeer.Size = new Size(82, 22);
            btnLeer.TabIndex = 6;
            btnLeer.Text = "Leer";
            btnLeer.UseVisualStyleBackColor = true;
            btnLeer.Click += btnLeer_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(236, 150);
            btnActualizar.Margin = new Padding(3, 2, 3, 2);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(82, 22);
            btnActualizar.TabIndex = 7;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(332, 150);
            btnEliminar.Margin = new Padding(3, 2, 3, 2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(82, 22);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvResultados
            // 
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Location = new Point(44, 188);
            dgvResultados.Margin = new Padding(3, 2, 3, 2);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.RowHeadersWidth = 51;
            dgvResultados.RowTemplate.Height = 29;
            dgvResultados.Size = new Size(551, 135);
            dgvResultados.TabIndex = 9;
            // 
            // Resultados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(656, 338);
            Controls.Add(dgvResultados);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnLeer);
            Controls.Add(btnCrear);
            Controls.Add(txtDiagnostico);
            Controls.Add(txtConsultaId);
            Controls.Add(lblDiagnostico);
            Controls.Add(lblConsultaId);
            Controls.Add(lblTitulo);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Resultados";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Resultados Médicos";
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblConsultaId;
        private Label lblDiagnostico;
        private TextBox txtConsultaId;
        private TextBox txtDiagnostico;
        private Button btnCrear;
        private Button btnLeer;
        private Button btnActualizar;
        private Button btnEliminar;
        private DataGridView dgvResultados;
    }
}
