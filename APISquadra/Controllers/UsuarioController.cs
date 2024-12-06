using APISquadra.Data;
using APISquadra.DTO;
using APISquadra.Models;
using APISquadra.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProjetoSquadra.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Gerente")]
        public ActionResult<List<Usuario>> GetUsuarios()
        {
            return Ok(_context.Usuario.ToList());
        }

        [HttpGet("{id?}")]
        [Authorize(Roles = "Gerente")]
        //Authenticar para Estoquista/Admin/Funcionario
        public ActionResult<Usuario> GetUsuario([FromRoute] Guid id)
        {
            var usuario = _context.Usuario.Find(id);

            if (usuario == null) return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        [Authorize(Roles = "Gerente")]
        public ActionResult<Usuario> CreateUsuario([FromBody] userRequest request)
        {
            var usuario = new Usuario()
            {
                userId = Guid.NewGuid(),
                userName = request.userName,
                userEmail = request.userEmail,
                userPassword = request.userPassword,
                userPhone = request.userPhone,
                userCargo = request.userCargo,
                userCpf = request.userCpf,
                userSalario = request.userSalario
            };

            _context.Usuario.Add(usuario);
            _context.SaveChanges();
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Gerente")]
        public ActionResult<Usuario> UpdateUsuario(
            [FromRoute] Guid id, 
            [FromBody] userRequest request)
        {
            if (id == Guid.Empty) return BadRequest();
            var usuario = new Usuario()
            {
                userId = id,
                userName = request.userName,
                userEmail = request.userEmail,
                userPassword = request.userPassword,
                userPhone = request.userPhone,
                userCargo = request.userCargo,
                userCpf = request.userCpf,
                userSalario = request.userSalario
            };

            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Gerente")]
        public IActionResult DeletarUsuario([FromRoute] Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var usuario = _context.Usuario.Find(id);
            if (usuario == null) return NotFound();

            _context.Usuario.Remove(usuario);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
