using CoreLayer.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly Data _data;
        private readonly DbSet<T> _dbSet;
        public Repository(Data data)
        {
            _data = data;
            _dbSet = data.Set<T>();
            data.Database.EnsureCreated();
        }
        public async Task AddAsync(T t)
        {
           await _dbSet.AddAsync(t);
        }

        public async Task<List<T>> getAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> getByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T t)
        {
            _dbSet.Remove(t);
        }

        public void Update(T t)
        {
            _dbSet.Update(t);
        }
    }
}
