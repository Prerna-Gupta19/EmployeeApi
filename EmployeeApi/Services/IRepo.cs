using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApi.Services
{
    public interface IRepo<K,T>
    {
        Task<T>Get(K key);
        Task<ICollection<T>> GetAll();
        Task<T> Delete(K key);
        Task<T> Add(T item);
        Task<T> Update(T item);
     }
}
