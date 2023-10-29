using System.Drawing;

namespace SOSGame.GUI.Pages
{
    public partial class SimpleGame : BaseGame
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
            
            GameLogic = GameLogicFactory.GetGameLogic("simple");
        }
    }
}
