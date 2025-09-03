using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace technical__test
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Identity autonumérico
        public int ProductoID { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; }

        [Required]
        public int Codigo { get; set; }

        [MaxLength(500)]
        public string Descripcion { get; set; }

        [Required]
        public decimal PrecioUnitario { get; set; }

        [Required]
        public int Stock { get; set; }

        [MaxLength(100)]
        public string Categoria { get; set; }

        [MaxLength(150)]
        public string Proveedor { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Required]
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}

