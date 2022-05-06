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
    public class SiparisService : Service<Siparis>, ISiparisService
    {
        private readonly ISiparisRepository _siparisRepository;
        public SiparisService(IRepository<Siparis> repository, IUnitOfWork unitOfWork, ISiparisRepository siparisRepository) : base(repository, unitOfWork)
        {
            _siparisRepository = siparisRepository;
        }

        public async Task DurumGuncelle(int islem)
        {
            await _siparisRepository.DurumGuncelle(islem);
            await _unitOfWork.CommitAsync();
        }

        public async Task SiparisGuncelle(int durum,int id)
        {
            await _siparisRepository.SiparisGuncelle(durum, id);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<Siparis>> Siparisler(Durum durum)
        {
            return await _siparisRepository.Siparisler(durum);
        }
    }
}
