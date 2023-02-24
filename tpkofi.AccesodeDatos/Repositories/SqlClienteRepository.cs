using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalKofi.Dominio.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace TpFinalKofi.AccesodeDatos.Repositories
{
    public class SqlClienteRepository : IClienteRepository
    {
        private string connectionString = "Data Source=DESKTOP-0RJ52H8;Initial Catalog=TpKofi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
     
        public List<Cliente> EliminarCliente(string nombre) 
        {
            throw new NotImplementedException();
        }

        public Cliente GetCliente(string nombre)
        {
            var clientes = new List<Cliente>();
            string query = "SELECT * FROM Clientes WHERE Nombre = @Nombre";
            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", nombre);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var cliente = new Cliente
                        {
                            Id = reader.GetInt32(nameof(Cliente.Id)),
                            Nombre = reader.GetFieldValue<string>("Nombre"),
                            Apellido = reader.GetFieldValue<string>("lastname"),
                            Edad = reader.GetFieldValue<int>("Edad"),
                            Email = reader.GetFieldValue<string>("email"),
                            Nacionalidad = reader.GetString(nameof(Cliente.Nacionalidad)),
                            Ciudad = reader.GetString(nameof(Cliente.Ciudad))
                        };
                        if (!reader.IsDBNull(nameof(Cliente.FechaDeNacimiento)))
                        {
                            cliente.FechaDeNacimiento = reader.GetFieldValue<DateTime>(nameof(Cliente.FechaDeNacimiento));
                        }
                        return cliente;
                    }
                }
             
            }
            return null;
        }

    

        public List<Cliente> GetClientes()
        {
            var clientes = new List<Cliente>();
            string query = "SELECT * FROM Clientes";
            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader  = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cliente = new Cliente
                        {
                            Id = reader.GetInt32(nameof(Cliente.Id)),
                            Nombre = reader.GetFieldValue<string>("Nombre"),
                            Apellido = reader.GetFieldValue<string>("lastname"),
                            Edad= reader.GetFieldValue<int>("Edad"),
                            Email = reader.GetFieldValue<string>("email"),
                            Nacionalidad = reader.GetString(nameof(Cliente.Nacionalidad)),
                            Ciudad = reader.GetString(nameof(Cliente.Ciudad))
                    };
                    if (!reader.IsDBNull(nameof(Cliente.FechaDeNacimiento)))
                        {
                            cliente.FechaDeNacimiento = reader.GetFieldValue<DateTime>(nameof(Cliente.FechaDeNacimiento));
                        }
                         
                        clientes.Add(cliente);
                    }
                }
                connection.Close();
            }
            return clientes;
        }

        public List<Cliente> InsertarCliente(Cliente cliente)
        {
            var clientes = new List<Cliente>();
            using (SqlConnection connection = new(connectionString))
            { var query = "INSERT INTO Clientes (Nombre, Apellido, Edad, Ciudad, Nacionalidad, Email, FechaDeNacimiento)" +
                    " VALUES (Nombre, Apellido, Edad, Ciudad, Nacionalidad, Email, FechaDeNacimiento)";
                connection.Open();
                using (SqlCommand command = new SqlCommand( query , connection))
                {
                    command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    command.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                    command.Parameters.AddWithValue("@Edad", cliente.Edad);
                    command.Parameters.AddWithValue("@Ciudad", cliente.Ciudad);
                    command.Parameters.AddWithValue("@Nacionalidad", cliente.Nacionalidad);
                    command.Parameters.AddWithValue("@Email", cliente.Email);
                    command.Parameters.AddWithValue("@FeachaDeNacimiento", cliente.FechaDeNacimiento);
                    command.ExecuteNonQuery();

                }
            } return GetClientes();


        }
        public List<Cliente> ModificarCliente(Cliente nombre)
        {
            throw new NotImplementedException();
        }
    }
}
