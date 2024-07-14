using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotech.Core.Services
{
    public interface IDataService<T>
    {
        Task<List<T>> GetAll();

        Task<T> GetById(Guid Id);

        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task<bool> Delete(Guid Id);
    }
}
