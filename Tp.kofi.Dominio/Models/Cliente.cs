using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalKofi.Dominio.Models
{
    public class Cliente
    {
        public int Edad { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int? Id { get; set; }
        public string? Nacionalidad { get; set; }
        public string? Email { get; set; }
        public string? Ciudad { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public override string ToString()
        {
            return $"Nombre: {Nombre} - Edad: {Edad} - FechaNacimiento: {FechaDeNacimiento}";
        }

    }
}