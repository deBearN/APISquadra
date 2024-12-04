using APISquadra.Models;
namespace APISquadra.Models.Requests
{
    public class colabRequest: userRequest
    {
        public decimal colabSalario { get; set; }
        public string colabCpf { get; set; }
        public Colaborador.Cargo colabCargo { get; set; } = Colaborador.Cargo.Funcionario;
    }
}
