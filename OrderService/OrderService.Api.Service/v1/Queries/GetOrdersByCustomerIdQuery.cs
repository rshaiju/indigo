using MediatR;
using OrderService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Api.Service.v1.Queries
{
    public class GetOrdersByCustomerIdQuery: IRequest<List<Order>>
    {
        public long CustomerId { get; set; }

    }
}
