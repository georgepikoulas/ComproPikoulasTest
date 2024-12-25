using AutoMapper;
using ComproPikoulasTest.API.Models;
using ComproPikoulasTest.Core;


namespace ComproPikoulasTest.API.Profiles
{
    public class CustomerProfile : Profile
    {

        public CustomerProfile()
        {
            CreateMap<Customer, Models.CustomerDTO>();
            CreateMap< Models.CustomerDTO , Customer>();
            CreateMap<Customer, Models.CustomerDTONoOrders>();
            CreateMap<Models.CustomerDTONoOrders, Customer>();
            

        }
    }
}
