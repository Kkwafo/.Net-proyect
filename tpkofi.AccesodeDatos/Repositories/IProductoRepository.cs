using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalKofi.Dominio.Models;

namespace TpFinalKofi.AccesodeDatos.Repositories
{
    public interface IProductoRepository
    {
        Cliente GetProducto(string nombre);
        public List<Cliente> GetProducto();
        List<Cliente> EliminarProducto(string nombre);
        List<Cliente> ModificarProducto(Cliente nombre);

    }
}
