using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Examen.Models
{
    public class Cuenta
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Categoria { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public decimal Saldo { get; set; }
        public decimal Limite { get; set; }
        public List<Detalle> Detalles { get; set; }
    }
}
