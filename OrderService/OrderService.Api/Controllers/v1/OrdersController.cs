using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Api.Models;
using OrderService.Api.Service.v1.Commands;
using OrderService.Api.Service.v1.Queries;
using OrderService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Controllers.v1
{
    [Produces("application/json")]
    [Route("v1/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public OrdersController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderModel orderModel)
        {
            if (orderModel is null)
            {
                throw new ArgumentNullException(nameof(orderModel));
            }

            try
            {
                return await this.mediator.Send(new CreateOrderCommand { Order=this.mapper.Map<Order>(orderModel) });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            try
            {
                return await this.mediator.Send(new GetPaidOrdersQuery());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        public async Task<ActionResult<Order>> Pay(long id)
        {
            try
            {
                var order = await mediator.Send(new GetOrderByIdQuery { Id = id });
                if (order == null)
                {
                    return NotFound($"Order {id} could not be found");
                }
                order.OrderState = 2;
                return await mediator.Send(new PayOrderCommand { Order = order });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
