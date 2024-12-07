using APISquadra.DTO;
using APISquadra.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISquadra.Data
{
    public class DBChecks
    {
        private readonly AppDbContext _context;

        public DBChecks(AppDbContext context)
        {
            _context = context;
        }

        public bool CheckID(Guid id)
        {
            var productExists = _context.Produto.Any(x => x.ProdutoID == id);
    
            return productExists;

        }

        public bool CheckIDCat(int id)
        {
            var productExists = _context.Categoria.Any(x => x.idCategoria == id);

            return productExists;

        }

        private ErrorCheck CheckProduto(produtoRequest request, Produto produto)
        {
            ErrorCheck errorCheck = new ErrorCheck();
            if (produto == null)
            {

                errorCheck.IsError = true;
                errorCheck.Message = "Oops! The method returned null! somehow...";

                return errorCheck;
            }
            if (produto.ProdutoName == null)
            {
                errorCheck.IsError = true;
                errorCheck.Message = "The product name is null! somehow...";

                return errorCheck;
            };
            if (produto.ProdutoName == string.Empty)
            {
                errorCheck.IsError = true;
                errorCheck.Message = "The product name is empty!";

                return errorCheck;
            }
            if (produto.ProdutoValue < 0)
            {
                errorCheck.IsError = true;
                errorCheck.Message = "The product price can't be negative!";

                return errorCheck;
            }
            if (produto.ProdutoAmount < 0)
            {
                errorCheck.IsError = true;
                errorCheck.Message = "The product amount can't be negative!";

                return errorCheck;
            }
            if (produto.ProdutoName != request.ProdutoName) // Nao faz sentido existir, mas VAI QUE!
            {
                errorCheck.IsError = true;
                errorCheck.Message = "Something went wrong!";

                return errorCheck;
            }; //MAY BE REMOVED
            if (CheckIDCat(produto.idCategoria) == false) // Nao faz sentido existir, mas VAI QUE!
            {
                errorCheck.IsError = true;
                errorCheck.Message = "This category ID doesn't exist!";

                return errorCheck;
            }; //MAY BE REMOVED
            errorCheck.IsError = false;
            return errorCheck;
        }

        public ErrorCheck returnCheck (produtoRequest request, Produto produto)
        {
            var errorCheck = CheckProduto(request, produto);

            return errorCheck;
        }


    }
}
