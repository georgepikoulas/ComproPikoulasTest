using ComproPikoulasTest.API.Models;
using ComproPikoulasTest.Core;
using AutoMapper;

namespace ComproPikoulasTest.API.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, Models.OrderDTO>();
            CreateMap<Models.OrderDTO, Order>();
        }
    }
}
