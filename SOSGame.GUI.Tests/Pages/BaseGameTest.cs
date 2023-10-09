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
            public BaseGameTest(IGameBoardFactory factory, IBaseGameLogic logic) 
            {
                base.GameBoardFactory = factory;
                base.BaseGameLogic = logic;
                GameBoard = GameBoardFactory.CreateDefaultGameBoard();
            }
            public void TileClicked(int x, int y)
            {
                base.TileClicked(x, y);
            }
        }

    }
}
