using APISquadra.Models;

namespace APISquadra.Services
{
    public class UsuarioService
    {
        private static List<Usuario> ListaUsuario { get; set; } = new List<Usuario>();
        //Retornar dados GET
        public List<Usuario> returnAllUsuarios()
        { return ListaUsuario; }
        //RegistrarDados POST
        public List<Usuario> registerUsuarios(string username, string password, string useremail, string userphone)
        {
            Usuario _usuario = new Usuario();
            {
                _usuario.userId = new Guid(Guid.NewGuid().ToString());
                _usuario.userName = username;
                _usuario.userPassword = password;
                _usuario.userEmail = useremail;
                _usuario.userPhone = userphone;
            }

            ListaUsuario.Add(_usuario);
            return returnAllUsuarios();
        }
        //Deletar dados DELETE
        public void removeUser(Guid id)
        {
            var _usuario = ListaUsuario.FirstOrDefault(x => x.userId == id);

            if (_usuario == null)
                return;

            ListaUsuario.Remove(_usuario);
        }
        //Update dados PUT
        public void updateUsuario(Guid id, string username, string password, string useremail, string userphone)
        {
            var _usuario = ListaUsuario.FirstOrDefault(x => x.userId == id);
            _usuario.userName = username;
            _usuario.userPassword = password;
            _usuario.userEmail = useremail;
            _usuario.userPhone = userphone;

            ListaUsuario.Remove(_usuario);
            ListaUsuario.Add(_usuario);
        }
    }
}
