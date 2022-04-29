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
    public class KategoriService : Service<Kategori>, IKategoriService
    {
        private readonly IKategoriRepository _kategoriRepository;
        public KategoriService(IRepository<Kategori> repository, IUnitOfWork unitOfWork, IKategoriRepository kategoriRepository) : base(repository, unitOfWork)
        {
            _kategoriRepository = kategoriRepository;
        }

        public async Task<List<Kategori>> KategoriyeAitDetaylar()
        {
            return await _kategoriRepository.KategoriyeAitDetaylar();
        }
    }
}
