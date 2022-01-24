using MediatR;
using OrderService.Data.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Api.Service.v1.Commands
{
    public class UpdateOrdersCommandHandler : IRequestHandler<UpdateOrdersCommand>
    {
        private readonly IOrderRepository orderRepository;

        public UpdateOrdersCommandHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public async Task<Unit> Handle(UpdateOrdersCommand request, CancellationToken cancellationToken)
        {
            await this.orderRepository.UpdateRangeAsync(request.Orders);

            return Unit.Value;
        }
    }
}
