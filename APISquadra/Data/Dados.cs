using APISquadra.Models;
using Microsoft.AspNetCore.Mvc;

namespace APISquadra.Data
{
    public class Dados
    {
        private readonly AppDbContext _context;

        public Dados(AppDbContext context)
        {
            _context = context;
        }

        private ActionResult<Produto> PegarProduto(Guid? id)
        {
            var produto = _context.Produto.Find(id);

            return produto;
        }
        public ActionResult<Produto> RetornarProduto (Guid id)
        {
            var retorno = PegarProduto(id);
            return retorno;
        }
    }
}
