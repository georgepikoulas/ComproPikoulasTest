using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ComproPikoulasTest.Core
{
    public class Order
    {
        public int ID { get; set; }
        [JsonIgnore]

        public List<Product>? Products { get; set; }

        [Range(1, double.MaxValue)]
        
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]

        public decimal TotalCost { get; set; }

        public DateTime OrderDate { get; set; }
        [StringLength(20)]
        public string? Status { get; set; }
        [JsonIgnore]
        public virtual  Customer? Customer { get; set; }

        public int? CustomerId { get; set; }


    }
}
