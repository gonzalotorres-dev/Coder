using SistemaGestionData;
using SistemaGestionEntities;

namespace SistemaGestionBusiness
{

    public class ProductoBusiness
    {
        private readonly IMasterDataService _masterDataService;

        public ProductoBusiness(IMasterDataService masterDataService)
        {
            _masterDataService = masterDataService;
        }

        public ProductoDto ObtenerProductoPorId(int id)
        {
            return _masterDataService.Products.GetProductById(id);
        }

    }

}