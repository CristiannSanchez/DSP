using System;
using System.Collections.Generic;

namespace PStudent.DAL.Entities
{
    public partial class Registro
    {
        public int Id { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public DateTime? FehcaDeNacimiento { get; set; }
        public string? Email { get; set; }
        public int? Telefono { get; set; }
    }
}
