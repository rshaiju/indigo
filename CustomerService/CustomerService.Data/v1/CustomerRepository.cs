using CustomerService.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerService.Data.v1
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerContext customerContext):base(customerContext)
        {

        }

        public async Task<Customer> GetCustomerByIdAsync(long id, CancellationToken cancellationToken)
        {
            return await this.customerContext.Customers.FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
        }
    }
}
