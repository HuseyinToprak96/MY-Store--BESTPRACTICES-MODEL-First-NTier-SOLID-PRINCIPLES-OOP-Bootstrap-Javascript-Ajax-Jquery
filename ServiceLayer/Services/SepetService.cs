using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Entities;
using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Services;
using CoreLayer.Interfaces.UnitOfWork;
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
            if (UyeId != 0)
                return await _sepetRepository.MusterininSepeti(UyeId);
            return new Sepet();
        }

        public async Task SepeteEkle(int UrunId, int UyeId)
        {
            SepetDetayDto sepetDetayDto = new SepetDetayDto();
            sepetDetayDto.UrunId = UrunId;
            var sepetDetay = _mapper.Map<SepetDetay>(sepetDetayDto);
            await _sepetRepository.SepeteEkle(sepetDetay, UyeId);
            await _unitOfWork.CommitAsync();

        }
        public async Task SepettenCikar(int Id)
        {
            _sepetRepository.SepettenCikar(Id);
           await _unitOfWork.CommitAsync();
        }
    }
}
