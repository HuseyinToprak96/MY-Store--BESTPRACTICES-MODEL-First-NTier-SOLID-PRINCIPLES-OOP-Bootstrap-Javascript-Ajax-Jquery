using AutoMapper;
using CoreLayer.Entities;
using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Services;
using CoreLayer.Interfaces.UnitOfWork;
using Microsoft.Extensions.Caching.Memory;
using ServiceLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheLayer
{
    public class UrunServiceWithCaching : IUrunService
    {
        private const string CacheUrunKey = "urunlerCache";
        private readonly IMemoryCache _memoryCache;
        private readonly IUrunRepository _urunRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UrunServiceWithCaching(IMemoryCache memoryCache, IUrunRepository urunRepository, IUnitOfWork unitOfWork)
        {
            
            _memoryCache = memoryCache;
            _urunRepository = urunRepository;
            _unitOfWork = unitOfWork;
            if (!_memoryCache.TryGetValue(CacheUrunKey,out _))
            {
                _memoryCache.Set(CacheUrunKey, _urunRepository.TumUrunBilgileri().Result);
            }
        }
        public async Task CacheAllUrunlerAsync()
        {
            _memoryCache.Set(CacheUrunKey, await _urunRepository.getAllAsync());
        }
        public async Task AddAsync(Urun t)
        {
           await _urunRepository.AddAsync(t);
            await _unitOfWork.CommitAsync();
            await CacheAllUrunlerAsync();

        }

        public Task<List<Urun>> AltKategoriyeGore(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Urun>> EncokSatan()
        {
            throw new NotImplementedException();
        }

        public Task<List<Urun>> getAllAsync()
        {
            return Task.FromResult(_memoryCache.Get<List<Urun>>(CacheUrunKey).ToList());
        }

        public Task<Urun> getByIdAsync(int id)
        {
            var urun= _memoryCache.Get<List<Urun>>(CacheUrunKey).FirstOrDefault(x => x.Id == id);
            if (urun==null)
            {
                throw new ClientSideException($"{typeof(Urun).Name} bulunamadı");
            }
            return Task.FromResult(urun);
        }

        public async Task Remove(Urun t)
        {
            _urunRepository.Remove(t);
            await _unitOfWork.CommitAsync();
           await CacheAllUrunlerAsync();
        }

        public async Task<List<Urun>> TumUrunBilgileri()
        {
            return await _urunRepository.TumUrunBilgileri();//await kullanılmıyor ise bu şekilde döndürülür
        }

        public async Task Update(Urun t)
        {
            _urunRepository.Update(t);
            await _unitOfWork.CommitAsync();
            await CacheAllUrunlerAsync();
        }

        public Task<List<Urun>> Yeni4Urun()
        {
            throw new NotImplementedException();
        }
    }
}
