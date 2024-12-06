using APISquadra.Data;
using APISquadra.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISquadra.Services
{
    public class ProdutoService
    {

        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }
        public static bool ValidarEstoque(int produtoAmount)
        {
            bool validado = false;
            if (produtoAmount > 0)
            {
                validado = true;
                return validado;
            }
            return validado;
        }
    }
}
