using APISquadra.DTO;
using APISquadra.Models;
using APISquadra.Services;
using Microsoft.AspNetCore.Mvc;

namespace APISquadra.Data
{
    public class ProdutosDB
    {
        private readonly AppDbContext _context;

        public ProdutosDB(AppDbContext context)
        {
            _context = context;
        }

        //GET
        private Produto PegarProduto(Guid? id)
        {
            var produto = _context.Produto.Find(id);

            return produto;
        }
        public ActionResult<Produto> RetornarProduto (Guid id)
        {
            var retorno = PegarProduto(id);
            return retorno;
        }
        //GET

        //POST
        private Produto criarProduto(produtoRequest request) // Fazer check se funcionou retorna true se nao false ai na controller ficaria se true Ok se nao BadRequest
        {
            Categoria categoria = new Categoria();

            var produto = new Produto()
            {
                ProdutoID = Guid.NewGuid(), 
                ProdutoName = request.ProdutoName,
                ProdutoDescription = request.ProdutoDescription,
                ProdutoValue = request.ProdutoValue,
                ProdutoAmount = request.ProdutoAmount,
                idCategoria = request.idCategoria,
                ProdutoAvailability = ProdutoService.ValidarEstoque(request.ProdutoAmount)

            };

            return produto;
        }

        public Produto returnCreateProduto(produtoRequest request)
        {
            return criarProduto(request);
        }
        //POST

        //PUT

        private Produto updateProdutoF(Guid id, produtoRequest request)
        {
            return new Produto()
            {
                ProdutoID = id,
                ProdutoName = request.ProdutoName,
                ProdutoDescription = request.ProdutoDescription,
                ProdutoValue = request.ProdutoValue,
                ProdutoAmount = request.ProdutoAmount,
                idCategoria = request.idCategoria,
                ProdutoAvailability = ProdutoService.ValidarEstoque(request.ProdutoAmount)
            };
        }

        public Produto returnProdutoF(Guid id, produtoRequest request)
        {
            return updateProdutoF(id, request);
        }
    }
}
