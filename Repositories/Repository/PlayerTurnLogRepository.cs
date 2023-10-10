using GomokuApp.Common.Enum;
using GomokuApp.Common.Logging;
using GomokuApp.Data;
using GomokuApp.Model.Entity;
using GomokuApp.Repositories.Interface;

namespace GomokuApp.Repositories.Repository
{
    public class PlayerTurnLogRepository : Repository<PlayerTurnLog>, IPlayerTurnLogRepository
    {
        public PlayerTurnLogRepository(DBContext context) : base(context)
        {
        }

        public List<PlayerTurnLog>? GetPlayerTurnLogs()
        {
            return Context.Set<PlayerTurnLog>().ToList();
        }

        public bool IsValidMove(PlayerEntity player)
        {
            try
            {
                var lastMove = Context.Set<PlayerTurnLog>().OrderByDescending(x => x.Id).FirstOrDefault();

                if (lastMove == null) return true;

                if (lastMove.PlayerTurn != player.ToString())
                    return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

            return false;
        }
    }
}
