using SistemaGestionEntities;

namespace SistemaGestionData
{
    public interface IUsersRepository
    {
        UsuarioDto GetUserById(int IdUser);

        public List<UsuarioDto> GetUserList();

        void CreateUser(UsuarioDto user);

        void UpdateUser(UsuarioDto user);

        void DeleteUser(UsuarioDto user);

    }
}
