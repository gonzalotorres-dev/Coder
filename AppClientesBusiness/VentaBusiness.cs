using SistemaGestionData;
using SistemaGestionEntities;

namespace SistemaGestionBusiness
{

    public class VentaBusiness
    {
        private readonly IMasterDataService _masterDataService;

        public VentaBusiness(IMasterDataService masterDataService)
        {
            _masterDataService = masterDataService;
        }

        public VentaDto ObtenerVentaPorId(int id)
        {
            return _masterDataService.Sales.GetSalesById(id);
        }

    }

}