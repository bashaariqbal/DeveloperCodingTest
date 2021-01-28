using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeveloperCodingTest.IData
{
    public interface IRepository
    {
        Task<List<T>> SelectAllAsync<T>() where T : class;
        Task<T> SelectByIdAsync<T>(int id) where T : class;
        Task CreateAsync<T>(T entity) where T : class;
        Task UpdateAsync<T>(T entity) where T : class;
        Task DeleteAsync<T>(T entity) where T : class;
    }
}
