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
    public class SepetService : Service<Sepet>, ISepetService
    {
        private readonly ISepetRepository _sepetRepository;
        private readonly IMapper _mapper;
        public SepetService(IRepository<Sepet> repository, IUnitOfWork unitOfWork, ISepetRepository sepetRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _sepetRepository = sepetRepository;
            _mapper = mapper;
        }

        public async Task<Sepet> MusterininSepeti(int UyeId)
        {
            return await _sepetRepository.MusterininSepeti(UyeId);
        }

        public async Task SepeteEkle(SepetDetayDto sepetDetayDto, int UyeId)
        {
            var sepetDetay = _mapper.Map<SepetDetay>(sepetDetayDto);
           await _sepetRepository.SepeteEkle(sepetDetay, UyeId);
           await _unitOfWork.CommitAsync();
            
        }
        public void SepettenCikar(int SepetDetayId, int UyeId)
        {
            _sepetRepository.SepettenCikar(SepetDetayId, UyeId);
            _unitOfWork.Commit();
        }
    }
}
