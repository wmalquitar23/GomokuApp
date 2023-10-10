using GomokuApp.Common.Constants;
using GomokuApp.Common.Enum;
using GomokuApp.Common.Logging;
using GomokuApp.Common.Request;
using GomokuApp.Model.Entity;
using GomokuApp.Repositories.Interface;
using GomokuApp.Services.Interface;

namespace GomokuApp.Services.Service
{
    public class BoardStateService : IBoardStateService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BoardStateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ApiResult DeleteBoard()
        {
            ApiResult result;
            try
            {
                var boardState = _unitOfWork.BoardState.GetBoardState();
                var IsDeletePlayerLogs = DeletePlayerTurnLogs();

                if (IsDeletePlayerLogs && boardState != null)
                {
                    _unitOfWork.BoardState.RemoveRange(boardState);
                    _unitOfWork.SaveChanges();
                    result = ApiResult.Success;
                }
                result = ApiResult.Failed;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                result = ApiResult.Failed;
            }

            return result;
        }

        public List<BoardState>? GetBoardState()
        {
            return _unitOfWork.BoardState.GetBoardState();
        }

        public ApiResult InitializeBoard()
        {
            var result = ApiResult.Success;
            try
            {
                var deletedBoard = DeleteBoard();
                var recordUpdated = 0;

                if (deletedBoard == ApiResult.Success)
                {
                    for (int x = 0; x < BoardEntity.BoardSize; x++)
                    {
                        for (int y = 0; y < BoardEntity.BoardSize; y++)
                        {
                            _unitOfWork.BoardState.Add(new BoardState
                            {
                                LocationX = x,
                                LocationY = y,
                                OccupiedBy = PlayerEntity.None.ToString()
                            });
                        }
                    }
                    recordUpdated = _unitOfWork.SaveChanges();
                    result = recordUpdated > 0 ? ApiResult.Success : ApiResult.Failed;
                }
                
            }
            catch(Exception ex)
            {
                Log.Error(ex);
                result = ApiResult.Failed;
            }

            return result;
        }

        public ApiResult PlaceStone(PlaceStoneRequest request)
        {
            var result = ApiResult.Success;
            bool IsWin = false;

            try
            {
                var player = IsValidPlayer(request.Player);

                if (player == PlayerEntity.Invalid)
                    return ApiResult.Failed;

                var isValidMove = _unitOfWork.PlayerTurnLog.IsValidMove(player);
                var boardState = _unitOfWork.BoardState.GetBoardState(request.LocationX, request.LocationY);

                if (isValidMove && boardState != null)
                {
                    _unitOfWork.PlayerTurnLog.Add(new PlayerTurnLog
                    {
                        PlayerTurn = player.ToString()
                    });

                    boardState.OccupiedBy = player.ToString();
                    boardState.LocationX = request.LocationX;
                    boardState.LocationY = request.LocationY;
                    boardState.DateUpdated = DateTime.Now;

                    IsWin = IsWinMove(request.LocationX, request.LocationY, player.ToString());

                    _unitOfWork.SaveChanges();

                    if (IsWin)
                        result = ApiResult.Win;
                    else
                        result = ApiResult.ValidMove;
                }
                else
                    result = ApiResult.InvalidMove;
            }
            catch(Exception ex)
            {
                Log.Error(ex);
                result = ApiResult.Failed;
            }
            return result;
        }

        private PlayerEntity IsValidPlayer(string Player)
        {
            var player = PlayerEntity.Invalid;

            if (Player.ToLower() == "player1" || Player.ToLower() == "p1" )
                player = PlayerEntity.P1;
            else if (Player.ToLower() == "player2" || Player.ToLower() == "p2")
                player = PlayerEntity.P2;

            return player;
        }

        private bool IsWinMove(int row, int column, string player)
        {
            // Checking for invalid row or column index
            if (row < 0 || row >= BoardEntity.BoardSize || column < 0 || column >= BoardEntity.BoardSize)
                return false;

            var boardState = _unitOfWork.BoardState.GetBoardContent();

            if (boardState == null)
            {
                return false;
            }

            int[] dx = { -1, 1, 0, 0, -1, 1, -1, 1 };
            int[] dy = { 0, 0, -1, 1, -1, 1, 1, -1 };

            for (int dir = 0; dir < 8; dir++)
            {
                int count = 1;
                for (int step = 1; step < 5; step++)
                {
                    int newRow = row + step * dx[dir];
                    int newCol = column + step * dy[dir];

                    if (newRow < 0 || newRow >= BoardEntity.BoardSize || newCol < 0 || newCol >= BoardEntity.BoardSize ||
                        boardState[newRow][newCol].Player != player)
                    {
                        break;
                    }
                    count++;
                }

                if (count >= 5)
                {
                    return true;
                }
            }

            return false;
        }

        private bool DeletePlayerTurnLogs()
        {
            try
            {
                var playerTurnLogs = _unitOfWork.PlayerTurnLog.GetPlayerTurnLogs();

                if (playerTurnLogs != null)
                    _unitOfWork.PlayerTurnLog.RemoveRange(playerTurnLogs);

                _unitOfWork.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return false;
            }
        }
    }
}
