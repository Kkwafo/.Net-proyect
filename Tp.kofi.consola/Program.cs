using System.Runtime.CompilerServices;
using TpFinalKofi.AccesodeDatos.Repositories;
using TpFinalKofi.Dominio.Models;

namespace Tp.kofi.consola
{
    internal class Program
    {
        public static InMemoryClienteRepository clienteInMemory = new();
        

        static void Main(string[] args)
        {
            /*MostrarMenu()*/;

            var sqlRepository = new SqlClienteRepository();

            var clientes = sqlRepository .GetClientes();
            var cliente = sqlRepository.GetCliente("Kofi");

            Console.WriteLine("Get Cliente");
            foreach (var item in clientes)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Get Cliente");
            Console.WriteLine(cliente.ToString());

            var clienteNuevo = new Cliente
            {
                Id = 1,
                Apellido = "Kwafo Awua",
                Nombre = "Kofi",
                Ciudad = "Cordoba",
                Edad = 30,
                Email = "kofikwafoawua@gmail.com",
                Nacionalidad = "Argentina",
                FechaDeNacimiento = DateTime.Now
            };
            clientes = sqlRepository.InsertarCliente(clienteNuevo);
            Console.WriteLine("Get New Client");
            foreach(var item in clientes)
            {
                Console.WriteLine(item.ToString());
            }
            }
        }


        private static void MostrarMenu()
        {
            string? resp;
            do
            {
                string menu = "1: Person Create \n" +
                              "2: Show Person \n" +
                              "3: Show all Persons \n" +
                               "4: Exit \n";

                Console.WriteLine(menu);
                Console.WriteLine("Choose any Option");
                resp = Console.ReadLine();
                string? election = Convert.ToString(resp);

                Console.WriteLine();

                switch (election)
                {
                    case "1":
                        Console.WriteLine($"You select: {election}");
                        break;
                    case "2":
                        Console.WriteLine($"You select: {election}");
                        break;
                    case "3":
                        Console.WriteLine($"You select: {election}");
                         var clientes = clienteInMemory.GetCliente();
                        Console.WriteLine($"Person List: {election}");
                        foreach (var cliente in clientes)
                        {
                            Console.WriteLine(cliente.ToString());

                        }
                        break;
                    case "4":
                        Console.WriteLine($"You select: {election}");
                        break;

                    default:                   
                        Console.WriteLine($"Wrong Selection");
                        break;     
                }
            }
            while (resp != "4");
             
            } 
        }
    }
