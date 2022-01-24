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
    public class GetOrdersByCustomerIdQueryHandler : IRequestHandler<GetOrdersByCustomerIdQuery, List<Order>>
    {
        private readonly IOrderRepository orderRepository;

        public GetOrdersByCustomerIdQueryHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public async Task<List<Order>> Handle(GetOrdersByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            return await this.orderRepository.GetOrdersByCustomerIdAsync(request.CustomerId, cancellationToken);
        }
    }
}
