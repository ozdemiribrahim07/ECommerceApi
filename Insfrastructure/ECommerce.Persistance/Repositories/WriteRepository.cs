using ECommerce.Application.Repositories;
using ECommerce.Domain.Common;
using ECommerce.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : EntityBase, IEntityBase, new()
    {
        readonly CommerceContext _context;
        public WriteRepository(CommerceContext context)
        {
            _context = context;
        }

        public DbSet<T> Table
          => _context.Set<T>();

        public async Task AddAsync(T entity)
        {
           await Table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
           await Table.AddRangeAsync(entities);
        }

        public async Task HardRemoveAsync(T entity)
        {
           await Task.Run(() => Table.Remove(entity));
        }


        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }
    }
}
