using System.Collections.Generic;
using System.Threading.Tasks;
using DeveloperCodingTest.IData;
using Microsoft.EntityFrameworkCore;

namespace DeveloperCodingTest.Data
{
    public class Repository<DeveloperCodingContext> : IRepository where DeveloperCodingContext : DbContext
    {
        protected DeveloperCodingContext dbContext;

        public Repository(DeveloperCodingContext context)
        {
            dbContext = context;
        }

        public async Task CreateAsync<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Add(entity);

            _ = await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Remove(entity);

            _ = await this.dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> SelectAllAsync<T>() where T : class
        {
            return await this.dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> SelectByIdAsync<T>(int id) where T : class
        {
            return await this.dbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Update(entity);

            _ = await this.dbContext.SaveChangesAsync();
        }
    }
}

