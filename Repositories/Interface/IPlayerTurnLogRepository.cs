using GomokuApp.Common.Enum;
using GomokuApp.Model.Entity;

namespace GomokuApp.Repositories.Interface
{
    public interface IPlayerTurnLogRepository : IRepository<PlayerTurnLog>
    {
        bool IsValidMove(PlayerEntity player);

        List<PlayerTurnLog>? GetPlayerTurnLogs();
    }
}
