namespace BestBurger
{
    partial class Form1
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNomeProduto = new System.Windows.Forms.Label();
            this.lblPreco = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.txtNomeProduto = new System.Windows.Forms.TextBox();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnPedidos = new System.Windows.Forms.Button();
            this.dvgProdutos = new System.Windows.Forms.DataGridView();
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.SuspendLayout();

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 240, 232);
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Best Burger - Gerenciamento de Produtos";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(112, 45, 25);
            this.lblTitulo.Location = new System.Drawing.Point(30, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(380, 50);
            this.lblTitulo.Text = "BEST BURGER";

            // lblNomeProduto
            this.lblNomeProduto.AutoSize = true;
            this.lblNomeProduto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNomeProduto.Location = new System.Drawing.Point(35, 110);
            this.lblNomeProduto.Name = "lblNomeProduto";
            this.lblNomeProduto.Text = "Nome do produto";

            // txtNomeProduto
            this.txtNomeProduto.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtNomeProduto.Location = new System.Drawing.Point(35, 140);
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.Size = new System.Drawing.Size(350, 32);

            // lblPreco
            this.lblPreco.AutoSize = true;
            this.lblPreco.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPreco.Location = new System.Drawing.Point(415, 110);
            this.lblPreco.Name = "lblPreco";
            this.lblPreco.Text = "Preço";

            // txtPreco
            this.txtPreco.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPreco.Location = new System.Drawing.Point(415, 140);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(180, 32);

            // lblCategoria
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCategoria.Location = new System.Drawing.Point(625, 110);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Text = "Categoria";

            // cmbCategoria
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(625, 140);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(330, 33);

            // btnCadastrar
            this.btnCadastrar.BackColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.btnCadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastrar.FlatAppearance.BorderSize = 0;
            this.btnCadastrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCadastrar.ForeColor = System.Drawing.Color.White;
            this.btnCadastrar.Location = new System.Drawing.Point(35, 205);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(160, 45);
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = false;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);

            // btnAtualizar
            this.btnAtualizar.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizar.FlatAppearance.BorderSize = 0;
            this.btnAtualizar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAtualizar.ForeColor = System.Drawing.Color.White;
            this.btnAtualizar.Location = new System.Drawing.Point(210, 205);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(160, 45);
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);

            // btnExcluir
            this.btnExcluir.BackColor = System.Drawing.Color.FromArgb(198, 40, 40);
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.FlatAppearance.BorderSize = 0;
            this.btnExcluir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExcluir.ForeColor = System.Drawing.Color.White;
            this.btnExcluir.Location = new System.Drawing.Point(385, 205);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(160, 45);
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);

            // btnLimpar
            this.btnLimpar.BackColor = System.Drawing.Color.FromArgb(117, 117, 117);
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.FlatAppearance.BorderSize = 0;
            this.btnLimpar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLimpar.ForeColor = System.Drawing.Color.White;
            this.btnLimpar.Location = new System.Drawing.Point(560, 205);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(160, 45);
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);

            // btnPedidos
            this.btnPedidos.BackColor = System.Drawing.Color.FromArgb(112, 45, 25);
            this.btnPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPedidos.FlatAppearance.BorderSize = 0;
            this.btnPedidos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPedidos.ForeColor = System.Drawing.Color.White;
            this.btnPedidos.Location = new System.Drawing.Point(795, 205);
            this.btnPedidos.Name = "btnPedidos";
            this.btnPedidos.Size = new System.Drawing.Size(160, 45);
            this.btnPedidos.Text = "Ver pedidos";
            this.btnPedidos.UseVisualStyleBackColor = false;
            this.btnPedidos.Click += new System.EventHandler(this.btnPedidos_Click);

            // dvgProdutos
            this.dvgProdutos.BackgroundColor = System.Drawing.Color.White;
            this.dvgProdutos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dvgProdutos.ColumnHeadersHeight = 40;
            this.dvgProdutos.EnableHeadersVisualStyles = false;
            this.dvgProdutos.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(112, 45, 25);
            this.dvgProdutos.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dvgProdutos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dvgProdutos.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dvgProdutos.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 224, 178);
            this.dvgProdutos.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dvgProdutos.Location = new System.Drawing.Point(35, 290);
            this.dvgProdutos.Name = "dvgProdutos";
            this.dvgProdutos.ReadOnly = true;
            this.dvgProdutos.RowHeadersVisible = false;
            this.dvgProdutos.RowTemplate.Height = 35;
            this.dvgProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgProdutos.MultiSelect = false;
            this.dvgProdutos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgProdutos.Size = new System.Drawing.Size(920, 320);

            // Adicionando controles
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblNomeProduto);
            this.Controls.Add(this.txtNomeProduto);
            this.Controls.Add(this.lblPreco);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnPedidos);
            this.Controls.Add(this.dvgProdutos);

            ((System.ComponentModel.ISupportInitialize)(this.dvgProdutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNomeProduto;
        private System.Windows.Forms.Label lblPreco;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.TextBox txtNomeProduto;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnPedidos;
        private System.Windows.Forms.DataGridView dvgProdutos;
    }
}