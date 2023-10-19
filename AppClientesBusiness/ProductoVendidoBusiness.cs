using SistemaGestionData;
using SistemaGestionEntities;

namespace SistemaGestionBusiness
{

    public class ProductoVendidoBusiness
    {
        private readonly IMasterDataService _masterDataService;

        public ProductoVendidoBusiness(IMasterDataService masterDataService)
        {
            _masterDataService = masterDataService;
        }

        public ProductoVendidoDto ObtenerProductoVendidoPorId(int id)
        {
            return _masterDataService.ProductSolds.GetProductSalesById(id);
        }

    }

}