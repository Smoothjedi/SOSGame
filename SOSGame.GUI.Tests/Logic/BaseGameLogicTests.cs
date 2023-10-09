using SOSGame.GUI.Data.Factories;
using SOSGame.GUI.Data.Objects;
using SOSGame.GUI.Logic;
using static SOSGame.GUI.Tests.Pages.BaseGameTests;

namespace SOSGame.GUI.Tests.Logic
{
    public class BaseGameLogicTests
    {
        [Fact]
        public void ChangeTurnTrueToFalseTest()
        {
            IBaseGameLogic baseGameLogic = new BaseGameLogic();
            Assert.False(baseGameLogic.ChangeTurn(true));
        }
        [Fact]
        public void ChangeTurnFalseToTrueTest()
        {
            IBaseGameLogic baseGameLogic = new BaseGameLogic();
            Assert.True(baseGameLogic.ChangeTurn(false));
        }


        [Fact]
        public void UpdateGameBoardAfterClickFirstPlayerSTest()
        {
            IBaseGameLogic baseGameLogic = new BaseGameLogic();
            IGameBoardFactory gameBoardFactory = new GameBoardFactory();
            var board = gameBoardFactory.CreateDefaultGameBoard();

            Assert.True(baseGameLogic.UpdateGameBoardAfterClick(0, 1, board, true));
            Assert.True(board.Tiles[0, 1].FirstPlayerOwned);
            Assert.Equal("S", board.Tiles[0, 1].Letter);
        }

        [Fact]
        public void UpdateGameBoardAfterClickSecondPlayerSTest()
        {
            IBaseGameLogic baseGameLogic = new BaseGameLogic();
            IGameBoardFactory gameBoardFactory = new GameBoardFactory();
            var board = gameBoardFactory.CreateDefaultGameBoard();

            Assert.True(baseGameLogic.UpdateGameBoardAfterClick(0, 1, board, false));
            Assert.False(board.Tiles[0, 1].FirstPlayerOwned);
            Assert.Equal("S", board.Tiles[0, 1].Letter);
        }

        [Fact]
        public void UpdateGameBoardAfterClickFirstPlayerOTest()
        {
            IBaseGameLogic baseGameLogic = new BaseGameLogic();
            IGameBoardFactory gameBoardFactory = new GameBoardFactory();
            var board = gameBoardFactory.CreateDefaultGameBoard();
            board.FirstPlayerLetter = "O";

            Assert.True(baseGameLogic.UpdateGameBoardAfterClick(0, 1, board, true));
            Assert.True(board.Tiles[0, 1].FirstPlayerOwned);
            Assert.Equal("O", board.Tiles[0, 1].Letter);
        }

        [Fact]
        public void UpdateGameBoardAfterClickSecondPlayerOTest()
        {
            IBaseGameLogic baseGameLogic = new BaseGameLogic();
            IGameBoardFactory gameBoardFactory = new GameBoardFactory();
            var board = gameBoardFactory.CreateDefaultGameBoard();
            board.SecondPlayerLetter = "O";

            Assert.True(baseGameLogic.UpdateGameBoardAfterClick(0, 1, board, false));
            Assert.False(board.Tiles[0, 1].FirstPlayerOwned);
            Assert.Equal("O", board.Tiles[0, 1].Letter);
        }

        [Fact]
        public void UpdateGameBoardAfterClickAlreadyOwnedTile()
        {
            IBaseGameLogic baseGameLogic = new BaseGameLogic();
            IGameBoardFactory gameBoardFactory = new GameBoardFactory();
            var board = gameBoardFactory.CreateDefaultGameBoard();
            board.SecondPlayerLetter = "O";

            Assert.True(baseGameLogic.UpdateGameBoardAfterClick(0, 1, board, true));
            Assert.False(baseGameLogic.UpdateGameBoardAfterClick(0, 1, board, false));

            Assert.Equal("S", board.Tiles[0, 1].Letter);
            Assert.True(board.Tiles[0, 1].FirstPlayerOwned);
        }
    }
}