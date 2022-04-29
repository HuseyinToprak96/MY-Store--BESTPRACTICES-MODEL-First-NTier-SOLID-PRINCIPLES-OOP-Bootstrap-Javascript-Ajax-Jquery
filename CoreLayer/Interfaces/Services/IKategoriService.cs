using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Services
{
   public interface IKategoriService:IService<Kategori>
    {
        Task<List<Kategori>> KategoriyeAitDetaylar();
    }
}
