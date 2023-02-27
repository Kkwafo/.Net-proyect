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

 

            private List<Producto> Productos = new()
            {
                new Producto
                {
                    Id = 1,
                    Name = "Fernet",
                    Price = "100",
                    Description = "70-30 con coca pa"
                },
                new Producto
                {
                    Id = 2,
                    Name = "sixpack",
                    Price = "200",
                    Description = "es domingo y aun no tome uno"
                }
            };
        

        public Producto GetById(int id)
        {
            return Productos.FirstOrDefault(p => p.Id.Equals(id)); //para el error CS0029 le pondri un .toString
        }

        public List<Producto> GetProductos()
        {
            return Productos;
        }

        public void InsertarProducto(Producto producto)
        {
            if (producto == null)
            {
                throw new ArgumentNullException(nameof(producto));
            }

            producto.Id = productos.Any() ? productos.Max(p => p.Id) + 1 : 1 ;
            Productos.Add(producto);
        }

        public void ActualizarProducto(Producto producto)
        {
            if (producto == null)
            {
                throw new ArgumentNullException(nameof(producto));
            }

            var productoExistente = Productos.FirstOrDefault(p => p.Id == producto.Id);

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
            var productoExistente =  Productos.FirstOrDefault(p => p.Id.Equals(id)); ;

            if (productoExistente == null)
            {
                throw new InvalidOperationException("El producto no existe.");
            }

            Productos.Remove(productoExistente);
        }
    }
}