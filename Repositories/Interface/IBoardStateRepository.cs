using GomokuApp.Common.Enum;
using GomokuApp.Model.DTO;
using GomokuApp.Model.Entity;

namespace GomokuApp.Repositories.Interface
{
    public interface IBoardStateRepository : IRepository<BoardState>
    {
        List<BoardState>? GetBoardState();
        BoardState? GetBoardState(int LocationX, int LocationY);

        List<List<BoardContentDto>>? GetBoardContent();

    }
}
