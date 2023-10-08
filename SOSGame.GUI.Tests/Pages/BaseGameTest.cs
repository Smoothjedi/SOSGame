using SOSGame.GUI.Data.Factories;
using SOSGame.GUI.Data.Objects;
using SOSGame.GUI.Pages;
using SOSGame.GUI.Logic;

namespace SOSGame.GUI.Tests.Pages
{
    public partial class BaseGameTests
    {
        //Mock 
        public class BaseGameTest : BaseGame
        {
            public BaseGameTest() 
            {
                base.GameBoardFactory = new GameBoardFactory();
                base.BaseGameLogic = new BaseGameLogic();
                GameBoard = GameBoardFactory.CreateDefaultGameBoard();
            }
            public void TileClicked(int x, int y)
            {
                base.TileClicked(x, y);
            }
            public void ResetBoard(int size)
            {
                base.ResetBoard(size);
            }
            public GameBoard ReturnGameBoard()
            {
                return base.GameBoard;
            }
            public bool GetFirstPlayer()
            {
                return FirstPlayer;
            }
            public void SetLetter(string letter, int player) 
            {
                if (player == 1)
                {
                    GameBoard.FirstPlayerLetter = letter;
                }
                if (player == 2)
                {
                    GameBoard.SecondPlayerLetter = letter;
                }
            }
        }

    }
}
