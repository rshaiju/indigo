using CustomerService.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerService.Api.Service.v1.Queries
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<Customer>>
    {
        public async Task<List<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult( new List<Customer> { new Customer { Id = 1, Age = 10, FirstName = "John", LastName = "Doe", Birthday = DateTime.Today } });
        }
    }
}
