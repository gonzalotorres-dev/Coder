using MiProyecto;
using Npgsql;
using NpgsqlTypes;
using System;

namespace AppClientesData
{
    public class UsersData
    {
        public static Usuario GetUserById(int IdUser)
        {
            Usuario userList = new Usuario();

            var query = "Select Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail FROM coder.Usuario where Id = @IdUser";

            string connectionString = @"Host=localhost;Port=5432;UserName=postgres;Password=Ab123456!";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection)) 
                {
                    var param = new NpgsqlParameter();
                    param.ParameterName = "IdUser";
                    param.NpgsqlDbType = NpgsqlDbType.Integer;
                    param.Value = IdUser;

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows != null)
                        {
                            while (reader.Read()) 
                            {
                                var user = new Usuario();

                                user.Id = Convert.ToInt32(reader["Id"]);
                                user.Apellido = reader["Apellido"].ToString();
                                user.Nombre = reader["Nombre"].ToString();
                                user.NombreUsuario = reader["NombreUsuario"].ToString();
                                user.Contraseña = reader["Contraseña"].ToString();
                                user.Mail = reader["Mail"].ToString();
                            }
                        }
                    }
                }
            }

            return userList;
        }

        public static List<Usuario> GetUserList()
        {
            List<Usuario> userList = new List<Usuario>();

            var query = "Select Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail FROM coder.Usuario";
    
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
                                var user = new Usuario();

                                user.Id = Convert.ToInt32(reader["Id"]);
                                user.Apellido = reader["Apellido"].ToString();
                                user.Nombre = reader["Nombre"].ToString();
                                user.NombreUsuario = reader["NombreUsuario"].ToString();
                                user.Contraseña = reader["Contraseña"].ToString();
                                user.Mail = reader["Mail"].ToString();

                                userList.Add(user);
                            }
                        }
                    }
                }
            }

            return userList;
        }

        public static void CreateUser(Usuario user)
        {
            var query = @"insert into coder.Usuario (Nombre, Apellido, NombreUsuario, Contraseña, Mail)
                values(@Nombre, @Apellido, @NombreUsuario, @Contraseña, @Mail)";

            string connectionString = @"Host=localhost;Port=5432;UserName=postgres;Password=Ab123456!";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.Add(new NpgsqlParameter("Nombre", NpgsqlDbType.Varchar) { Value = user.Nombre });
                    command.Parameters.Add(new NpgsqlParameter("Apellido", NpgsqlDbType.Money) { Value = user.Apellido });
                    command.Parameters.Add(new NpgsqlParameter("NombreUsuario", NpgsqlDbType.Money) { Value = user.NombreUsuario });
                    command.Parameters.Add(new NpgsqlParameter("Contraseña", NpgsqlDbType.Integer) { Value = user.Contraseña });
                    command.Parameters.Add(new NpgsqlParameter("Mail", NpgsqlDbType.Varchar) { Value = user.Mail });
                }

                connection.Close();
            }
        }

        public static void UpdateUser(Usuario user)
        {
            var query = @"update coder.Usuario
                        set Nombre = @Nombre, 
                        Apellido = @Apellido, 
                        NombreUsuario = @NombreUsuario, 
                        Contraseña = @Contraseña, 
                        Mail = @Mail 
                        where Id = @Id";

            string connectionString = @"Host=localhost;Port=5432;UserName=postgres;Password=Ab123456!";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.Add(new NpgsqlParameter("Nombre", NpgsqlDbType.Varchar) { Value = user.Nombre });
                    command.Parameters.Add(new NpgsqlParameter("Apellido", NpgsqlDbType.Money) { Value = user.Apellido });
                    command.Parameters.Add(new NpgsqlParameter("NombreUsuario", NpgsqlDbType.Money) { Value = user.NombreUsuario });
                    command.Parameters.Add(new NpgsqlParameter("Contraseña", NpgsqlDbType.Integer) { Value = user.Contraseña });
                    command.Parameters.Add(new NpgsqlParameter("Mail", NpgsqlDbType.Varchar) { Value = user.Mail });
                }

                connection.Close();
            }
        }

        public static void DeleteUser(Usuario user)
        {
            var query = "Delete FROM coder.Usuario where Id = @Id";

            string connectionString = @"Host=localhost;Port=5432;UserName=postgres;Password=Ab123456!";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.Add(new NpgsqlParameter("Id", NpgsqlDbType.Integer) { Value = user.Id } );       
                }

                connection.Close();
            }
        }

    }
}
    