using CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Services
{
    public interface IKategoriService : IService<Kategori>
    {
        Task<List<Kategori>> KategoriyeAitDetaylar();
    }
}
