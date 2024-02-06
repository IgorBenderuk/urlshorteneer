using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repos.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T?> GetSingle(Guid Id);
        
        Task<bool> Create(T entity);

        Task<bool> Update(T entity);

        Task<bool> Delete(Guid Id);

    }
}
