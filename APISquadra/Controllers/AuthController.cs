using APISquadra.Data;
using APISquadra.DTO;
using APISquadra.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APISquadra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AuthController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserLogin login)
        {
            if (login == null)
            {
                return BadRequest("Invalid client request");
            }
            //Busca no banco para ver se login e senha existem\

            var _Usuario = _context.Usuario.Where(x => x.userName == login.UserName).FirstOrDefault();
            if (_Usuario.userName == login.UserName && _Usuario.userPassword == login.Password)
            {
                var token = AuthService.TokenUsuario(_Usuario.userCargo);

                return Ok(new { Token = token });
            }

            return Unauthorized(new { Mensagem = "Credenciais Invalidas", Codigo = 001 });
        }
        [HttpGet("RotaProtegida")]
        [Authorize(Roles = "Gerente, Estoquista, Funcionario")]
        public IActionResult RotaProtegida()
        {
            return Ok("Acessando uma rota Protegida");
        }
    }
}
