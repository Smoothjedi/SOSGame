using Microsoft.AspNetCore.Components;
using SOSGame.GUI.Logic;

namespace SOSGame.GUI.Pages
{
    public partial class GeneralGame : BaseGame
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (string.IsNullOrEmpty(size)
                || (int.TryParse(size, out var boardSize) && (boardSize < 3 || boardSize > 10)))
            {
                GameBoard = GameBoardFactory.CreateDefaultGameBoard();
            }
            else
            {
                GameBoard = GameBoardFactory.CreateGameBoard(boardSize);
            }
            GameLogic = GameLogicFactory.GetGameLogic("general");
        }
    }
}
