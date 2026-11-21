namespace BestBurger
{
    partial class FrmPedidos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.btnImportar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.SuspendLayout();

            // FrmPedidos
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 240, 232);
            this.ClientSize = new System.Drawing.Size(1000, 620);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmPedidos";
            this.Text = "Best Burger - Pedidos";

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(112, 45, 25);
            this.lblTitulo.Location = new System.Drawing.Point(35, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(350, 54);
            this.lblTitulo.Text = "BEST BURGER";

            // lblSubtitulo
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(100, 85, 70);
            this.lblSubtitulo.Location = new System.Drawing.Point(40, 85);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(250, 28);
            this.lblSubtitulo.Text = "Gerenciamento de pedidos";

            // dgvPedidos
            this.dgvPedidos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPedidos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPedidos.ColumnHeadersHeight = 45;
            this.dgvPedidos.EnableHeadersVisualStyles = false;
            this.dgvPedidos.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(112, 45, 25);
            this.dgvPedidos.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;
            this.dgvPedidos.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvPedidos.DefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 10F);
            this.dgvPedidos.DefaultCellStyle.SelectionBackColor =
                System.Drawing.Color.FromArgb(255, 224, 178);
            this.dgvPedidos.DefaultCellStyle.SelectionForeColor =
                System.Drawing.Color.Black;
            this.dgvPedidos.RowTemplate.Height = 38;
            this.dgvPedidos.RowHeadersVisible = false;
            this.dgvPedidos.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidos.MultiSelect = false;
            this.dgvPedidos.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPedidos.Location = new System.Drawing.Point(40, 145);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.ReadOnly = true;
            this.dgvPedidos.Size = new System.Drawing.Size(920, 330);

            // btnVoltar
            this.btnVoltar.BackColor = System.Drawing.Color.FromArgb(117, 117, 117);
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.FlatAppearance.BorderSize = 0;
            this.btnVoltar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnVoltar.ForeColor = System.Drawing.Color.White;
            this.btnVoltar.Location = new System.Drawing.Point(40, 510);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(200, 55);
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.button1_Click);

            // btnImportar
            this.btnImportar.BackColor = System.Drawing.Color.FromArgb(112, 45, 25);
            this.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportar.FlatAppearance.BorderSize = 0;
            this.btnImportar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnImportar.ForeColor = System.Drawing.Color.White;
            this.btnImportar.Location = new System.Drawing.Point(760, 510);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(200, 55);
            this.btnImportar.Text = "Importar pedidos";
            this.btnImportar.UseVisualStyleBackColor = false;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);

            // Adicionando controles
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.dgvPedidos);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnImportar);

            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
    }
}