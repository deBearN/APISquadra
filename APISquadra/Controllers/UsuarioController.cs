using APISquadra.Models;
using APISquadra.Models.Requests;
using APISquadra.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoSquadra.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController
    {
        private readonly UsuarioService usuariosService = new UsuarioService();

        [HttpGet]
        public List<Usuario> returnUsuarios()
        {
            var _usuarios = usuariosService.returnAllUsuarios();
            
            return _usuarios;
        }
        
        [HttpPost]
        public List<Usuario> RegistrarUsuario([FromBody] userRequest request)
        {
            var usuariosCadastrados = usuariosService.registerUsuarios(request.userName, request.userPassword, request.userEmail, request.userPhone);

            return usuariosCadastrados;
        }

        [HttpDelete("{id}")]
        public List<Usuario> Delete([FromRoute] Guid id)
        {
            usuariosService.removeUser(id);

            return usuariosService.returnAllUsuarios();
        }

        [HttpPut("{id}")]
        public List<Usuario> Atualizar(userRequest request, [FromRoute] Guid id)
        {
            usuariosService.updateUsuario(id, request.userName, request.userPassword, request.userEmail, request.userPhone);

            return usuariosService.returnAllUsuarios();
        }
    }
}
