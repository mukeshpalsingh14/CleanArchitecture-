using AutoMapper;
using Order.Application.Dtos;
using Order.Application.Dtos.Order;
using Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Mapper
{
    public class OrderProfile :Profile
    {
        public OrderProfile()
        {
           // CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, ProductsDTO>().ReverseMap();
            CreateMap<Orders, OrderDTO>().ReverseMap();
            CreateMap<Orders, OrdersDTO>().ReverseMap();
            CreateMap<Orders, OrdersDTO>().ForMember(dst => dst.FirstName,
        opt => opt.MapFrom(src => src.UserInfo.FirstName)).ReverseMap();
            CreateMap<Orders, OrdersDTO>().ForMember(dst => dst.ProductName,
        opt => opt.MapFrom(src => src.ProductType.ProductName)).ReverseMap();
        }
    }
}
