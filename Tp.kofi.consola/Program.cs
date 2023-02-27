using System.Globalization;
using TpFinalKofi.AccesodeDatos.Repositories;
using TpFinalKofi.Dominio.Models;
using TpFinalKofi.Dominio.Repositories;




//Empece con lo que hacamos en Clases de Personas, Luego lei la cosnigna y era Clientes y Productos... Luego Relei la consigna e hice todo mal
//Tenia que hacer registro de productos termine haciendo registro de clientes....
//Ya estoy muy sobre la fecha y no llego a modificar el codigo ni mucho menos empezar uno nuevo.
namespace Tp.kofi.consola
{
    class Program
    {
        static void Main(string[] args)
        {


            var clientesRepo = new InMemoryClienteRepository();

            var listaDeProductos = new List<Producto>();
            var productosRepo = new InMemoryProductoRepository(listaDeProductos);

             void  agregarCliente()
            {
                Console.Clear();
                var nuevoCliente = new Cliente();
                Console.WriteLine("Registrar nuevo cliente");
                Console.Write("Ingrese el nombre del cliente: ");
                nuevoCliente.Nombre = Console.ReadLine();
                Console.Write("Ingrese el apellido del cliente: ");
                nuevoCliente.Apellido = Console.ReadLine();
                Console.Write("Ingrese la ciudad del cliente: ");
                nuevoCliente.Ciudad = Console.ReadLine();
                Console.Write("Ingrese la edad del cliente: ");
                nuevoCliente.Edad = int.Parse(Console.ReadLine());
                Console.Write("Ingrese el email del cliente: ");
                nuevoCliente.Email = Console.ReadLine();
                Console.Write("Ingrese la nacionalidad del cliente: ");
                nuevoCliente.Nacionalidad = Console.ReadLine();

                Console.Write("Ingrese la fecha de nacimiento del cliente (en formato dd/mm/yyyy): ");
                nuevoCliente.FechaDeNacimiento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);

                clientesRepo.InsertarCliente(nuevoCliente);

                Console.WriteLine("Cliente registrado exitosamente.");
            }
            

            Console.Clear();
            Console.WriteLine("Entraste al sistema de gestion de Clientes-productos");
            Console.WriteLine("===============================================================================================");
            Console.WriteLine("1. Registrar un nuevo cliente");
            Console.WriteLine("2. Ver todos los clientes");
            Console.WriteLine("3. Modificar un cliente");
            Console.WriteLine("4. Ver Productos");
            Console.WriteLine("5. Modificar un Producto");
            Console.WriteLine("6. Salir del programa");
            Console.WriteLine("===============================================================================================");
            Console.Write("Seleccione una opción: ");

            int opcion ;
            do {
            int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1:

                        {
                            agregarCliente();

                        }
                        break; 
                        

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Lista de clientes registrados");

                        var clientes1 = clientesRepo.GetClientes();
                        foreach (var cliente in clientes1)
                        {
                            Console.WriteLine(" Nombre de Cliente: {0} {1}, de la ciudad de ({2}), ({3}) Edad: ({4})", cliente.Nombre, cliente.Apellido, cliente.Ciudad, cliente.Nacionalidad, cliente.Edad);
                        }
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Modificar un cliente");

                        Console.Write("Ingrese el Nombre del cliente a modificar: ");
                        var NombreModificador = Console.ReadLine();

                        var clienteModificar = clientesRepo.GetCliente(NombreModificador);

                        if (clienteModificar != null)
                        {
                            Console.Write("Nuevo nombre (anterior: {0}): ", clienteModificar.Nombre);
                            var nuevoNombre = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nuevoNombre))
                            {
                                clienteModificar.Nombre = nuevoNombre;
                            }

                            Console.Write("Nuevo apellido (anterior: {0}): ", clienteModificar.Apellido);
                            var nuevoApellido = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nuevoApellido))
                            {
                                clienteModificar.Apellido = nuevoApellido;
                            }

                            Console.Write("Nueva ciudad (anterior: {0}): ", clienteModificar.Ciudad);
                            var nuevaCiudad = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nuevaCiudad))
                            {
                                clienteModificar.Ciudad = nuevaCiudad;
                            }

                            clientesRepo.ModificarCliente(clienteModificar.Id.Value, clienteModificar);
                            Console.WriteLine("Cliente modificado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("El cliente no existe.");
                        }

                        break;

                    case 4:
                        // Ver todos los productos
                        Console.Clear();
                        Console.WriteLine("Lista de productos registrados");


                        var producto = productosRepo.GetProductos(); 
                        foreach (var productos in producto)
                        {
                            Console.WriteLine(" Producto: {0}, Precio: {1}, Detalle: {2}", productos.Name, productos.Price, productos.Description);
                        }
                        break;

                    case 5:
                        // Modificar un producto
                        Console.Clear();
                        Console.WriteLine("Modificar un producto");

                        Console.Write("Ingrese el ID del producto a modificar: ");
                        var idProductoModificador = int.Parse(Console.ReadLine());

                        var productoModificar = productosRepo.GetById(idProductoModificador);

                        if (productoModificar != null)
                        {
                            Console.Write("Nuevo nombre (anterior: {0}): ", productoModificar.Name);
                            var nuevoNombre = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nuevoNombre))
                            {
                                productoModificar.Name = nuevoNombre;
                            }

                            Console.Write("Nueva descripción (anterior: {0}): ", productoModificar.Description);
                            var nuevaDescripcion = Console.ReadLine();
                            if (!string.IsNullOrEmpty(nuevaDescripcion))
                            {
                                productoModificar.Description = nuevaDescripcion;
                            }

                            Console.Write("Nuevo precio (anterior: {0}): ", productoModificar.Price);
                            var nuevoPrecio = decimal.Parse(Console.ReadLine());
                            productoModificar.Price = nuevoPrecio.ToString();

                            productosRepo.ActualizarProducto(productoModificar);
                            Console.WriteLine("Producto modificado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("El producto no existe.");
                        }

                        break;

                    case 6:
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Entraste al sistema de gestion de Clientes-productos");
                        Console.WriteLine("===============================================================================================");
                        Console.WriteLine("1. Registrar un nuevo cliente");
                        Console.WriteLine("2. Ver todos los clientes");
                        Console.WriteLine("3. Modificar un cliente");
                        Console.WriteLine("4. Ver Productos");
                        Console.WriteLine("5. Modificar un Producto");
                        Console.WriteLine("6. Salir del programa");
                        Console.WriteLine("===============================================================================================");
                        Console.Write("Seleccione una opción: ");
                        break;

                }
            }                             
            while (opcion != 6);             
        }
    }

}