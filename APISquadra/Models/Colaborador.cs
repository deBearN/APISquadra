namespace APISquadra.Models
{
    public class Colaborador: Usuarios
    {
        public decimal colabSalario {  get; set; }
        public string colabCpf { get; set; }
        public enum ColaboradorPerms
        {
            Funcionario = 1,
            Administrador = 2
        }
        public ColaboradorPerms colabPerms { get; set; } = ColaboradorPerms.Funcionario;
    }
}
