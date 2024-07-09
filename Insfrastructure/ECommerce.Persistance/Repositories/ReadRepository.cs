
using ECommerce.Application.Repositories;
using ECommerce.Domain.Common;
using ECommerce.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : EntityBase,IEntityBase ,new()
    {
        readonly CommerceContext _context;
        public ReadRepository(CommerceContext context)
        {
            _context = context;
        }

        public DbSet<T> Table
          => _context.Set<T>();


        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? method = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null)
        {
            IQueryable<T> query = Table;

            if (method != null)
                query = query.Where(method);
            
            if (include != null)
                query = include(query);
            
            if (orderby != null)
               return await orderby(query).ToListAsync();
              
            return await query.ToListAsync();
        }




        public async Task<IList<T>> GetAllByPageAsync(Expression<Func<T, bool>>? method = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null, int page = 1, int pageSize = 5)
        {

            IQueryable<T> query = Table;

            if (method != null)
                query = query.Where(method);

            if (include != null)
                query = include(query);

            if (orderby != null)
                return await orderby(query). Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return await query.ToListAsync();
        }



        public async Task<T> GetAsync(
            Expression<Func<T, bool>> method, Func<IQueryable<T>,
            IIncludableQueryable<T, object>>? include = null)
        {
            IQueryable<T> query = Table;

            if (include is not null)
                query = include(query);

            return await query.FirstOrDefaultAsync(method);
        }


        public async Task<int> CountAsync(Expression<Func<T, bool>>? method = null)
        {
            if (method is not null)
                return await Table.Where(method).CountAsync();

            return await Table.CountAsync();
        }


        public IQueryable<T> FindAsync(Expression<Func<T, bool>> method)
        {
            return Table.Where(method);
        }
    }
}
