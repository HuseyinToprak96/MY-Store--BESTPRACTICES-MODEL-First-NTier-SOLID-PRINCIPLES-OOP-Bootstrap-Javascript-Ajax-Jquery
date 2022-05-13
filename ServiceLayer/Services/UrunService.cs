using CoreLayer.Dtos;
using CoreLayer.Entities;
using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Services;
using CoreLayer.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class UrunService : Service<Urun>, IUrunService
    {
        private readonly IUrunRepository _urunRepository;
        public UrunService(IRepository<Urun> repository, IUnitOfWork unitOfWork, IUrunRepository urunRepository) : base(repository, unitOfWork)
        {
            _urunRepository = urunRepository;
        }

        public async Task AdetGuncelle(int adet, int id)
        {
            await _urunRepository.AdetGuncelle(adet, id);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<Urun>> AltKategoriyeGore(int id)
        {
            return await _urunRepository.AltKategoriyeGore(id);
        }

        public Task<List<Urun>> Arama(Source source)
        {
            throw new NotImplementedException();
        }

        public Task<List<Urun>> BitmesiYakin()
        {
            throw new NotImplementedException();
        }

        public async Task<Urun> EklenenUrunuGoster(Urun urun)
        {
            return await _urunRepository.EklenenUrunuGoster(urun);
        }

        public Task<List<Urun>> EncokSatan()
        {
            throw new NotImplementedException();
        }

        public Task<List<Urun>> FavoriUrunler()
        {
            throw new NotImplementedException();
        }

        public Task<List<Urun>> OnerilenUrunler(int? cinsId, int? AltKategoriId)
        {
            throw new NotImplementedException();
        }

        public Task<List<StokDto>> StokKontrol(int tehlikeSiniri)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Urun>> TumUrunBilgileri()
        {
            return await _urunRepository.TumUrunBilgileri();
        }

        public Task<Urun> UrunDetay(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Urun>> Yeni4Urun()
        {
            throw new NotImplementedException();
        }
    }
}
