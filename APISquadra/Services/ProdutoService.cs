using APISquadra.Models;

namespace APISquadra.Services
{
    public class ProdutoService
    {
        public bool ValidarEstoque(int produtoAmount)
        {
            bool validado = false;
            if (produtoAmount > 0)
            {
                validado = true;
                return validado;
            }
            return validado;
        }

        public static List<Produto> listaProdutos {  get; set; } = new List<Produto>();

        //GET
        public List<Produto> ReturnAllProdutos()
        { 
            return listaProdutos; 
        }
        // POST
        public List<Produto> RegisterProduto(string name, string description, decimal value, int amount) 
        { 
            Produto _produto = new Produto();
            {
                _produto.ProdutoID = new Guid(Guid.NewGuid().ToString());
                _produto.ProdutoName = name;
                _produto.ProdutoDescription = description;
                _produto.ProdutoAmount = amount;
                _produto.ProdutoAvailability = ValidarEstoque(_produto.ProdutoAmount);
                _produto.ProdutoValue = value;
                
            }
            listaProdutos.Add( _produto );
            return ReturnAllProdutos();
        }
        public void removeProduto(Guid id)
        {
            var _produto = listaProdutos.FirstOrDefault(x => x.ProdutoID == id);

            if (_produto == null)
                return;

            listaProdutos.Remove(_produto);
        }
        public void updateProduto(Guid id, string name, string description, decimal value, int amount)
        {
            var _produto = listaProdutos.FirstOrDefault(x => x.ProdutoID == id);
            _produto.ProdutoName = name;
            _produto.ProdutoDescription = description;
            _produto.ProdutoAmount = amount;
            _produto.ProdutoAvailability = ValidarEstoque(_produto.ProdutoAmount);
            _produto.ProdutoValue = value;

            listaProdutos.Remove(_produto);
            listaProdutos.Add(_produto );
        }
    }
}
