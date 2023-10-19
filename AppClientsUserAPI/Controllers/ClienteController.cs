using Microsoft.AspNetCore.Mvc;
using SistemaGestionData;
using SistemaGestionEntities;

namespace AppClientsUserAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMasterDataService _masterDataService;

        public UsuarioController(IMasterDataService masterDataService)
        {
            _masterDataService = masterDataService;
        }

        //Crear
        [HttpPost]
        public void Create([FromBody]UsuarioDto user)
        {
            _masterDataService.Users.CreateUser(user);   
        }

        //Actualizar
        [HttpPut]
        public void Update([FromBody] UsuarioDto user)
        {
            _masterDataService.Users.UpdateUser(user);
        }

        //Borrar
        [HttpDelete]
        public void Delete([FromBody] UsuarioDto user)
        {
            _masterDataService.Users.DeleteUser(user);
        }

        //Obtener
        [HttpGet]
        public List<UsuarioDto> GetUsersList()
        {
            var usersList = _masterDataService.Users.GetUserList();

            return usersList;
        }

        [HttpGet]
        public UsuarioDto GetUserById([FromBody] int userId)
        {
            return _masterDataService.Users.GetUserById(userId);
        }
    }
}
