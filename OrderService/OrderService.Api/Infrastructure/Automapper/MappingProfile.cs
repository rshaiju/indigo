using AutoMapper;
using OrderService.Api.Models;
using OrderService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Infrastructure.Automapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderModel, Order>().ForMember(x => x.OrderState, x => x.MapFrom(src => 1));
        }
    }
}
