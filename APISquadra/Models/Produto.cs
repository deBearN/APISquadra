using APISquadra.Services;

namespace APISquadra.Models
{
    public class Produto
    {
        public Guid ProdutoID { get; set; }
        public string ProdutoName { get; set; } = string.Empty;
        public string ProdutoDescription { get; set; } = string.Empty;
        public bool ProdutoAvailability { get; set; }
        public decimal ProdutoValue { get; set; }
        public int ProdutoAmount { get; set; }
    }
}
