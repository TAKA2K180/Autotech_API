using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Core.Services
{
    public interface IDataService<T>
    {
        Task<List<T>> Getall();

        Task<T> Get(Guid Id);

        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task<bool> Delete(Guid Id);
    }
}
