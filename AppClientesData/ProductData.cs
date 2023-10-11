using MiProyecto;
using Npgsql;
using NpgsqlTypes;
using System;

namespace AppClientesData
{
    public static class ProductData
    {
        public static Producto GetProductById(int IdProduct)
        {
            string connectionString = @"Host=localhost;Port=5432;UserName=postgres;Password=Ab123456!";

            Producto productList = new Producto();

            var query = "Select Id, Descripcion, Costo, PrecioVenta, Stock, IdUsuario FROM coder.Producto where Id = @IdProducto";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection)) 
                {
                    var param = new NpgsqlParameter();
                    param.ParameterName = "IdProducto";
                    param.NpgsqlDbType = NpgsqlDbType.Integer;
                    param.Value = IdProduct;

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows != null)
                        {
                            while (reader.Read()) 
                            {
                                var product = new Producto();

                                product.Id = Convert.ToInt32(reader["Id"]);
                                product.Descripcion = reader["Descripciones"].ToString();
                                product.Costo = Convert.ToDecimal(reader["Costo"]).ToString();
                                product.PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"]).ToString();
                                product.Stock = Convert.ToDecimal(reader["Stock"]).ToString();
                                product.IdUsuario = Convert.ToInt32(reader["IdUsuario"]).ToString();
                            }
                        }
                    }
                }
            }

            return productList;
        }

        public static List<Producto> GetProductList()
        {
            List<Producto> productList = new List<Producto>();

            string connectionString = @"Host=localhost;Port=5432;UserName=postgres;Password=Ab123456!";

            var query = "Select Id, Descripcion, Costo, PrecioVenta, Stock, IdUsuario FROM coder.Producto";

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
                                var product = new Producto();

                                product.Id = Convert.ToInt32(reader["Id"]);
                                product.Descripcion = reader["Descripciones"].ToString();
                                product.Costo = Convert.ToDecimal(reader["Costo"]).ToString();
                                product.PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"]).ToString();
                                product.Stock = Convert.ToDecimal(reader["Stock"]).ToString();
                                product.IdUsuario = Convert.ToInt32(reader["IdUsuario"]).ToString();

                                productList.Add(product);
                            }
                        }
                    }
                }
            }

            return productList;
        }

        public static void CreateProduct(Producto product)
        {
            var query = @"insert into coder.Producto (Descripcion, Costo, PrecioVenta, Stock, IdUsuario)
                values(@Descripcion, @Costo, @PrecioVenta, @Stock, @IdUsuario)";

            string connectionString = @"Host=localhost;Port=5432;UserName=postgres;Password=Ab123456!";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.Add(new NpgsqlParameter("Descripcion", NpgsqlDbType.Varchar) { Value = product.Descripcion });
                    command.Parameters.Add(new NpgsqlParameter("Costo", NpgsqlDbType.Money) { Value = product.Costo });
                    command.Parameters.Add(new NpgsqlParameter("PrecioVenta", NpgsqlDbType.Money) { Value = product.PrecioVenta });
                    command.Parameters.Add(new NpgsqlParameter("Stock", NpgsqlDbType.Integer) { Value = product.Stock });
                    command.Parameters.Add(new NpgsqlParameter("IdUsuario", NpgsqlDbType.Varchar) { Value = product.IdUsuario });
                }

                connection.Close();
            }
        }

        public static void UpdateProduct(Producto product)
        {
            var query = @"update coder.Producto
                        set Descripcion = @Descripcion, 
                        Costo = @Costo, 
                        PrecioVenta = @PrecioVenta, 
                        Stock = @Stock, 
                        IdUsuario = @IdUsuario 
                        where Id = @Id";

            string connectionString = @"Host=localhost;Port=5432;UserName=postgres;Password=Ab123456!";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.Add(new NpgsqlParameter("Descripcion", NpgsqlDbType.Varchar) { Value = product.Descripcion });
                    command.Parameters.Add(new NpgsqlParameter("Costo", NpgsqlDbType.Money) { Value = product.Costo });
                    command.Parameters.Add(new NpgsqlParameter("PrecioVenta", NpgsqlDbType.Money) { Value = product.PrecioVenta });
                    command.Parameters.Add(new NpgsqlParameter("Stock", NpgsqlDbType.Integer) { Value = product.Stock });
                    command.Parameters.Add(new NpgsqlParameter("IdUsuario", NpgsqlDbType.Varchar) { Value = product.IdUsuario });
                }

                connection.Close();
            }
        }

        public static void DeleteProduct(Producto product)
        {
            var query = "Delete FROM coder.Producto where Id = @Id";

            string connectionString = @"Host=localhost;Port=5432;UserName=postgres;Password=Ab123456!";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.Add(new NpgsqlParameter("Id", NpgsqlDbType.Integer) { Value = product.Id } );       
                }

                connection.Close();
            }
        }

    }
}
    