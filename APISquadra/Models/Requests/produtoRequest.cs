namespace APISquadra.Models.Requests
{
    public class produtoRequest
    {
        public string ProdutoName { get; set; } = string.Empty;
        public string ProdutoDescription { get; set; } = string.Empty;
        public decimal ProdutoValue { get; set; }
        public int ProdutoAmount { get; set; }
    }
}
