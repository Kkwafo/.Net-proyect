
using System.Globalization;
using TpFinalKofi.Dominio.Models;

namespace TpFinalKofi.AccesodeDatos.Repositories
{
    public class InMemoryClienteRepository : IClienteRepository
    {
      

        public InMemoryClienteRepository(List<Cliente>? clientes = null)
        {
           var _clientes = clientes ?? new List<Cliente>();
        }

        private List<Cliente> Clientes = new()
        {
            new Cliente
            {
                Id = 1,
                Apellido="Kwafo Awua",
                Nombre= "Kofi",
                Ciudad="Cordoba",
                Edad= 30,
                Email= "kofikwafoawua@gmail.com",
                Nacionalidad="Argentina",
                FechaDeNacimiento=  DateTime.Now
            },
            new Cliente 
            {
                Id = 2,
                Apellido="De los Palotes",
                Nombre= "Juan",
                Ciudad="Cordoba",
                Edad= 54,
                Email= "algunmail@gmail.com",
                Nacionalidad="Argentina",
                FechaDeNacimiento=  DateTime.Now
            },

        };

        public void EliminarCliente(int id)
        {
            var cliente = Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                Clientes.Remove(cliente);
            }
        }

        public Cliente GetCliente(string nombre)
        {
            Cliente? clienteResult = null;
            foreach (var cliente in Clientes)
            {
                if (cliente.Nombre == nombre)
                {
                    clienteResult = cliente;
                }
            }
            return clienteResult;
        }

        public List<Cliente> GetClientes()
        {
            return Clientes;
        }

        public void ModificarCliente(int id, Cliente clienteModificar)
        {
            var clienteEncontrado = Clientes.FirstOrDefault(c => c.Id == id);
            if (clienteEncontrado != null)
            {
                clienteEncontrado.Nombre = clienteModificar.Nombre;
                clienteEncontrado.Apellido = clienteModificar.Apellido;
                clienteEncontrado.Edad = clienteModificar.Edad;
                clienteEncontrado.Email = clienteModificar.Email;
                clienteEncontrado.Nacionalidad = clienteModificar.Nacionalidad;
                clienteEncontrado.FechaDeNacimiento = clienteModificar.FechaDeNacimiento;
            }
        }

        public void InsertarCliente(Cliente cliente)
        {
            
            Clientes.Add(cliente);

        }


    }
}