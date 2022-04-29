using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Services
{
    public interface IFaturaService:IService<Fatura>
    {
        Task<Fatura> FaturaDetay(int id);
        Task<List<Fatura>> KisininFaturalari(int UyeId);
    }
}
