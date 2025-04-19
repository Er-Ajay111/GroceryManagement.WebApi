using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GroceryManagement.DB.Models;
using GroceryManagement.Dtos;

namespace GroceryManagement.BL.Utility
{
    public class GroceryMappingProfile : Profile
    {
        public GroceryMappingProfile()
        {
            CreateMap<Category, CategoryDto>()
                 .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Name))
                 .ReverseMap();

            CreateMap<Items, ItemsDto>()
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<Stocks, StocksDto>().ReverseMap();

            CreateMap<Customers,CustomersDto>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CustomerAddress, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.CustomerEmailId, opt => opt.MapFrom(src => src.EmailId))
                .ForMember(dest => dest.CustomerPhoneNo, opt => opt.MapFrom(src => src.PhoneNo))
                .ReverseMap();

            CreateMap<Orders, OrdersDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest=>dest.OrderItemsDto,opt=>opt.MapFrom(src=>src.OrderItems))
                .ReverseMap();

            CreateMap<OrderItems, OrderItemsDto>().ReverseMap();
        }
    }
}
