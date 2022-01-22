using System;

namespace OrderService.Domain
{
    public class Order
    {
        public long Id { get; set; }
        public int OrderState { get; set; }
        public long CustomerId { get; set; }
        public string CustomerFullName { get; set; }
    }
}
