namespace CashFlow.Application.Interfaces
{
    public interface ISetRepository<T, C> where T : class
    {
        Task<T> Insert(T entidade);
        Task Update(T entidade);
        Task Delete(C id);
    }

    public interface ISetRepository<T> : ISetRepository<T, string> where T : class
    {
    }
}
