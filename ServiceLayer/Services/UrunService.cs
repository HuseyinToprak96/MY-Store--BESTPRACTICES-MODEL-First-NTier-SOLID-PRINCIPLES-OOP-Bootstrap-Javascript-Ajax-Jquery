using CoreLayer.Entities;
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
    public class UrunService : Service<Urun>, IUrunService
    {
        private readonly IUrunRepository _urunRepository;
        public UrunService(IRepository<Urun> repository, IUnitOfWork unitOfWork, IUrunRepository urunRepository) : base(repository, unitOfWork)
        {
            _urunRepository = urunRepository;
        }

        public async Task<List<Urun>> AltKategoriyeGore(int id)
        {
            return await _urunRepository.AltKategoriyeGore(id);
        }

        public Task<Urun[]> BitmesiYakin()
        {
            throw new NotImplementedException();
        }

        public Task<Urun[]> EncokSatan()
        {
            throw new NotImplementedException();
        }

        public Task<Urun[]> FavoriUrunler()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Urun>> TumUrunBilgileri()
        {
          return await  _urunRepository.TumUrunBilgileri();
        }

        public Task<Urun[]> Yeni4Urun()
        {
            throw new NotImplementedException();
        }
    }
}
