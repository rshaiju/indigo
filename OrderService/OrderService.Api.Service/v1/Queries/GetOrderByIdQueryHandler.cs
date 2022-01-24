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
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IOrderRepository orderRepository;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await this.orderRepository.GetOrderByIdAsync(request.Id, cancellationToken);
        }
    }
}
