using GomokuApp.Data;
using GomokuApp.Repositories.Interface;

namespace GomokuApp.Repositories.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly DBContext _context;
        public IBoardStateRepository BoardState { get; }

        public IPlayerTurnLogRepository PlayerTurnLog { get; }

        public UnitOfWork(DBContext context)
        {
            _context = context;
            BoardState = new BoardStateRepository(_context);
            PlayerTurnLog = new PlayerTurnLogRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
