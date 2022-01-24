using MediatR;
using OrderService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Api.Service.v1.Commands
{
    public class PayOrderCommand:IRequest<Order>
    {
        public Order Order { get; set; }
    }
}
