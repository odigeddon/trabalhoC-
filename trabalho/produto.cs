using System;

namespace BestBurger
{
    internal class Produto
    {
        public int IdProduto { get; set; }

        public string Nome { get; set; } = "";

        public string Descricao { get; set; } = "";

        public decimal Preco { get; set; }

        public int? IdCategoria { get; set; }

        public bool Ativo { get; set; } = true;

        public DateTime CriadoEm { get; set; }
    }
}
