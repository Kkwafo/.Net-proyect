using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TpFinalKofi.Dominio.Models
{
    public class Producto
    {
        private string Id { get; set; }
        private string ?Name{ get; set; }
        private string ?Description { get; set; }
        private string ?Price { get; set; }

    }
}