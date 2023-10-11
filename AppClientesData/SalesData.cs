using MiProyecto;
using Npgsql;
using NpgsqlTypes;
using System;

namespace AppClientesData
{
    public static class SalesData
    {
        public static Venta GetSalesById(int IdSales)
        {
            Venta salesList = new Venta();

            var query = "Select Id, Comentarios, IdUsuario FROM coder.Venta where Id = @IdSales";

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
                                var sale = new Venta();

                                sale.Id = Convert.ToInt32(reader["Id"]);
                                sale.Comentarios = reader["Comentarios"].ToString();
                                sale.IdUsuario = Convert.ToInt32(reader["IdUsuario"]).ToString();
                            }
                        }
                    }
                }
            }

            return salesList;
        }

        public static List<Venta> GetSalesList()
        {
            List<Venta> salesList = new List<Venta>();

            var query = "Select Id, Comentarios, IdUsuario FROM coder.Venta";

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
                                var sale = new Venta();

                                sale.Id = Convert.ToInt32(reader["Id"]);
                                sale.Comentarios = reader["Comentarios"].ToString();
                                sale.IdUsuario = Convert.ToInt32(reader["IdUsuario"]).ToString();

                                salesList.Add(sale);
                            }
                        }
                    }
                }
            }

            return salesList;
        }

        public static void CreateSales(Venta sales)
        {
            var query = @"insert into coder.Venta (Comentarios, IdUsuario)
                values(@Comentarios, @IdUsuario)";

            string connectionString = @"Host=localhost;Port=5432;UserName=postgres;Password=Ab123456!";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.Add(new NpgsqlParameter("Costo", NpgsqlDbType.Money) { Value = sales.Comentarios });
                    command.Parameters.Add(new NpgsqlParameter("PrecioVenta", NpgsqlDbType.Money) { Value = sales.IdUsuario });
                }

                connection.Close();
            }
        }

        public static void UpdateSales(Venta sales)
        {
            var query = @"update coder.Venta
                        set Comentarios = @Comentarios, 
                        IdUsuario = @IdUsuario 
                        where Id = @Id";

            string connectionString = @"Host=localhost;Port=5432;UserName=postgres;Password=Ab123456!";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.Add(new NpgsqlParameter("Comentarios", NpgsqlDbType.Varchar) { Value = sales.Comentarios });
                    command.Parameters.Add(new NpgsqlParameter("IdUsuario", NpgsqlDbType.Money) { Value = sales.IdUsuario });
                }

                connection.Close();
            }
        }

        public static void DeleteSale(Venta sales)
        {
            var query = "Delete FROM coder.Venta where Id = @Id";

            string connectionString = @"Host=localhost;Port=5432;UserName=postgres;Password=Ab123456!";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.Add(new NpgsqlParameter("Id", NpgsqlDbType.Integer) { Value = sales.Id } );       
                }

                connection.Close();
            }
        }

    }
}
    