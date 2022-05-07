using AutoMapper;
using CoreLayer.Dtos;
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
        private readonly IMapper _mapper;
        public SiparisService(IRepository<Siparis> repository, IUnitOfWork unitOfWork, ISiparisRepository siparisRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _siparisRepository = siparisRepository;
            _mapper = mapper;
        }

        public async Task DurumGuncelle(int islem)
        {
            await _siparisRepository.DurumGuncelle(islem);
            await _unitOfWork.CommitAsync();
        }

        public async Task<Siparis_Siparis_Detay_UrunDto> SiparisDetay(int id)
        {
            var siparisDetay = _mapper.Map<Siparis_Siparis_Detay_UrunDto>(await _siparisRepository.SiparisDetay(id));
            return siparisDetay;
           
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
