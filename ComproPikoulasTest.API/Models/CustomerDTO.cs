using ComproPikoulasTest.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ComproPikoulasTest.API.Models
{
    public class CustomerDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        
        public string? Phone { get; set; }

        public int NumberOfOrders
        {
            get
            {
                return Orders.Count;
            }
        }

        public ICollection<OrderDTO>? Orders { get; set; }
            = new List<OrderDTO>();
    }
}
    