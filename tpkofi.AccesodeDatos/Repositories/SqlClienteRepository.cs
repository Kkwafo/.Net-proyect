using Microsoft.Data.SqlClient;
using TpFinalKofi.Dominio.Models;
namespace TpFinalKofi.AccesodeDatos.Repositories
{
    public class SqlClienteRepository : IClienteRepository
    {
        private string connectionString = "Data Source=DESKTOP-0RJ52H8;Initial Catalog=TpKofi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private const string GetClienteQuery = "SELECT * FROM Clientes WHERE Nombre = @Nombre";
        private const string GetClientesQuery = "SELECT * FROM Clientes";

        public void EliminarCliente(int id)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Cliente WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result < 1)
                    {
                        Console.WriteLine("No se encontró ningún registro para eliminar");
                    }
                    else
                    {
                        Console.WriteLine("Se eliminó correctamente el registro con Id {0}", id);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar el registro con Id {0}: {1}", id, ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public Cliente GetCliente(string nombre)
        {
            using var connection = new SqlConnection(connectionString);

            var command = new SqlCommand(GetClienteQuery, connection);
            command.Parameters.AddWithValue("@nombre", nombre);

            connection.Open();

            var reader = command.ExecuteReader();

            if (!reader.Read())
            {
                return null;
            }

            var cliente = new Cliente
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                Apellido = reader.GetString(reader.GetOrdinal("Apellido")),
                Edad = reader.GetInt32(reader.GetOrdinal("Edad")),
                Ciudad = reader.GetString(reader.GetOrdinal("Ciudad")),
                Nacionalidad = reader.GetString(reader.GetOrdinal("Nacionalidad")),
                Email = reader.GetString(reader.GetOrdinal("Email")),
                FechaDeNacimiento = reader.GetDateTime(reader.GetOrdinal("FechaDeNacimiento"))
            };

            return cliente;
        }



        public List<Cliente> GetClientes()
        {
            var clientes = new List<Cliente>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(GetClientesQuery, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var cliente = new Cliente()
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        Edad = (int)reader["Edad"],
                        Ciudad = reader["Ciudad"].ToString(),
                        Email = reader["Email"].ToString(),
                        Nacionalidad = reader["Nacionalidad"].ToString(),
                        FechaDeNacimiento = (DateTime)reader["FechaDeNacimiento"]
                    };

                    clientes.Add(cliente);
                }
            }

            return clientes;
        }

        public void InsertarCliente(Cliente cliente)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Clientes (Apellido, Nombre, Ciudad, Edad, Email, Nacionalidad, FechaDeNacimiento) " +
                                   "VALUES (@Apellido, @Nombre, @Ciudad, @Edad, @Email, @Nacionalidad, @FechaDeNacimiento)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                    command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    command.Parameters.AddWithValue("@Ciudad", cliente.Ciudad);
                    command.Parameters.AddWithValue("@Edad", cliente.Edad);
                    command.Parameters.AddWithValue("@Email", cliente.Email);
                    command.Parameters.AddWithValue("@Nacionalidad", cliente.Nacionalidad);
                    command.Parameters.AddWithValue("@FechaDeNacimiento", cliente.FechaDeNacimiento);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 1)
                    {
                        Console.WriteLine("El cliente se ha insertado correctamente en la base de datos.");
                    }
                    else
                    {
                        Console.WriteLine("No se ha podido insertar el cliente en la base de datos.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error al insertar el cliente en la base de datos: " + ex.Message);
            }
        }

        public void ModificarCliente(int id, Cliente cliente)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Clientes SET Nombre = @Nombre, Apellido = @Apellido, Ciudad = @Ciudad, " +
                               "Edad = @Edad, Email = @Email, Nacionalidad = @Nacionalidad, FechaDeNacimiento = @FechaDeNacimiento " +
                               "WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                command.Parameters.AddWithValue("@Ciudad", cliente.Ciudad);
                command.Parameters.AddWithValue("@Edad", cliente.Edad);
                command.Parameters.AddWithValue("@Email", cliente.Email);
                command.Parameters.AddWithValue("@Nacionalidad", cliente.Nacionalidad);
                command.Parameters.AddWithValue("@FechaDeNacimiento", cliente.FechaDeNacimiento);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Cliente modificado correctamente.");
                }
                else
                {
                    Console.WriteLine($"No se encontró un cliente con el ID {id}.");
                }
            }
        }


    }
}
