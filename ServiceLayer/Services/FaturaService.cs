using CoreLayer.Entities;
using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Services;
using CoreLayer.Interfaces.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class FaturaService : Service<Fatura>, IFaturaService
    {
        private readonly IFaturaRepository _faturaRepository;
        public FaturaService(IRepository<Fatura> repository, IUnitOfWork unitOfWork, IFaturaRepository faturaRepository) : base(repository, unitOfWork)
        {
            _faturaRepository = faturaRepository;
        }

        public async Task<Fatura> FaturaDetay(int id)
        {
            return await _faturaRepository.FaturaDetay(id);
        }

        public async Task<List<Fatura>> KisininFaturalari(int UyeId)
        {
            return await _faturaRepository.KisininFaturalari(UyeId);
        }
    }
}
