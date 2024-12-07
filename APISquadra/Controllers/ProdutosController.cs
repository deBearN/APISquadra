using APISquadra.Data;
using APISquadra.DTO;
using APISquadra.Models;
using APISquadra.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
        public ActionResult<List<Produto>> GetProdutos()
        {
            return Ok(_context.Produto
        .Include(p => p.Categoria)
        .ToList());
        }

        [HttpGet("Estoque")]
        public ActionResult<Produto> GetProdutosEmEstoque()
        {

            return Ok(_context.Produto
        .Include(p => p.Categoria)
        .ToList()
        .Where(p => p.ProdutoAvailability == true));
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> GetProduto([FromRoute][Required] Guid id)
        {
            ProdutosDB _dados = new ProdutosDB(_context);
            var produto = _dados.RetornarProduto(id);

            if (produto == null) return NotFound();

            return produto;
        }
        [HttpPost]
        [Authorize(Roles = "Gerente, Estoquista")]
        //TODO Authenticar para Estoquista/Admin
        public ActionResult<Produto> CreateProduto([FromBody] produtoRequest request)
        {
            ProdutosDB _dados = new ProdutosDB(_context);
            DBChecks dBChecks = new DBChecks(_context);
            Produto produto = _dados.returnCreateProduto(request);
            //Checks
            ErrorCheck Check = (ErrorCheck)dBChecks.returnCheck(request, produto);
            if (Check.IsError == true)
            {
                return BadRequest(Check.Message);
            }
            //
            _context.Produto.Add(produto);
            _context.SaveChanges();
            return Ok(produto);

        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Gerente, Estoquista")]
        public ActionResult<Produto> UpdateProduto(
            [FromRoute][Required] Guid id,
            [FromBody] produtoRequest request)
        {

            DBChecks dbChecks = new DBChecks(_context);
            ProdutosDB produtosDB = new ProdutosDB(_context);
            var resultado = dbChecks.CheckID(id);


            if (resultado == true) {
                
                var produto = produtosDB.returnProdutoF(id, request);
                ErrorCheck Check = (ErrorCheck)dbChecks.returnCheck(request, produto);
                if (produto == null) return BadRequest("The product returned null! somehow...");
                if (Check.IsError == true) return BadRequest(Check.Message);
                _context.Entry(produto).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(produto);
            }
            else return BadRequest("The requested ID doesn't exist in our Database");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Gerente")]
        public IActionResult DeletarProduto([FromRoute][Required] Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Empty or Null ID");

            var produto = _context.Produto.Find(id);
            if (produto == null) return NotFound();

            _context.Produto.Remove(produto);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
