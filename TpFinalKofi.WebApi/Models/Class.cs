namespace TpFinalKofi.WebApi.Models
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
                return $"Id {Id} -  Nombre: {Nombre} - Edad: {Edad} - FechaNacimiento: {FechaDeNacimiento}";
            }

        }
    
}
