namespace APISquadra.Models
{
    public class Colaborador: Usuario
    {
        public decimal colabSalario {  get; set; }
        public string colabCpf { get; set; }
        public enum Cargo
        {
            Funcionario = 1,
            Estoquista = 2,
            Gerente = 3
        }
        public Cargo colabCargo { get; set; } = Cargo.Funcionario;
    }
}
