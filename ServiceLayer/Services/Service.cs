using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Services;
using CoreLayer.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ServiceLayer.Services
{
    public class Service<T> : IService<T> where T:class
    {
        protected readonly IRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public Service(IRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(T t)
        {
           await _repository.AddAsync(t);
           await _unitOfWork.CommitAsync();
        }

        public async Task<List<T>> getAllAsync()
        {
            return await _repository.getAllAsync();
        }

        public async Task<T> getByIdAsync(int id)
        {
            return await _repository.getByIdAsync(id);
        }

        public void Remove(T t)
        {
            _repository.Remove(t);
            _unitOfWork.Commit();
        }

        public void Update(T t)
        {
            _repository.Update(t);
            _unitOfWork.Commit();
        }
    }
}
