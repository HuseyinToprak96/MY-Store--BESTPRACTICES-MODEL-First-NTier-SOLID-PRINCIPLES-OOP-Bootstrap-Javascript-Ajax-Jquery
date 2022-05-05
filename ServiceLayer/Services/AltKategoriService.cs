using CoreLayer.Entities;
using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Services;
using CoreLayer.Interfaces.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class AltKategoriService : Service<AltKategori>, IAltKategoriService
    {
        private readonly IAltKategoriRepository _altKategoriRepository;
        public AltKategoriService(IRepository<AltKategori> repository, IUnitOfWork unitOfWork, IAltKategoriRepository altKategoriRepository) : base(repository, unitOfWork)
        {
            _altKategoriRepository = altKategoriRepository;
        }

        public Task<AltKategori> Eklenen(AltKategori altKategori)
        {
            return _altKategoriRepository.Eklenen(altKategori);
        }

        public async Task<List<AltKategori>> KategoriyeAitAltKategoriler(int id)
        {
            return await _altKategoriRepository.KategoriyeAitAltKategoriler(id);
        }
    }
}
