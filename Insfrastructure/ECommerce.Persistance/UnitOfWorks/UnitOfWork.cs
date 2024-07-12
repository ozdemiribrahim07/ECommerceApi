using ECommerce.Application.Repositories;
using ECommerce.Application.UnitOfWorks;
using ECommerce.Domain.Common;
using ECommerce.Persistance.Contexts;
using ECommerce.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistance.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly CommerceContext _context;
        public UnitOfWork(CommerceContext context)
        {
            _context = context;
        }

        public async ValueTask DisposeAsync()
            => await _context.DisposeAsync();

        public IReadRepository<T> GetReadRepository<T>() where T : EntityBase, new()
            => new ReadRepository<T>(_context);

        public IWriteRepository<T> GetWriteRepository<T>() where T : EntityBase, new()
            => new WriteRepository<T>(_context);

        public int Save()
         => _context.SaveChanges();

        public async Task<int> SaveAsync()
         => await _context.SaveChangesAsync();
    }   
}
