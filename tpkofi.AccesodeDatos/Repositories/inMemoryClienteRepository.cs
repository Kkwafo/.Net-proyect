
using System.Globalization;
using TpFinalKofi.Dominio.Models;

namespace TpFinalKofi.AccesodeDatos.Repositories
{
    public class InMemoryClienteRepository : IClienteRepository
    {
        private List<Cliente> clientes;

        public InMemoryClienteRepository(List<Cliente> clientes = null)
        {
            _clientes = clientes ?? new List<Cliente>();
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
            }
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
            Console.WriteLine("Ingrese el nombre del cliente:");
            var nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido del cliente:");
            var apellido = Console.ReadLine();

            Console.WriteLine("Ingrese la edad del cliente:");
            var edadString = Console.ReadLine();
            int edad;
            //valido la edad del wacho
            while (!int.TryParse(edadString, out edad))
            {
                Console.WriteLine("La edad ingresada no es válida. Ingrese un número entero:");
                edadString = Console.ReadLine();
            }

            Console.WriteLine("Ingrese la ciudad del cliente:");
            var ciudad = Console.ReadLine();

            Console.WriteLine("Ingrese el email del cliente:");
            var email = Console.ReadLine();

            Console.WriteLine("Ingrese la nacionalidad del cliente:");
            var nacionalidad = Console.ReadLine();

            Console.WriteLine("Ingrese la fecha de nacimiento del cliente (formato dd/mm/yyyy):");
            var fechaNacimientoString = Console.ReadLine();
            DateTime fechaNacimiento;
            //valido cuando nacio --> no quiero leer mas documentacion
            while (!DateTime.TryParseExact(fechaNacimientoString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaNacimiento))
            {
                Console.WriteLine("La fecha ingresada no es válida. Ingrese una fecha en formato dd/mm/yyyy:");
                fechaNacimientoString = Console.ReadLine();
            }

            var clienteNuevo = new Cliente()
            {
                
                Nombre = nombre,
                Apellido = apellido,
                Edad = edad,
                Ciudad = ciudad,
                Email = email,
                Nacionalidad = nacionalidad,
                FechaDeNacimiento = fechaNacimiento
            };

            var clienteRepository = new InMemoryClienteRepository();
            clienteRepository.InsertarCliente(clienteNuevo);
            Clientes.Add(clienteNuevo);
            Console.WriteLine("Cliente creado exitosamente. Presione una tecla para continuar...");
            Console.ReadKey();
        }


    }
}