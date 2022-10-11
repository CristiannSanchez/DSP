using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PStudent.BL.PagModelo
{
    public class DetalleDeContacto
    {
        public int Id { get; set; }
        [Required]
        public string? Nombres { get; set; }
        [Required]
        public string? Apellidos { get; set; }
        [Required]
        public DateTime FehcaDeNacimiento { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public int Telefono { get; set; }
    }
}
