using APISquadra.Models;
using APISquadra.Models.Requests;
using APISquadra.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoSquadra.Controllers
{

    [ApiController]
    [Route("[controller]")]
    
    public class ColaboradorController
    {
        private readonly ColaboradorServices colaboradorServices = new ColaboradorServices();

        [HttpGet]
        public List<Colaborador> returnColaborador()
        {
            var _colaborador = colaboradorServices.returnAllColaboradores();

            return _colaborador;
        }

        [HttpPost]
        public List<Colaborador> RegistrarColaborador([FromBody] colabRequest request)
        {
            var _colaboradorCadastrados = colaboradorServices.registerColaborador(request.userName, request.userPassword, request.userEmail, request.userPhone, request.colabCpf, request.colabCargo);

            return _colaboradorCadastrados;
        }

        [HttpDelete("{id}")]
        public List<Colaborador> Delete([FromRoute] Guid id)
        {
            colaboradorServices.removeColaborador(id);

            return colaboradorServices.returnAllColaboradores();
        }

        [HttpPut("{id}")]
        public List<Colaborador> Atualizar(colabRequest request, [FromRoute] Guid id)
        {
            colaboradorServices.updateColaborador(id, request.userName, request.userPassword, request.userEmail, request.userPhone, request.colabCpf, request.colabSalario, request.colabCargo);

            return colaboradorServices.returnAllColaboradores();
        }
    }
}
