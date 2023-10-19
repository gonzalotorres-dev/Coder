using Npgsql;
using NpgsqlTypes;
using SistemaGestionData;
using SistemaGestionEntities;

namespace AppClientesData
{
    public class SalesData : ISalesRepository
    {
        public VentaDto GetSalesById(int IdSales)
        {
            VentaDto salesList = new VentaDto();

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
                                var sale = new VentaDto();

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

        public List<VentaDto> GetSalesList()
        {
            List<VentaDto> salesList = new List<VentaDto>();

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
                                var sale = new VentaDto();

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

        public void CreateSales(VentaDto sales)
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

        public void UpdateSales(VentaDto sales)
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

        public void DeleteSale(VentaDto sales)
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
    