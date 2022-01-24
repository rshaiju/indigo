using MediatR;
using OrderService.Data.v1;
using OrderService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Api.Service.v1.Commands
{
    public class PayOrderCommandHandler : IRequestHandler<PayOrderCommand, Order>
    {
        private readonly IOrderRepository orderRepository;

        public PayOrderCommandHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public async Task<Order> Handle(PayOrderCommand request, CancellationToken cancellationToken)
        {
            return await this.orderRepository.UpdateAsync(request.Order);
        }
    }
}
