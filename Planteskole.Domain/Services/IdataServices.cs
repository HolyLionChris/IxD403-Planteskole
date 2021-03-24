using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planteskole.Domain.Services
{
    public interface IdataServices<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        Task<T> Create(T entity);

        Task<T> Update(int id, T entity);

        Task<bool> Delete(int id); 
    }
}
