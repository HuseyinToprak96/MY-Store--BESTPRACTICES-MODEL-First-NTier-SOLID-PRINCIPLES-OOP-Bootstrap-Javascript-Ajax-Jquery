using CoreLayer.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Data _data;
        public UnitOfWork(Data data)
        {
            _data = data;
        }
        public void Commit()
        {
            _data.SaveChanges();
        }

        public async Task CommitAsync()
        {
           await _data.SaveChangesAsync();
        }
    }
}
