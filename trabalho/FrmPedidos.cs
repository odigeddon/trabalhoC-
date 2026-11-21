using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BestBurger
{
    public partial class FrmPedidos : Form
    {
        public FrmPedidos()
        {
            InitializeComponent();

            btnImportar.Click -= btnImportar_Click;
            btnImportar.Click += btnImportar_Click;

            dgvPedidos.ReadOnly = true;
            dgvPedidos.AllowUserToAddRows = false;
            dgvPedidos.AllowUserToDeleteRows = false;
            dgvPedidos.MultiSelect = false;
            dgvPedidos.AutoGenerateColumns = true;

            dgvPedidos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvPedidos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvPedidos.BackgroundColor =
                System.Drawing.Color.White;

            dgvPedidos.DefaultCellStyle.BackColor =
                System.Drawing.Color.White;

            dgvPedidos.DefaultCellStyle.ForeColor =
                System.Drawing.Color.Black;

            dgvPedidos.DefaultCellStyle.SelectionBackColor =
                System.Drawing.Color.SaddleBrown;

            dgvPedidos.DefaultCellStyle.SelectionForeColor =
                System.Drawing.Color.White;

            dgvPedidos.RowsDefaultCellStyle.ForeColor =
                System.Drawing.Color.Black;

            dgvPedidos.AlternatingRowsDefaultCellStyle.BackColor =
                System.Drawing.Color.Beige;

            dgvPedidos.AlternatingRowsDefaultCellStyle.ForeColor =
                System.Drawing.Color.Black;

            ListarPedidos();
        }

        private void ListarPedidos()
        {
            try
            {
                Conexao banco = new Conexao();

                using (MySqlConnection conexaoAberta =
                    banco.conectarBD())
                {
                    string query = @"
                        SELECT
                            codigo_pedido AS 'Código',
                            nome_cliente AS 'Cliente',
                            total AS 'Total',
                            status AS 'Status'
                        FROM BBD.pedidos_site
                        ORDER BY id DESC";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, conexaoAberta))
                    using (MySqlDataAdapter adapter =
                        new MySqlDataAdapter(cmd))
                    {
                        DataTable tabela = new DataTable();

                        adapter.Fill(tabela);

                        dgvPedidos.DataSource = null;
                        dgvPedidos.Columns.Clear();
                        dgvPedidos.DataSource = tabela;
                    }
                }

                if (dgvPedidos.Columns["Total"] != null)
                {
                    dgvPedidos.Columns["Total"]
                        .DefaultCellStyle.Format = "C2";

                    dgvPedidos.Columns["Total"]
                        .DefaultCellStyle.FormatProvider =
                        System.Globalization.CultureInfo
                            .GetCultureInfo("pt-BR");
                }

                dgvPedidos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao listar pedidos:\n\n" +
                    ex.Message);
            }
        }

        private void btnImportar_Click(
            object sender, EventArgs e)
        {
            try
            {
                // Altere para a pasta onde o site salva os pedidos JSON.
                DirectoryInfo pasta = new DirectoryInfo(
                    @"C:\Users\kiq\source\repos\trabalho\trabalho"
                );

                if (!pasta.Exists)
                {
                    MessageBox.Show(
                        "A pasta dos pedidos não foi encontrada:\n" +
                        pasta.FullName);
                    return;
                }

                FileInfo[] arquivos = pasta
                    .GetFiles("pedido_*.json")
                    .OrderByDescending(f => f.LastWriteTimeUtc)
                    .ToArray();

                if (arquivos.Length == 0)
                {
                    MessageBox.Show(
                        "Nenhum arquivo JSON encontrado na pasta.");
                    return;
                }

                FileInfo arquivoMaisRecente = arquivos[0];

                string textoJson = File.ReadAllText(
                    arquivoMaisRecente.FullName);

                if (string.IsNullOrWhiteSpace(textoJson))
                {
                    MessageBox.Show(
                        "O arquivo JSON está vazio:\n" +
                        arquivoMaisRecente.Name);
                    return;
                }

                PedidoJson pedidoDoSite =
                    JsonSerializer.Deserialize<PedidoJson>(
                        textoJson);

                if (pedidoDoSite == null ||
                    string.IsNullOrWhiteSpace(
                        pedidoDoSite.PedidoId) ||
                    pedidoDoSite.Cliente == null ||
                    string.IsNullOrWhiteSpace(
                        pedidoDoSite.Cliente.Nome) ||
                    pedidoDoSite.Total < 0)
                {
                    MessageBox.Show(
                        "O arquivo não contém um pedido válido:\n" +
                        arquivoMaisRecente.Name);
                    return;
                }

                Conexao banco = new Conexao();

                using (MySqlConnection conexaoAberta =
                    banco.conectarBD())
                {
                    string query = @"
                        INSERT INTO BBD.pedidos_site
                        (
                            codigo_pedido,
                            nome_cliente,
                            total,
                            status
                        )
                        VALUES
                        (
                            @codigo,
                            @cliente,
                            @total,
                            'Pendente'
                        )";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, conexaoAberta))
                    {
                        cmd.Parameters.AddWithValue(
                            "@codigo",
                            pedidoDoSite.PedidoId);

                        cmd.Parameters.AddWithValue(
                            "@cliente",
                            pedidoDoSite.Cliente.Nome);

                        cmd.Parameters.AddWithValue(
                            "@total",
                            pedidoDoSite.Total);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    $"Pedido {pedidoDoSite.PedidoId} " +
                    "foi importado com sucesso!");

                ListarPedidos();
            }
            catch (JsonException ex)
            {
                MessageBox.Show(
                    "Erro: o arquivo não contém um JSON válido.\n\n" +
                    ex.Message);
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show(
                        "Este pedido já foi importado!");
                }
                else
                {
                    MessageBox.Show(
                        "Erro no MySQL:\n\n" +
                        ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro: Pedido não importado.\n\n" +
                    ex.Message);
            }
        }

        private void button1_Click(
            object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
