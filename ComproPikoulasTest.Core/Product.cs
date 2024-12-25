using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComproPikoulasTest.Core
{
    public class Product
    {
        public int ID { get; set; }
        [StringLength(150)]
        [Required]
        public string Name { get; set; }

        

        public string? Description { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public bool Availability { get; set; }

        public virtual List<Order>? Orders { get; set; }

    }
}
