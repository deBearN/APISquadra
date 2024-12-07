using APISquadra.DTO;
using APISquadra.Models;
using APISquadra.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var produto = _context.Produto
        .Include(p => p.Categoria)
        .FirstOrDefault(p => p.ProdutoID == id);

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
            var categoria = _context.Categoria.FirstOrDefault(c => c.idCategoria == request.idCategoria);

            var produto = new Produto()
            {
                ProdutoID = Guid.NewGuid(),
                ProdutoName = request.ProdutoName,
                ProdutoDescription = request.ProdutoDescription,
                ProdutoValue = request.ProdutoValue,
                ProdutoAmount = request.ProdutoAmount,
                idCategoria = request.idCategoria,
                Categoria = categoria,
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
            var categoria = _context.Categoria.FirstOrDefault(c => c.idCategoria == request.idCategoria);
            return new Produto()
            {
                ProdutoID = id,
                ProdutoName = request.ProdutoName,
                ProdutoDescription = request.ProdutoDescription,
                ProdutoValue = request.ProdutoValue,
                ProdutoAmount = request.ProdutoAmount,
                idCategoria = request.idCategoria,
                Categoria = categoria,
                ProdutoAvailability = ProdutoService.ValidarEstoque(request.ProdutoAmount)
            };
        }

        public Produto returnProdutoF(Guid id, produtoRequest request)
        {
            return updateProdutoF(id, request);
        }
    }
}
