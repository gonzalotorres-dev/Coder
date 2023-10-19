using SistemaGestionEntities;

namespace SistemaGestionData
{
    public interface IProductRepository
    {
        ProductoDto GetProductById(int IdProduct);

        List<ProductoDto> GetProductList();

        void CreateProduct(ProductoDto product);

        void UpdateProduct(ProductoDto product);

        void DeleteProduct(ProductoDto product);
    }
}
