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
            lblTitulo.Font = new Font("Ebrima", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = Color.Teal;
            lblTitulo.Location = new Point(270, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(210, 40);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Resultados Médicos";

            // 
            // lblConsultaId
            // 
            lblConsultaId.AutoSize = true;
            lblConsultaId.Font = new Font("Ebrima", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblConsultaId.Location = new Point(50, 90);
            lblConsultaId.Name = "lblConsultaId";
            lblConsultaId.Size = new Size(102, 23);
            lblConsultaId.TabIndex = 1;
            lblConsultaId.Text = "ID Consulta:";

            // 
            // lblDiagnostico
            // 
            lblDiagnostico.AutoSize = true;
            lblDiagnostico.Font = new Font("Ebrima", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblDiagnostico.Location = new Point(50, 140);
            lblDiagnostico.Name = "lblDiagnostico";
            lblDiagnostico.Size = new Size(103, 23);
            lblDiagnostico.TabIndex = 2;
            lblDiagnostico.Text = "Diagnóstico:";

            // 
            // txtConsultaId
            // 
            txtConsultaId.Location = new Point(180, 90);
            txtConsultaId.Name = "txtConsultaId";
            txtConsultaId.Size = new Size(200, 27);
            txtConsultaId.TabIndex = 3;

            // 
            // txtDiagnostico
            // 
            txtDiagnostico.Location = new Point(180, 140);
            txtDiagnostico.Name = "txtDiagnostico";
            txtDiagnostico.Size = new Size(500, 27);
            txtDiagnostico.TabIndex = 4;

            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(50, 200);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(94, 29);
            btnCrear.TabIndex = 5;
            btnCrear.Text = "Crear";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;

            // 
            // btnLeer
            // 
            btnLeer.Location = new Point(160, 200);
            btnLeer.Name = "btnLeer";
            btnLeer.Size = new Size(94, 29);
            btnLeer.TabIndex = 6;
            btnLeer.Text = "Leer";
            btnLeer.UseVisualStyleBackColor = true;
            btnLeer.Click += btnLeer_Click;

            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(270, 200);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(94, 29);
            btnActualizar.TabIndex = 7;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;

            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(380, 200);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;

            // 
            // dgvResultados
            // 
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Location = new Point(50, 250);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.RowHeadersWidth = 51;
            dgvResultados.RowTemplate.Height = 29;
            dgvResultados.Size = new Size(630, 180);
            dgvResultados.TabIndex = 9;

            // 
            // Resultados
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(750, 450);
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
