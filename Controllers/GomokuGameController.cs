using GomokuApp.Common.Enum;
using GomokuApp.Common.Request;
using GomokuApp.Common.Response;
using GomokuApp.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GomokuApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GomokuGameController
    {
        public readonly IBoardStateService _boardStateService;
        public readonly IPlayerTurnLogService _playerTurnLogService;
        public GomokuGameController(IBoardStateService boardStateService, IPlayerTurnLogService playerTurnLogService)
        {
            _boardStateService = boardStateService;
            _playerTurnLogService = playerTurnLogService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("initialize-board")]
        public JsonActionResult<JsonOutput> InitializeBoard()
        {
            var result = _boardStateService.InitializeBoard();
            var isSuccess = result == ApiResult.Success;

            return new JsonActionResult<JsonOutput>(new JsonOutput
            {
                Exception = null,
                success = true,
                message = isSuccess? "The board has been successfully initialized" : "An error occurred while initializing the board",
                result = result.ToString()
            });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("place-stone")]
        public JsonActionResult<JsonOutput> PlaceStone([FromBody] PlaceStoneRequest request)
        {
            var result = _boardStateService.PlaceStone(request);
            var isSuccess = result == ApiResult.Success || result == ApiResult.Win || result == ApiResult.ValidMove;

            return new JsonActionResult<JsonOutput>(new JsonOutput
            {
                Exception = null,
                success = isSuccess,
                message = result == ApiResult.Win ? request.Player + " Wins" : result.ToString(),
                result = result.ToString(),
            });
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get-board-state")]
        public JsonActionResult<JsonOutput> GetBoardState()
        {
            var result = _boardStateService.GetBoardState();
            var hasContent = result != null && result.Count > 0;

            return new JsonActionResult<JsonOutput>(new JsonOutput
            {
                Exception = null,
                success = hasContent,
                message = result != null ? "Showing the board state" : "An issue occurred while getting the board contents",
                result = result
            });
        }


        [AllowAnonymous]
        [HttpDelete]
        [Route("delete-board")]
        public JsonActionResult<JsonOutput> DeleteBoard()
        {
            var result = _boardStateService.DeleteBoard();
            var isSuccess = result == ApiResult.Success;
            return new JsonActionResult<JsonOutput>(new JsonOutput
            {
                Exception = null,
                success = isSuccess,
                message = isSuccess ? "Success" : "An issue occurred while clearing up the board",
                result = result
            });
        }
    }
}
