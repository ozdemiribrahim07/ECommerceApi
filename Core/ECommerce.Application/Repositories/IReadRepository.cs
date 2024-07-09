using ECommerce.Domain.Common;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Repositories
{
    public interface IReadRepository<T> where T : EntityBase, IEntityBase, new()
    {
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? method = null, Func<IQueryable<T>,IIncludableQueryable<T, object>>? include = null,
          Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null);

        Task<IList<T>> GetAllByPageAsync(Expression<Func<T, bool>>? method = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
          Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null,
          int page = 1, int pageSize = 5);

        Task<T> GetAsync(Expression<Func<T, bool>> method,
          Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);


        IQueryable<T> FindAsync(Expression<Func<T, bool>> method);
        Task<int> CountAsync(Expression<Func<T, bool>>? method = null);


    }
}
