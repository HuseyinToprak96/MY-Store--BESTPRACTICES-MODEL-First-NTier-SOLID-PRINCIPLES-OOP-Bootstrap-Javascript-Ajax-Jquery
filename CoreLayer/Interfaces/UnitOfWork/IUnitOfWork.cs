using System.Threading.Tasks;

namespace CoreLayer.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
    }
}
