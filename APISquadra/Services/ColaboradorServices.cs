using APISquadra.Models;

namespace APISquadra.Services
{
    public class ColaboradorServices
    {

        private static List<Colaborador> ListaColaboradores { get; set; } = new List<Colaborador>();

        //Retornar dados GET
        public List<Colaborador> returnAllColaboradores()
        { return ListaColaboradores; }
        //RegistrarDados POST
        public List<Colaborador> registerColaborador(string username, string password, string useremail, string userphone, string cpf, Colaborador.Cargo Cargo)
        {
            Colaborador _colaborador = new Colaborador();
            {
                _colaborador.userId = new Guid(Guid.NewGuid().ToString());
                _colaborador.userName = username;
                _colaborador.userPassword = password;
                _colaborador.userEmail = useremail;
                _colaborador.userPhone = userphone;
                _colaborador.colabCpf = cpf;
                _colaborador.colabCargo = Cargo;
            }
            ListaColaboradores.Add(_colaborador);
            return returnAllColaboradores();
        }
            //Deletar dados DELETE
        public void removeColaborador(Guid id)
        {
            var _colaborador = ListaColaboradores.FirstOrDefault(x => x.userId == id);

            if (_colaborador == null)
                return;

            ListaColaboradores.Remove(_colaborador);
        }
        //Update dados PUT
        public void updateColaborador(Guid id, string username, string password, string useremail, string userphone, string cpf, decimal salario, Colaborador.Cargo Cargo)
        {
            var _colaborador = ListaColaboradores.FirstOrDefault(x => x.userId == id);
            _colaborador.userName = username;
            _colaborador.userPassword = password;
            _colaborador.userEmail = useremail;
            _colaborador.userPhone = userphone;
            _colaborador.colabCpf = cpf;
            _colaborador.colabSalario = salario;
            _colaborador.colabCargo = Cargo;

            ListaColaboradores.Remove(_colaborador);
            ListaColaboradores.Add(_colaborador);
        }
    }
}

