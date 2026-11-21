using System.Text.Json.Serialization;

namespace BestBurger
{
    public class PedidoJson
    {
        [JsonPropertyName("pedido_id")]
        public string PedidoId { get; set; }

        [JsonPropertyName("cliente")]
        public ClienteJson Cliente { get; set; } // <- Aqui deve ser a classe ClienteJson, NÃO string!

        [JsonPropertyName("total")]
        public decimal Total { get; set; }
    }

    public class ClienteJson
    {
        [JsonPropertyName("nome")]
        public string Nome { get; set; } // <- É aqui dentro que a propriedade 'Nome' existe!
    }
}