using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalKofi.Dominio.Models;

namespace TpFinalKofi.AccesodeDatos.Repositories
{
    public interface IClienteRepository
    {
     public  Cliente GetCliente(string nombre);
     public List<Cliente> GetClientes();
     public  List<Cliente> EliminarCliente(string nombre);
     public List<Cliente> ModificarCliente(Cliente nombre);
     public List<Cliente> InsertarCliente(Cliente cliente);

    }
}
