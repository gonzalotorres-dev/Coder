using SistemaGestionEntities;

namespace SistemaGestionData
{
    public interface IProductSoldRepository
    {
        ProductoVendidoDto GetProductSalesById(int IdSales);

        List<ProductoVendidoDto> GetSoldProductsList();

        void CreateSoldProducts(ProductoVendidoDto soldProducts);

        void UpdateSoldProducts(ProductoVendidoDto soldProducts);

        void DeleteSoldProducts(ProductoVendidoDto soldProducts);

    }
}
