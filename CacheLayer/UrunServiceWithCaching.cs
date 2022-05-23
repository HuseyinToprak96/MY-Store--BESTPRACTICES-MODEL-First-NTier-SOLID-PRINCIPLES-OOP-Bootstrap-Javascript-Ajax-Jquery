using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Entities;
using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Services;
using CoreLayer.Interfaces.UnitOfWork;
using Microsoft.Extensions.Caching.Memory;
using ServiceLayer.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CacheLayer
{
    public class UrunServiceWithCaching : IUrunService
    {
        private const string CacheUrunKey = "urunlerCache";
        private readonly IMemoryCache _memoryCache;
        private readonly IUrunRepository _urunRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UrunServiceWithCaching(IMemoryCache memoryCache, IUrunRepository urunRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _memoryCache = memoryCache;
            _urunRepository = urunRepository;
            _unitOfWork = unitOfWork;
            if (!_memoryCache.TryGetValue(CacheUrunKey, out _))
            {
                _memoryCache.Set(CacheUrunKey, _urunRepository.TumUrunBilgileri().Result);
            }
            _mapper = mapper;
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
        public async Task<List<Urun>> AltKategoriyeGore(int id) => await _urunRepository.AltKategoriyeGore(id);
        public async Task<List<Urun>> EncokSatan() => await _urunRepository.EncokSatan();
       
        
        public Task<List<Urun>> getAllAsync() => Task.FromResult(_memoryCache.Get<List<Urun>>(CacheUrunKey).ToList());


        public Task<Urun> getByIdAsync(int id)
        {
            var urun = _memoryCache.Get<List<Urun>>(CacheUrunKey).FirstOrDefault(x => x.Id == id);
            if (urun == null)
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

        public async Task<List<Urun>> TumUrunBilgileri() => await _urunRepository.TumUrunBilgileri();//await kullanılmıyor ise bu şekilde döndürülür


        public async Task Update(Urun t)
        {
            _urunRepository.Update(t);
            await _unitOfWork.CommitAsync();
            await CacheAllUrunlerAsync();
        }

        public async Task<List<Urun>> Yeni4Urun() => await _urunRepository.Yeni4Urun();


        public async Task<List<Urun>> FavoriUrunler() => await _urunRepository.FavoriUrunler();

        public async Task<List<Urun>> BitmesiYakin() => await _urunRepository.BitmesiYakin();

        public async Task<Urun> UrunDetay(int id)
        {
            var urun = await _urunRepository.UrunDetay(id);
            return urun;
        }

        public Task<List<Urun>> OnerilenUrunler(int? cinsId, int? AltKategoriId)
        {
            var urunler = _memoryCache.Get<List<Urun>>(CacheUrunKey).Where(x => x.kimeGoreId == cinsId && x.AltKategoriId == AltKategoriId).Take(5).ToList();
            return Task.FromResult(urunler);
        }

        public Task<List<Urun>> Arama(Source source)
        {
            List<Urun> urunler = _memoryCache.Get<List<Urun>>(CacheUrunKey);
            if (source.AltKategoriId > 0)
                urunler = urunler.Where(x => x.AltKategoriId == source.AltKategoriId).ToList();
            if (source.KimeGore > 0)
                urunler = urunler.Where(x => x.kimeGoreId == source.KimeGore).ToList();
            return Task.FromResult(urunler);

        }

        public async Task<Urun> EklenenUrunuGoster(Urun urun)
        {
         var u=  await _urunRepository.EklenenUrunuGoster(urun);
            return u;
        }

        public Task<List<StokDto>> StokKontrol(int tehlikeSiniri)
        {
            var urunler= _memoryCache.Get<List<Urun>>(CacheUrunKey).Where(x =>x.Adet<=tehlikeSiniri).ToList();
            var stokDto = _mapper.Map<List<StokDto>>(urunler);
            return Task.FromResult(stokDto);
        }

        public async Task AdetGuncelle(int adet, int id)
        {
            await _urunRepository.AdetGuncelle(adet,id);
            await _unitOfWork.CommitAsync();
            await CacheAllUrunlerAsync();
        }
    }
}
