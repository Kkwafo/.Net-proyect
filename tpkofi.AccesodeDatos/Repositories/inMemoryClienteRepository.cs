using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TpFinalKofi.Dominio.Models;


namespace TpFinalKofi.AccesodeDatos.Repositories
{
    public class InMemoryClienteRepository : IClienteRepository
    {
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
            }
            };

        public List<Cliente> EliminarCliente(string nombre)
        {
            foreach (var cliente in Clientes)
            {
                if (cliente.Nombre == nombre)
                {
                    Clientes.Remove(cliente);
                }
            }
            //ver el return
                return null;
                
        }

        public Cliente GetCliente(string nombre)
        {
            Cliente clienteResult = null;
            foreach (var cliente in Clientes)
            {
                if (cliente.Nombre == nombre)
                {
                    clienteResult = cliente;
                }
            }
            return clienteResult;
        }

        public List<Cliente> GetCliente()
        {
            return Clientes;
        }

        public List<Cliente> ModificarCLiente(Cliente nombre)
        {
            Cliente? clienteEncontrado = null;
            foreach (var c in Clientes)
            {
                if (c.Nombre == Clientes.Nombre)
                {
                    clienteEncontrado = c;
                    break;
                }
            }
            if (clienteEncontrado != null)
            {
                Clientes.Remove(clienteEncontrado);
                 return InsertarCliente(cliente);
            }
        return Clientes;
        }

        public List<Cliente> InsertarCliente(Cliente cliente)
        {
            Clientes.Add(cliente);
            return Clientes;
        }
    }


}
