using System.Linq.Expressions;

namespace CashFlow.Application.Interfaces
{
    public interface IGetRepository<T, C> where T : class
    {
        T Get(C id);
        Task<IQueryable<T>> GetAll(Expression<Func<T, bool>>? predicate = null);
    }

    public interface IGetRepository<T> : IGetRepository<T, string> where T : class
    {
    }
}
