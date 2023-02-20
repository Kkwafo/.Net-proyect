using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalKofi.Dominio.Models;
using Microsoft.Data.SqlClient;


namespace TpFinalKofi.AccesodeDatos.Repositories
{
    public class SqlPersonaRepository : IPersonaRepository
    {
        private string connectionString = "Data Source=DESKTOP-0RJ52H8;Initial Catalog=TpKofi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private connString =     
        public List<Persona> EliminarPersona(string nombre) 
        {
            throw new NotImplementedException();
        }

        public Persona GetPersona(string nombre)
        {
            throw new NotImplementedException();
        }

        public List<Persona> GetPersona()
        {
            var personas = new List<Persona>();
            string query = "SELECT * FROM Personas";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader  = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Persona persona = new Persona();
                    }
                }
                connection.Close();
            }
            return personas;
        }

        public List<Persona> ModificarPersona(Persona nombre)
        {
            throw new NotImplementedException();
        }
    }
}
