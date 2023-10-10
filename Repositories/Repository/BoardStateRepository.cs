using GomokuApp.Common.Constants;
using GomokuApp.Common.Enum;
using GomokuApp.Common.Logging;
using GomokuApp.Data;
using GomokuApp.Model.DTO;
using GomokuApp.Model.Entity;
using GomokuApp.Repositories.Interface;

namespace GomokuApp.Repositories.Repository
{
    public class BoardStateRepository : Repository<BoardState>, IBoardStateRepository
    {
        public BoardStateRepository(DBContext context) : base(context)
        {

        }

        public List<List<BoardContentDto>>? GetBoardContent()
        {
            int columnCounter = 0;
            var boardContent = new List<List<BoardContentDto>>();
            var rowContent = new List<BoardContentDto>();
            
            try
            {
                var result = Context.Set<BoardState>().ToList();

                for (var i = 0; i < result.Count; i++)
                {
                    var content = GenerateBoardContentDto(result[i]);

                    if (columnCounter < BoardEntity.BoardSize)
                    {
                        rowContent.Add(content);
                        columnCounter++;
                    }
                    else
                    {
                        boardContent.Add(rowContent);
                        columnCounter = 0;
                        rowContent = new List<BoardContentDto>();
                    }
                }

                return boardContent;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return null;
            }
        }

        public List<BoardState>? GetBoardState()
        {
            try
            {
                return Context.Set<BoardState>().ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return null;
            }
        }

        public BoardState? GetBoardState(int LocationX, int LocationY)
        {
            try
            {
               var result = Context.Set<BoardState>()
                    .Where(x => x.LocationX == LocationX && x.LocationY == LocationY && x.OccupiedBy == "None").FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return null;
            }
        }
    
        private BoardContentDto GenerateBoardContentDto(BoardState boardState)
        {
            return new BoardContentDto
            {
                LocationX = boardState.LocationX,
                LocationY = boardState.LocationY,
                Player = boardState.OccupiedBy
            };
        }
    }
}
