using Microsoft.AspNetCore.Mvc;
using SistemaGestionData;
using SistemaGestionEntities;

namespace AppClientsUserAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        private readonly IMasterDataService _masterDataService;

        public ProductoVendidoController(IMasterDataService masterDataService)
        {
            _masterDataService = masterDataService;
        }

        //Crear
        [HttpPost]
        public void Create([FromBody] ProductoVendidoDto soldProduct)
        {
            _masterDataService.ProductSolds.CreateSoldProducts(soldProduct);   
        }

        //Actualizar
        [HttpPut]
        public void Update([FromBody] ProductoVendidoDto soldProduct)
        {
            _masterDataService.ProductSolds.UpdateSoldProducts(soldProduct);
        }

        //Borrar
        [HttpDelete]
        public void Delete([FromBody] ProductoVendidoDto soldProduct)
        {
            _masterDataService.ProductSolds.DeleteSoldProducts(soldProduct);
        }

        //Obtener
        [HttpGet]
        public List<ProductoVendidoDto> GetSoldProductList()
        {
            var productSoldList = _masterDataService.ProductSolds.GetSoldProductsList();

            return productSoldList;
        }

        [HttpGet]
        public ProductoVendidoDto GetSoldProductbyId([FromBody] int soldProductId)
        {
            return _masterDataService.ProductSolds.GetProductSalesById(soldProductId); ;
        }
    }
}
