using MediatR;
using OrderService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Api.Service.v1.Queries
{
    public class OrdersQueryHandler : IRequestHandler<OrdersQuery, List<Order>>
    {
        public async Task<List<Order>> Handle(OrdersQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new List<Order> { new Order { Id = 1, OrderState = 1, CustomerFullName = "John Doe", CustomerId = 1 } });
        }
    }
}
