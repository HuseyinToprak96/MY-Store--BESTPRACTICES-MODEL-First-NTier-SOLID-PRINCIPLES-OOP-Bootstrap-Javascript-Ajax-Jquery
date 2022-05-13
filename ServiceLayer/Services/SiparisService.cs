using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Entities;
using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Services;
using CoreLayer.Interfaces.UnitOfWork;
using ServiceLayer.KodUretme;
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

        public async Task SiparisOlustur(int id)
        {
            await _siparisRepository.AddAsync(
                new Siparis
                {
                    UyeId = id,
                    SiparisTarihi = DateTime.Now,
                    SiparisKodu = CodeSiparis.KodUret(),
                    SiparisDurumu = 0
                });
           await _unitOfWork.CommitAsync();
        }
        

        public async Task<int> SiparisBul(int UyeId)
        {
          return await _siparisRepository.SiparisBul(UyeId);
        }

        public async Task SiparisleriEkle(List<SepetDetay> sepetDetaylar,int siparisId)
        {
            List<SiparisDetay> siparisDetaylar = new List<SiparisDetay>(); 
            for (int i = 0; i < sepetDetaylar.Count; i++)
            {
                SiparisDetay siparisDetay = new SiparisDetay();
                siparisDetay.Fiyat = sepetDetaylar[i].urun.Ucret;
                siparisDetay.urunId = sepetDetaylar[i].urun.Id;
                siparisDetay.SiparisId = siparisId;
                siparisDetaylar.Add(siparisDetay);
            }
            _siparisRepository.SiparisleriEkle(siparisDetaylar);
            await _unitOfWork.CommitAsync();
        }
        public async Task Puanla(int puan, int id)
        {
            _siparisRepository.Puanla(puan, id);
            await _unitOfWork.CommitAsync();
        }

        public async Task<double> PuanOrt()
        {
            return await _siparisRepository.PuanOrt();
        }
    }
}
