using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Services;
using CoreLayer.Interfaces.UnitOfWork;
using ServiceLayer.Exceptions;
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
        protected readonly IUnitOfWork _unitOfWork;
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
            var hasData =await _repository.getByIdAsync(id);
            if (hasData == null)
            throw new ClientSideException($"{typeof(T).Name} bulunamadı.");
            return await _repository.getByIdAsync(id);
        }

        public async Task Remove(T t)
        {
            _repository.Remove(t);
           await _unitOfWork.CommitAsync();
        }

        public async Task Update(T t)
        {
            _repository.Update(t);
            await _unitOfWork.CommitAsync();
        }
    }
}
