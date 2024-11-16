using CashFlow.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace CashFlow.Infrastructure.Database.Repositories
{
    //Implementa as interfaces dos repositórios com as funções base de CRUD
    public class BaseRepository<T, C> : IGetRepository<T, C>, ISetRepository<T, C> where T : class
    {
        internal readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public virtual T Get(C id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual Task<IQueryable<T>> GetAll(Expression<Func<T, bool>>? predicate = null)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return Task.FromResult(query);
        }

        public async Task Insert(T entidade)
        {
            await _context.Set<T>().AddAsync(entidade);
            await Save();
        }

        public virtual async Task Update(T entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;
            await Save();
        }

        public virtual async Task Delete(C id)
        {
            var entity = Get(id);
            EntityEntry entityEntry = _context.Entry(entity);
            entityEntry.State = EntityState.Deleted;
            await Save();
        }

        private async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }

    public class BaseRepository<T> : BaseRepository<T, string>, IGetRepository<T, string>, ISetRepository<T, string> where T : class
    {
        public BaseRepository(DbContext context) : base(context)
        {
        }
    }
}
