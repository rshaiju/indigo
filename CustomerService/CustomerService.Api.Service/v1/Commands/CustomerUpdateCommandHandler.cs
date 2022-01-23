using CustomerService.Data.v1;
using CustomerService.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerService.Api.Service.v1.Commands
{
    public class CustomerUpdateCommandHandler : IRequestHandler<CustomerUpdateCommand, Customer>
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerUpdateCommandHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
        {
            return await this.customerRepository.UpdateAsync(request.Customer);
        }
    }
}
