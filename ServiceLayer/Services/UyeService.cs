using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Entities;
using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Services;
using CoreLayer.Interfaces.UnitOfWork;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class UyeService : Service<Uye>, IUyeService
    {
        private readonly IMapper _mapper;
        private readonly IUyeRepository _uyeRepository;
        public UyeService(IRepository<Uye> repository, IUnitOfWork unitOfWork, IMapper mapper, IUyeRepository uyeRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _uyeRepository = uyeRepository;
        }

        public async Task<string> MailBul(int id)
        {
            return await _uyeRepository.MailBul(id);
        }

        public async Task<bool> MailKontrol(string mail)
        {
            return await _uyeRepository.MailKontrol(mail);
        }

        public async Task<Uye> uyeDetay(int UyeId)
        {
            var uye = await _uyeRepository.uyeDetay(UyeId);
            var uyeDto = _mapper.Map<UyeDto>(uye);
            return uye;
        }

        public async Task<GirenBilgileri> UyeLogin(string mail, string sifre)
        {
            var uye = await _uyeRepository.UyeLogin(mail, sifre);
            var GirenBilgileriDto = _mapper.Map<GirenBilgileri>(uye);
            return GirenBilgileriDto;
        }

        public async Task Yetkilendir(bool yetki, int id)
        {
            await _uyeRepository.Yetkilendir(yetki, id);
        }
    }
}
