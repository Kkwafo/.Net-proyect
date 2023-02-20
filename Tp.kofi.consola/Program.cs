using System.Runtime.CompilerServices;
using TpFinalKofi.AccesodeDatos.Repositories;

namespace Tp.kofi.consola
{
    internal class Program
    {
        public static inMemoryPersonarepository personasInMemory = new();
        static void Main(string[] args)
        {
            MostrarMenu();
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
                        var personas = personasInMemory.GetPersona();
                        Console.WriteLine($"Person List: {election}");
                        foreach (var persona in personas)
                        {
                            Console.WriteLine(persona.ToString());

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
