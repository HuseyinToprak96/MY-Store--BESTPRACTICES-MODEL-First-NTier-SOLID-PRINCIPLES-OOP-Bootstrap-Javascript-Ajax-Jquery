using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Repository
{
    public interface ISiparisRepository:IRepository<Siparis>
    {
        Task<List<Siparis>> Siparisler(Durum durum);
        Task DurumGuncelle(int durum);
        Task SiparisGuncelle(int durum, int id);
        Task<Siparis> SiparisDetay(int id);
    }
}
