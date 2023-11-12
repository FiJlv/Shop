using AutoMapper;
using Shop.BLL.DTO;
using Shop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Mapping
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<OrderDTO, Order>().ReverseMap();
        }
    }
}
