using AutoMapper;
using CustomerService.Api.Models.v1;
using CustomerService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.Api.Infrastructure.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCustomerModel, Customer>().ForMember(i => i.Id, opt => opt.Ignore());
            CreateMap<UpdateCustomerModel, Customer>();
        }
    }
}
