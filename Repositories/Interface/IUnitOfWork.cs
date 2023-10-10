namespace GomokuApp.Repositories.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IBoardStateRepository BoardState { get; }
        IPlayerTurnLogRepository PlayerTurnLog { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
