using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using BestBurger;
#nullable disable

namespace BestBurger
{
    public partial class Form1 : Form
    {
        private int idSelecionado = 0;

        public Form1()
        {
            InitializeComponent();

            btnCadastrar.Click -= btnCadastrar_Click;
            btnCadastrar.Click += btnCadastrar_Click;

            btnAtualizar.Click -= btnAtualizar_Click;
            btnAtualizar.Click += btnAtualizar_Click;

            btnExcluir.Click -= btnExcluir_Click;
            btnExcluir.Click += btnExcluir_Click;

            btnLimpar.Click -= btnLimpar_Click;
            btnLimpar.Click += btnLimpar_Click;

            dvgProdutos.CellClick -= dvgProdutos_CellClick;
            dvgProdutos.CellClick += dvgProdutos_CellClick;

            ConfigurarTabela();
            CarregarCategorias();
            CarregarProdutos();
        }

        private void ConfigurarTabela()
        {
            dvgProdutos.ReadOnly = true;
            dvgProdutos.AllowUserToAddRows = false;
            dvgProdutos.AllowUserToDeleteRows = false;
            dvgProdutos.MultiSelect = false;
            dvgProdutos.AutoGenerateColumns = true;

            dvgProdutos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dvgProdutos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dvgProdutos.BackgroundColor = Color.White;
            dvgProdutos.BorderStyle = BorderStyle.FixedSingle;

            dvgProdutos.DefaultCellStyle.BackColor = Color.White;
            dvgProdutos.DefaultCellStyle.ForeColor = Color.Black;
            dvgProdutos.DefaultCellStyle.SelectionBackColor = Color.SaddleBrown;
            dvgProdutos.DefaultCellStyle.SelectionForeColor = Color.White;

            dvgProdutos.RowsDefaultCellStyle.BackColor = Color.White;
            dvgProdutos.RowsDefaultCellStyle.ForeColor = Color.Black;

            dvgProdutos.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 239, 230);

            dvgProdutos.AlternatingRowsDefaultCellStyle.ForeColor =
                Color.Black;

            dvgProdutos.EnableHeadersVisualStyles = false;

            dvgProdutos.ColumnHeadersDefaultCellStyle.BackColor =
                Color.SaddleBrown;

            dvgProdutos.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dvgProdutos.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.SaddleBrown;

            dvgProdutos.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                Color.White;

            dvgProdutos.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            dvgProdutos.ColumnHeadersHeight = 40;

            dvgProdutos.RowHeadersDefaultCellStyle.BackColor = Color.White;
            dvgProdutos.RowHeadersDefaultCellStyle.ForeColor = Color.Black;
            dvgProdutos.RowHeadersVisible = false;
            dvgProdutos.GridColor = Color.LightGray;
            dvgProdutos.RowTemplate.Height = 35;

            dvgProdutos.DefaultCellStyle.Font =
                new Font("Segoe UI", 10F);
        }

        private class CategoriaItem
        {
            public int Id { get; set; }
            public string Nome { get; set; }

            public CategoriaItem(int id, string nome)
            {
                Id = id;
                Nome = nome;
            }

            public override string ToString()
            {
                return Nome;
            }
        }

        private void CarregarCategorias()
        {
            try
            {
                cmbCategoria.DataSource = null;
                cmbCategoria.Items.Clear();

                cmbCategoria.DropDownStyle =
                    ComboBoxStyle.DropDownList;

                Conexao conexao = new Conexao();

                using (MySqlConnection conn = conexao.conectarBD())
                {
                    string sql = @"
                        SELECT id_categoria, nome
                        FROM BBD.categorias
                        ORDER BY nome";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["id_categoria"]);
                            string nome = reader["nome"].ToString();

                            cmbCategoria.Items.Add(
                                new CategoriaItem(id, nome));
                        }
                    }
                }

