
using TpFinalKofi.Dominio.Models;

namespace TpFinalKofi.AccesodeDatos.Repositories
{
    public interface IClienteRepository
    {
        void InsertarCliente(Cliente cliente);
        void ModificarCliente(int id, Cliente clienteModificar);
        void EliminarCliente(int id);
        List<Cliente> GetClientes();

    }
}
