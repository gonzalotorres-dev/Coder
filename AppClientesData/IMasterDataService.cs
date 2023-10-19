namespace SistemaGestionData
{
    public interface IMasterDataService
    {
        public IProductRepository Products { get; }

        public IProductSoldRepository ProductSolds { get; }

        public ISalesRepository Sales { get; }

        public IUsersRepository Users { get; }
    }
}
