using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Data.v1
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        protected readonly OrderContext orderContext;

        public Repository(OrderContext orderContext)
        {
            this.orderContext = orderContext;
        }

        public async Task<T> CreateAsync(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                await this.orderContext.AddAsync(entity);
                await this.orderContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {

                throw new Exception($"Failed to create {nameof(entity)}, Exception: {ex.Message}");
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return this.orderContext.Set<T>();
            }
            catch (Exception ex)
            {

                throw new Exception($"Failed to retrive entity, Exception: {ex.Message}");
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                this.orderContext.Update(entity);
                await this.orderContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {

                throw new Exception($"Failed to update {nameof(entity)}, Exception: {ex.Message}");
            }
        }

        public async Task UpdateRangeAsync(List<T> entities)
        {
            if (entities is null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            try
            {
                this.orderContext.UpdateRange(entities);
                await this.orderContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception($"Failed to update {nameof(entities)}, Exception: {ex.Message}"); 
            }
        }
    }
}
