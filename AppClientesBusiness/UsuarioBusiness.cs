using SistemaGestionData;
using SistemaGestionEntities;

namespace SistemaGestionBusiness
{

    public class UsuarioBusiness
    {
        private readonly IMasterDataService _masterDataService;

        public UsuarioBusiness(IMasterDataService masterDataService)
        {
            _masterDataService = masterDataService;
        }

        public UsuarioDto ObtenerUsuarioPorId(int id)
        {
            return _masterDataService.Users.GetUserById(id);
        }

    }

}