using Microsoft.EntityFrameworkCore;
using OrderService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Data.v1
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext orderContext):base(orderContext)
        {

        }

        public async Task<Order> GetOrderByIdAsync(long id, CancellationToken cancellationToken)
        {
            try
            {
                return await this.orderContext.Orders.FindAsync(id, cancellationToken);
            }
            catch (Exception ex)
            {

                throw new Exception($"Failed to retrive order, Exception: {ex.Message}");
            }
        }

        public async Task<List<Order>> GetOrdersByCustomerIdAsync(long customerId, CancellationToken cancellationToken)
        {
            try
            {
                return await this.orderContext.Orders.Where(i => i.CustomerId == customerId).ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {

                throw new Exception($"Failed to retrive orders, Exception: {ex.Message}");
            }
        }

        public async Task<List<Order>> GetPaidOrdersAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await this.orderContext.Orders.Where(i => i.OrderState==2).ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {

                throw new Exception($"Failed to retrive orders, Exception: {ex.Message}");
            }
        }
    }
}
