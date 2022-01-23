using CustomerService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerService.Data.v1
{
    public interface ICustomerRepository:IRepository<Customer>
    {
        Task<Customer> GetCustomerByIdAsync(long id, CancellationToken cancellationToken);
    }
}