                cmbCategoria.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar categorias:\n" + ex.Message);
            }
        }

        private void CarregarProdutos()
        {
            try
            {
                Conexao conexao = new Conexao();

                using (MySqlConnection conn = conexao.conectarBD())
                {
                    string sql = @"
                        SELECT
                            p.id_produto,
                            p.nome,
                            p.preco,
                            p.id_categoria,
                            c.nome AS categoria
                        FROM BBD.produtos p
                        LEFT JOIN BBD.categorias c
                            ON p.id_categoria = c.id_categoria
                        ORDER BY p.id_produto DESC";

                    using (MySqlDataAdapter adapter =
                        new MySqlDataAdapter(sql, conn))
                    {
                        DataTable tabela = new DataTable();

                        adapter.Fill(tabela);

                        dvgProdutos.DataSource = null;
                        dvgProdutos.Columns.Clear();
                        dvgProdutos.DataSource = tabela;
                    }
                }

                if (dvgProdutos.Columns["id_produto"] != null)
                    dvgProdutos.Columns["id_produto"].Visible = false;

                if (dvgProdutos.Columns["id_categoria"] != null)
                    dvgProdutos.Columns["id_categoria"].Visible = false;

                if (dvgProdutos.Columns["nome"] != null)
                    dvgProdutos.Columns["nome"].HeaderText = "Produto";

                if (dvgProdutos.Columns["preco"] != null)
                {
                    dvgProdutos.Columns["preco"].HeaderText = "Preço";

                    dvgProdutos.Columns["preco"]
                        .DefaultCellStyle.Format = "C2";

                    dvgProdutos.Columns["preco"]
                        .DefaultCellStyle.FormatProvider =
                        CultureInfo.GetCultureInfo("pt-BR");
                }

                if (dvgProdutos.Columns["categoria"] != null)
                    dvgProdutos.Columns["categoria"].HeaderText = "Categoria";

                dvgProdutos.ClearSelection();
                idSelecionado = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar produtos:\n" + ex.Message);
            }
        }

        private bool ValidarCampos(
            out string nome,
            out decimal preco,
            out int idCategoria)
        {
            nome = txtNomeProduto.Text.Trim();
            preco = 0;
            idCategoria = 0;

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Digite o nome do produto.");
                txtNomeProduto.Focus();
                return false;
            }

            if (nome.Length > 120)
            {
                MessageBox.Show(
                    "O nome deve ter no máximo 120 caracteres.");
                return false;
            }

            if (!decimal.TryParse(
                txtPreco.Text,
                NumberStyles.Number,
                CultureInfo.GetCultureInfo("pt-BR"),
                out preco))
            {
                MessageBox.Show(
                    "Digite um preço válido. Exemplo: 25,90");

                txtPreco.Focus();
                return false;
            }

            if (preco < 0 ||
                preco > 99999999.99m ||
                decimal.Round(preco, 2) != preco)
            {
                MessageBox.Show("Informe um preço válido.");
                return false;
            }

            CategoriaItem categoria =
                cmbCategoria.SelectedItem as CategoriaItem;

            if (categoria == null)
            {
                MessageBox.Show("Selecione uma categoria.");
                cmbCategoria.Focus();
                return false;
            }

            idCategoria = categoria.Id;

            return true;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos(
                out string nome,
                out decimal preco,
                out int idCategoria))
                return;

            try
            {
                Conexao conexao = new Conexao();

                using (MySqlConnection conn = conexao.conectarBD())
                {
                    string sql = @"
                        INSERT INTO BBD.produtos
                        (nome, preco, id_categoria)
                        VALUES
                        (@nome, @preco, @categoria)";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@preco", preco);
                        cmd.Parameters.AddWithValue("@categoria", idCategoria);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Produto cadastrado com sucesso!");

                LimparCampos();
                CarregarProdutos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar:\n" + ex.Message);
            }
        }

        private void dvgProdutos_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.RowIndex >= dvgProdutos.Rows.Count)
                return;

            DataGridViewRow linha = dvgProdutos.Rows[e.RowIndex];

            if (linha.IsNewRow)
                return;

            object valorId = linha.Cells["id_produto"].Value;

            if (valorId == null || valorId == DBNull.Value)
                return;

            idSelecionado = Convert.ToInt32(valorId);

            txtNomeProduto.Text =
                Convert.ToString(linha.Cells["nome"].Value);

            decimal preco = Convert.ToDecimal(
                linha.Cells["preco"].Value);

            txtPreco.Text = preco.ToString(
                "F2",
                CultureInfo.GetCultureInfo("pt-BR"));

            cmbCategoria.SelectedIndex = -1;

            object valorCategoria =
                linha.Cells["id_categoria"].Value;

            if (valorCategoria != null &&
                valorCategoria != DBNull.Value)
            {
                int idCategoria = Convert.ToInt32(valorCategoria);

                for (int i = 0; i < cmbCategoria.Items.Count; i++)
                {
                    CategoriaItem item =
                        cmbCategoria.Items[i] as CategoriaItem;

                    if (item != null && item.Id == idCategoria)
                    {
                        cmbCategoria.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (idSelecionado == 0)
            {
                MessageBox.Show("Selecione um produto na tabela.");
                return;
            }

            if (!ValidarCampos(
                out string nome,
                out decimal preco,
                out int idCategoria))
                return;

            try
            {
                Conexao conexao = new Conexao();

                using (MySqlConnection conn = conexao.conectarBD())
                {
                    string sql = @"
                        UPDATE BBD.produtos
                        SET
                            nome = @nome,
                            preco = @preco,
                            id_categoria = @categoria
                        WHERE id_produto = @id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@preco", preco);
                        cmd.Parameters.AddWithValue("@categoria", idCategoria);
                        cmd.Parameters.AddWithValue("@id", idSelecionado);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Produto atualizado com sucesso!");

                LimparCampos();
                CarregarProdutos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar:\n" + ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (idSelecionado == 0)
            {
                MessageBox.Show("Selecione um produto na tabela.");
                return;
            }

            DialogResult resposta = MessageBox.Show(
                "Deseja realmente excluir este produto?",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resposta != DialogResult.Yes)
                return;

            try
            {
                Conexao conexao = new Conexao();

                using (MySqlConnection conn = conexao.conectarBD())
                {
                    string sql = @"
                        DELETE FROM BBD.produtos
                        WHERE id_produto = @id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idSelecionado);

                        int linhas = cmd.ExecuteNonQuery();

                        if (linhas == 0)
                        {
                            MessageBox.Show("Produto não encontrado.");
                            return;
                        }
                    }
                }

                MessageBox.Show("Produto excluído com sucesso!");

                LimparCampos();
                CarregarProdutos();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    MessageBox.Show(
                        "Este produto possui registros relacionados e não pode ser excluído.");
                }
                else
                {
                    MessageBox.Show("Erro ao excluir:\n" + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir:\n" + ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtNomeProduto.Clear();
            txtPreco.Clear();

            cmbCategoria.SelectedIndex = -1;

            idSelecionado = 0;

            dvgProdutos.ClearSelection();

            txtNomeProduto.Focus();
        }
        private void btnPedidos_Click(object sender, EventArgs e)
        {
            using (FrmPedidos telaPedidos = new FrmPedidos())
            {
                telaPedidos.ShowDialog();
            }
        }

        private void cmbCategoria_SelectedIndexChanged(
            object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}