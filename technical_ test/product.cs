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
        public int ProductID { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        public int Code { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public decimal UnitaryPrice { get; set; }

        [Required]
        public int Stock { get; set; }

        [MaxLength(100)]
        public string Category { get; set; }

        [MaxLength(150)]
        public string Supplier { get; set; }

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime ModificationDate { get; set; } = DateTime.Now;
    }
}

