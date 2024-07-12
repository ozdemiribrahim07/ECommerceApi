using ECommerce.Application.Repositories;
using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : EntityBase, new();
        IWriteRepository<T> GetWriteRepository<T>() where T : EntityBase, new();

        Task<int> SaveAsync();
        int Save();

    }
}
