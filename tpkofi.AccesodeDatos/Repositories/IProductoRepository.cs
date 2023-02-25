using System.Collections.Generic;
using TpFinalKofi.Dominio.Models;

namespace TpFinalKofi.Dominio.Interfaces
{
    public interface IProductoRepository
    {
        Producto GetById(int id);
        IEnumerable<Producto> GetAll();
        void InsertarProducto(Producto producto);
        void ActualizarProducto(Producto producto);
        void EliminarProducto(int id);
    }
}