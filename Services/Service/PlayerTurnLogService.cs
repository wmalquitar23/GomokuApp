using GomokuApp.Repositories.Interface;
using GomokuApp.Services.Interface;

namespace GomokuApp.Services.Service
{
    public class PlayerTurnLogService : IPlayerTurnLogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlayerTurnLogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
