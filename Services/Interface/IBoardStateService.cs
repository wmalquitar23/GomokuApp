using GomokuApp.Common.Enum;
using GomokuApp.Common.Request;
using GomokuApp.Model.Entity;

namespace GomokuApp.Services.Interface
{
    public interface IBoardStateService
    {
        ApiResult InitializeBoard();
        ApiResult DeleteBoard();
        List<BoardState>? GetBoardState();
        ApiResult PlaceStone(PlaceStoneRequest request);
    }
}
