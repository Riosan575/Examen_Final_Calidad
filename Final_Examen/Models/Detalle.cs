using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Examen.Models
{
    public class Detalle
    {
        public int Id { get; set; }
        public int IdCuenta { get; set; }        
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public decimal Monto { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Categoria { get; set; }
    }
}
