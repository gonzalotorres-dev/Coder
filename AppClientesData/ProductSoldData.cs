using Npgsql;
using NpgsqlTypes;
using SistemaGestionData;
using SistemaGestionEntities;

namespace AppClientesData
{
    public class ProductSoldData : IProductSoldRepository
    {
        public ProductoVendidoDto GetProductSalesById(int IdSales)
        {
            ProductoVendidoDto salesList = new ProductoVendidoDto();

            var query = "Select Id, IdProducto, Stock, IdVenta FROM coder.ProductoVendido where Id = @IdSales";

            string connectionString = @"Host=localhost;Port=5432;UserName=postgres;Password=Ab123456!";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection)) 
                {
                    var param = new NpgsqlParameter();
                    param.ParameterName = "IdSales";
                    param.NpgsqlDbType = NpgsqlDbType.Integer;
                    param.Value = IdSales;

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows != null)
                        {
                            while (reader.Read()) 
                            {
                                var sale = new ProductoVendidoDto();

                                sale.Id = Convert.ToInt32(reader["Id"]);
                                sale.IdProducto = reader["IdProducto"].ToString();
                                sale.Stock = reader["Stock"].ToString();
                                sale.IdVenta = reader["IdVenta"].ToString();
                            }
                        }
                    }
                }
            }

            return salesList;
        }

        public List<ProductoVendidoDto> GetSoldProductsList()
        {
            List<ProductoVendidoDto> salesList = new List<ProductoVendidoDto>();

            var query = "Select Id, Comentarios, IdUsuario FROM coder.ProductoVendido";

            string connectionString = @"Host=localhost;Port=5432;UserName=postgres;Password=Ab123456!";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows != null)
                        {
                            while (reader.Read())
                            {
                                var sale = new ProductoVendidoDto();

                                sale.Id = Convert.ToInt32(reader["Id"]);
                                sale.IdProducto = reader["IdProducto"].ToString();
                                sale.Stock = reader["Stock"].ToString();
                                sale.IdVenta = reader["IdVenta"].ToString();

                                salesList.Add(sale);
                            }
                        }
                    }
                }
            }

            return salesList;
        }

        public void CreateSoldProducts(ProductoVendidoDto soldProducts)
        {
            var query = @"insert into coder.ProductoVendido (IdProducto, Stock, IdVenta)
                values(@IdProducto, @Stock, @IdVenta)";

            string connectionString = @"Host=localhost;Port=5432;UserName=postgres;Password=Ab123456!";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.Add(new NpgsqlParameter("IdProducto", NpgsqlDbType.Varchar) { Value = soldProducts.IdProducto });
                    command.Parameters.Add(new NpgsqlParameter("Stock", NpgsqlDbType.Varchar) { Value = soldProducts.Stock });
                    command.Parameters.Add(new NpgsqlParameter("IdVenta", NpgsqlDbType.Varchar) { Value = soldProducts.IdVenta });
                }

                connection.Close();
            }
        }

        public void UpdateSoldProducts(ProductoVendidoDto soldProducts)
        {
            var query = @"update coder.ProductoVendido
                        set IdProducto = @IdProducto, 
                        Stock = @Stock,
                        IdVenta = @IdVenta
                        where Id = @Id";

            string connectionString = @"Host=localhost;Port=5432;UserName=postgres;Password=Ab123456!";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.Add(new NpgsqlParameter("IdProducto", NpgsqlDbType.Varchar) { Value = soldProducts.IdProducto });
                    command.Parameters.Add(new NpgsqlParameter("Stock", NpgsqlDbType.Varchar) { Value = soldProducts.Stock });
                    command.Parameters.Add(new NpgsqlParameter("IdVenta", NpgsqlDbType.Varchar) { Value = soldProducts.IdVenta });
                }

                connection.Close();
            }
        }

        public void DeleteSoldProducts(ProductoVendidoDto soldProducts)
        {
            var query = "Delete FROM coder.ProductoVendido where Id = @Id";

            string connectionString = @"Host=localhost;Port=5432;UserName=postgres;Password=Ab123456!";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.Add(new NpgsqlParameter("Id", NpgsqlDbType.Integer) { Value = soldProducts.Id });
                }

                connection.Close();
            }
        }
    }
}
    