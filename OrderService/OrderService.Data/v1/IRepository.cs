using OrderService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Data.v1
{
    public interface IRepository<T> where T:class, new()
    {
        IEnumerable<T> GetAll();

        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task UpdateRangeAsync(List<T> entities);
    }
}
