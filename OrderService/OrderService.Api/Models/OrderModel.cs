using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Models
{
    public class OrderModel
    {
        [Required] public long CustomerId { get; set; }
        [Required] public string CustomerFullName { get; set; }
    }
}
