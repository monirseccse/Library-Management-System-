namespace Infrastructure.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveAsync();
    }
}
