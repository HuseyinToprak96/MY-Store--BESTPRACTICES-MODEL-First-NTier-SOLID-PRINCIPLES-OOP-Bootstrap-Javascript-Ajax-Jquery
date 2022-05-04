using CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Repository
{
    public interface IFaturaRepository : IRepository<Fatura>
    {
        Task<Fatura> FaturaDetay(int id);
        Task<List<Fatura>> KisininFaturalari(int UyeId);
    }
}
