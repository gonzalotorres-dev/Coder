using Microsoft.AspNetCore.Mvc;
using SistemaGestionData;
using SistemaGestionEntities;

namespace AppClientsUserAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IMasterDataService _masterDataService;

        public VentaController(IMasterDataService masterDataService)
        {
            _masterDataService = masterDataService;
        }

        //Crear
        [HttpPost]
        public void Create([FromBody] VentaDto sales)
        {
            _masterDataService.Sales.CreateSales(sales);   
        }

        //Actualizar
        [HttpPut]
        public void Update([FromBody] VentaDto sales)
        {
            _masterDataService.Sales.UpdateSales(sales);
        }

        //Borrar
        [HttpDelete]
        public void Delete([FromBody] VentaDto sales)
        {
            _masterDataService.Sales.DeleteSale(sales);
        }

        //Obtener
        [HttpGet]
        public List<VentaDto> GetProductList()
        {
            var salesList = _masterDataService.Sales.GetSalesList();

            return salesList;
        }

        [HttpGet]
        public VentaDto GetSalesById([FromBody] int salesId)
        {
            return _masterDataService.Sales.GetSalesById(salesId);
        }
    }
}
