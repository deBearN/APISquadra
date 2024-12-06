using APISquadra.Data;
using APISquadra.DTO;
using APISquadra.Models;
using APISquadra.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISquadra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Gerente, Estoquista, Funcionario")]
        public ActionResult<List<Produto>> GetProdutos()
        {
            return Ok(_context.Produto.ToList());
        }

        [HttpGet("Estoque")]
        [Authorize(Roles = "Gerente, Estoquista, Funcionario")]
        public ActionResult<Produto> GetProdutosEmEstoque()
        {

            return Ok(_context.Produto.ToList().Where(p => p.ProdutoAvailability == true));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Gerente, Estoquista, Funcionario")]
        public ActionResult<Produto> GetProduto([FromRoute] Guid id)
        {
            Dados _dados = new Dados(_context);
            var produto = _dados.RetornarProduto(id);

            if (produto == null) return NotFound();

            return Ok(produto);
        }
        [HttpPost]
        [Authorize(Roles = "Gerente, Estoquista")]
        //TODO Authenticar para Estoquista/Admin
        public ActionResult<Produto> CreateProduto([FromBody] produtoRequest request)
        {
            var produto = new Produto()
            {
                ProdutoID = Guid.NewGuid(),
                ProdutoName = request.ProdutoName,
                ProdutoDescription = request.ProdutoDescription,
                ProdutoValue = request.ProdutoValue,
                ProdutoAmount = request.ProdutoAmount,
                ProdutoAvailability = ProdutoService.ValidarEstoque(request.ProdutoAmount)

            };

            _context.Produto.Add(produto);
            _context.SaveChanges();
            return Ok(produto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Gerente, Estoquista")]
        public ActionResult<Produto> UpdateProduto(
            [FromRoute] Guid id,
            [FromBody] produtoRequest request)
        {
            if (id == Guid.Empty) return BadRequest();
            var produto = new Produto()
            {
                ProdutoID = id,
                ProdutoName = request.ProdutoName,
                ProdutoDescription = request.ProdutoDescription,
                ProdutoValue = request.ProdutoValue,
                ProdutoAmount = request.ProdutoAmount,
                ProdutoAvailability = ProdutoService.ValidarEstoque(request.ProdutoAmount)
            };

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Gerente")]
        public IActionResult DeletarProduto([FromRoute] Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var produto = _context.Produto.Find(id);
            if (produto == null) return NotFound();

            _context.Produto.Remove(produto);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
