using APISquadra.Models;
using APISquadra.Models.Requests;
using APISquadra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APISquadra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoService produtoService = new ProdutoService();
        [HttpGet]
        public List<Produto> returnUsuarios()
        {
            var _produtos = produtoService.ReturnAllProdutos();

            return _produtos;
        }
        [HttpPost]
        public List<Produto> RegistrarUsuario([FromBody] produtoRequest request)
        {

            var _produtosCadastrados = produtoService.RegisterProduto(request.ProdutoName, request.ProdutoDescription, request.ProdutoValue, request.ProdutoAmount);
            return _produtosCadastrados;
        }
        [HttpDelete("{id}")]
        public List<Produto> Delete([FromRoute] Guid id)
        {
            produtoService.removeProduto(id);

            return produtoService.ReturnAllProdutos();
        }

        [HttpPut("{id}")]
        public List<Produto> Atualizar(produtoRequest request, [FromRoute] Guid id)
        {
            produtoService.updateProduto(id, request.ProdutoName, request.ProdutoDescription, request.ProdutoValue, request.ProdutoAmount);

            return produtoService.ReturnAllProdutos();
        }
    }
}
