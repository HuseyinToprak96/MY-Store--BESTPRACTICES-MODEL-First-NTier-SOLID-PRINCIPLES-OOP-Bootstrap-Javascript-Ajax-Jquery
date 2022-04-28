using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Services
{
   public interface IService<T> where T:class
    {
        Task<List<T>> getAllAsync();
        Task<T> getByIdAsync(int id);
        Task AddAsync(T t);
        void Remove(T t);
        void Update(T t);
    }
}
