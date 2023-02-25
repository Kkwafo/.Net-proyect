using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TpFinalKofi.Dominio.Interfaces;
using TpFinalKofi.Dominio.Models;

namespace TpFinalKofi.Dominio.Repositories
{
    public class InMemoryProductoRepository : IProductoRepository
    {
        private readonly List<Producto> productos;
        

        public InMemoryProductoRepository(List<Producto> listaDeProductos)
        {
            this.productos = listaDeProductos;
        }

        public InMemoryProductoRepository()
        {

            productos = new List<Producto>()
            {
                new Producto
                {
                    Id = 1,
                    Name = "Fernet",
                    Price = "100",
                    Description = "70-30 con coca pa"
                }
            };
        }

        public Producto GetById(int id)
        {
            return productos.FirstOrDefault(p => p.Id.Equals(id));
        }

        public IEnumerable<Producto> GetAll()
        {
            return productos;
        }

        public void InsertarProducto(Producto producto)
        {
            if (producto == null)
            {
                throw new ArgumentNullException(nameof(producto));
            }

            producto.Id = productos.Any() ? productos.Max(p => p.Id) + 1 : 1.ToString(); ;
            productos.Add(producto);
        }

        public void ActualizarProducto(Producto producto)
        {
            if (producto == null)
            {
                throw new ArgumentNullException(nameof(producto));
            }

            var productoExistente = productos.FirstOrDefault(p => p.Id == producto.Id);

            if (productoExistente == null)
            {
                throw new InvalidOperationException("El producto no existe.");
            }

            productoExistente.Name = producto.Name;
            productoExistente.Description = producto.Description;
            productoExistente.Price = producto.Price;
        }

        public void EliminarProducto(int id)
        {
            var productoExistente =  productos.FirstOrDefault(p => p.Id.Equals(id)); ;

            if (productoExistente == null)
            {
                throw new InvalidOperationException("El producto no existe.");
            }

            productos.Remove(productoExistente);
        }
    }
}