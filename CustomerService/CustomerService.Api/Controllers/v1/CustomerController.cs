using AutoMapper;
using CustomerService.Api.Models.v1;
using CustomerService.Api.Service.v1.Commands;
using CustomerService.Api.Service.v1.Queries;
using CustomerService.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.Api.Controllers.v1
{
    [Produces("application/json")]
    [Route("v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public CustomerController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<IList<Customer>>> GetCustomers()
        {
            try
            {
                return await mediator.Send(new GetCustomersQuery());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(CreateCustomerModel createCustomerModel)
        {
            try
            {
                return await mediator.Send(new CustomerCreateCommand
                { 
                    Customer = this.mapper.Map<Customer>(createCustomerModel) 
                }); 
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        public async Task<ActionResult<Customer>> UpdateCustomer(UpdateCustomerModel updateCustomerModel)
        {
            try
            {
                var customer=await mediator.Send(new GetCustomerByIdQuery { Id = updateCustomerModel.Id });
                if(customer==null)
                {
                    return NotFound("Customer not found");
                }

                return await mediator.Send(new CustomerUpdateCommand
                {
                    Customer = this.mapper.Map(updateCustomerModel, customer)
                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
