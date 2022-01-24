using MediatR;
using OrderService.Data.v1;
using OrderService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Api.Service.v1.Queries
{
    public class GetOrdersByCustomerQueryHandler : IRequestHandler<GetOrdersByCustomerQuery, List<Order>>
    {
        private readonly IOrderRepository orderRepository;

        public GetOrdersByCustomerQueryHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public async Task<List<Order>> Handle(GetOrdersByCustomerQuery request, CancellationToken cancellationToken)
        {
            return await this.orderRepository.GetOrdersByCustomerIdAsync(request.CustomerId, cancellationToken);
        }
    }
}
