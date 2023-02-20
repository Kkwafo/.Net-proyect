using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalKofi.Dominio.Models;

namespace TpFinalKofi.AccesodeDatos.Repositories
{
    public interface IPersonaRepository
    {
        Persona GetPersona(string nombre);
       public List<Persona> GetPersona();
        List<Persona> EliminarPersona(string nombre);
        List<Persona> ModificarPersona(Persona nombre);

    }
}
