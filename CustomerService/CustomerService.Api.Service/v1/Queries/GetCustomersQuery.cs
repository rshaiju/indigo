using CustomerService.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Api.Service.v1.Queries
{
    public class GetCustomersQuery: IRequest<List<Customer>>
    {
    }
}
