using AutoMapper;
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
    public class SepetService : Service<Sepet>, ISepetService
    {
        private readonly ISepetRepository _sepetRepository;
        private readonly IRepository<SepetDetay> _sepetDetayRepository;
        private readonly IMapper _mapper;
        public SepetService(IRepository<Sepet> repository, IUnitOfWork unitOfWork, ISepetRepository sepetRepository, IMapper mapper, IRepository<SepetDetay> sepetDetayRepository) : base(repository, unitOfWork)
        {
            _sepetRepository = sepetRepository;
            _mapper = mapper;
            _sepetDetayRepository = sepetDetayRepository;
        }

        public async Task<Sepet> MusterininSepeti(int UyeId)
        {
                return await _sepetRepository.MusterininSepeti(UyeId);
                 }

        public async Task<List<SepetDetay>> sepetDetaylari(int sepetId)
        {
            return await _sepetRepository.sepetDetaylari(sepetId);
        }

        public async Task SepeteEkle(int UrunId, int UyeId)
        {
            await _sepetRepository.SepeteEkle(UrunId, UyeId);
            await _unitOfWork.CommitAsync();
        }
        
        public async Task SepettenCikar(int Id)
        {
            _sepetRepository.SepettenCikar(Id);
           await _unitOfWork.CommitAsync();
        }
    }
}
