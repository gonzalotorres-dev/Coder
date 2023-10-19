using Microsoft.AspNetCore.Mvc;
using SistemaGestionData;
using SistemaGestionEntities;

namespace AppClientsUserAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IMasterDataService _masterDataService;

        public ProductoController(IMasterDataService masterDataService)
        {
            _masterDataService = masterDataService;
        }

        //Crear
        [HttpPost]
        public void Create([FromBody] ProductoDto product)
        {
            _masterDataService.Products.CreateProduct(product);   
        }

        //Actualizar
        [HttpPut]
        public void Update([FromBody] ProductoDto product)
        {
            _masterDataService.Products.UpdateProduct(product);
        }

        //Borrar
        [HttpDelete]
        public void Delete([FromBody] ProductoDto product)
        {
            _masterDataService.Products.DeleteProduct(product);
        }

        //Obtener
        [HttpGet]
        public List<ProductoDto> GetProductList()
        {
            var productList = _masterDataService.Products.GetProductList();

            return productList;
        }

        [HttpGet]
        public ProductoDto GetProductById([FromBody] int productId)
        {
            return _masterDataService.Products.GetProductById(productId);
        }
    }
}
