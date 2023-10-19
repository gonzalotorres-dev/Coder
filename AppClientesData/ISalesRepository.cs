using SistemaGestionEntities;

namespace SistemaGestionData
{
    public interface ISalesRepository
    {
        VentaDto GetSalesById(int IdSales);

        List<VentaDto> GetSalesList();

        void CreateSales(VentaDto sales);

        void UpdateSales(VentaDto sales);

        void DeleteSale(VentaDto sales);

    }
}
