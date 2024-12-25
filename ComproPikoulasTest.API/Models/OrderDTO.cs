using ComproPikoulasTest.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ComproPikoulasTest.API.Models
{
    public class OrderDTO
    {
        public int ID { get; set; }
        public List<Product>? Products { get; set; }


        public int TotalCost { get; set; }

        public DateTime OrderDate { get; set; }
        [StringLength(20)]
        public string? Status { get; set; }
    }
}
