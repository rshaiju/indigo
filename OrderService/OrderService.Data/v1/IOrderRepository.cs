using OrderService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Data.v1
{
    public interface IOrderRepository:IRepository<Order>
    {
        Task<List<Order>> GetPaidOrdersAsync(CancellationToken cancellationToken);

        Task<Order> GetOrderByIdAsync(long id, CancellationToken cancellationToken);

        Task<List<Order>> GetOrdersByCustomerIdAsync(long customerId, CancellationToken cancellationToken);
    }
}
