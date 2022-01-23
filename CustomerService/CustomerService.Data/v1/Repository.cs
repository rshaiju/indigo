using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Data.v1
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        protected readonly CustomerContext customerContext;

        public Repository(CustomerContext customerContext)
        {
            this.customerContext = customerContext;
        }
        public async Task<T> CreateAsync(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                await this.customerContext.AddAsync(entity);
                await this.customerContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {

                throw new Exception($"{nameof(entity)} could not be saved. Exception:{ex.Message}");
            }
          
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return this.customerContext.Set<T>();
            }
            catch (Exception ex)
            {

                throw new Exception($"Could not retrieve entities. Exception:{ex.Message}");
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
                this.customerContext.Update(entity);
                await this.customerContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {

                throw new Exception($"{nameof(entity)} could not be saved. Exception:{ex.Message}");
            }
        }
    }
}
