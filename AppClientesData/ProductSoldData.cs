using MiProyecto;
using Npgsql;
using NpgsqlTypes;
using System;

namespace AppClientesData
{
    public static class ProductSoldData
    {
        public static ProductoVendido GetProductSalesById(int IdSales)
        {
            ProductoVendido salesList = new ProductoVendido();

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
                                var sale = new ProductoVendido();

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

    }
}
    