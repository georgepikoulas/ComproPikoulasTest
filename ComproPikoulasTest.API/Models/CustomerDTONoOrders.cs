using ComproPikoulasTest.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ComproPikoulasTest.API.Models
{
    public class CustomerDTONoOrders
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        
        public string? Phone { get; set; }

       
    }
}
