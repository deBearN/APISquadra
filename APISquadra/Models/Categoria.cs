using System.Text.Json.Serialization;

namespace APISquadra.Models
{
    public class Categoria
    {
        public int idCategoria { get; set; }
        public string nomeCategoria { get; set; } = string.Empty;

        [JsonIgnore] // Para acabar com loop de serializacao
        public ICollection<Produto> Produtos { get; set; }
    }
}
