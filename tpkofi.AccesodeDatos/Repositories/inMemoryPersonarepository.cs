using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TpFinalKofi.Dominio.Models;

namespace TpFinalKofi.AccesodeDatos.Repositories
{
    public class inMemoryPersonarepository : IPersonaRepository
    {
        private List<Persona> Personas = new()
        {
            new Persona
            {
            Altura= 1.76m,
            Nombre= "Kofi",
            Apellido="Kwafo Awua",
            Ciudad="Cordoba",
            Edad= 30,
            Email= "kofikwafoawua@gmail.com",
            Nacionalidad="Argentina",
            FechaDeNacimiento=  DateTime.Now
            }
            };

        public List<Persona> EliminarPersona(string nombre)
        {
            foreach (var persona in Personas)
            {
                if (persona.Nombre == nombre)
                {
                    Personas.Remove(persona);
                }
            }
        }

        public Persona GetPersona(string nombre)
        {
            Persona personaResult = null;
            foreach (var personas in Personas)
            {
                if (persona.Nombre = nombre)
                {
                    personaResult = persona;
                }
            }
            return personaResult;
        }

        public List<Persona> GetPersona()
        {
            return Personas;
        }

        public List<Persona> ModificarPersona(Persona persona)
        {
            Persona? personaEncontrada = null;
            foreach (var p in Personas)
            {
                if (p.Nombre == persona.Nombre)
                {
                    personaEncontrada = p;
                    break;
                }
            }
            if (personaEncontrada != null)
            {
                Personas.Remove(personaEncontrada);
                 return InsertarPersona(persona);
            }
        return Personas;
        }

        public List<Persona> InsertarPersona(Persona persona)
        {
            Personas.Add(persona);
            return Personas;
        }
    }


}
