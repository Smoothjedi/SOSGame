using SOSGame.GUI.Data.Factories;
using SOSGame.GUI.Data.Objects;
using SOSGame.GUI.Logic;
using static SOSGame.GUI.Tests.Pages.BaseGameTests;

namespace SOSGame.GUI.Tests.Logic
{
    public class BaseGameLogicTestClassTests
    {
        [Fact]
        public void ChangeTurnTrueToFalseTest()
        {
            IGameLogic BaseGameLogicTestClass = new BaseGameLogicTestClass();
            Assert.False(BaseGameLogicTestClass.ChangeTurn(true));
        }

        [Fact]
        public void ChangeTurnFalseToTrueTest()
        {
            IGameLogic BaseGameLogicTestClass = new BaseGameLogicTestClass();
            Assert.True(BaseGameLogicTestClass.ChangeTurn(false));
        }

        //[Fact]
        //public void UpdateGameBoardAfterClickFirstPlayerSTest()
        //{
        //    IGameLogic BaseGameLogicTestClass = new BaseGameLogicTestClass();
        //    IGameBoardFactory gameBoardFactory = new GameBoardFactory();
        //    var board = gameBoardFactory.CreateDefaultGameBoard();

        //    Assert.True(BaseGameLogicTestClass.UpdateGameBoardAfterClick(board.Tiles[0, 1], "S"));
        //    Assert.Equal("S", board.Tiles[0, 1].Letter);
        //}

        //[Fact]
        //public void UpdateGameBoardAfterClickSecondPlayerSTest()
        //{
        //    IGameLogic BaseGameLogicTestClass = new BaseGameLogicTestClass();
        //    IGameBoardFactory gameBoardFactory = new GameBoardFactory();
        //    var board = gameBoardFactory.CreateDefaultGameBoard();

        //    Assert.True(BaseGameLogicTestClass.UpdateGameBoardAfterClick(board.Tiles[0, 1], "S"));
        //    Assert.Equal("S", board.Tiles[0, 1].Letter);
        //}

        //[Fact]
        //public void UpdateGameBoardAfterClickFirstPlayerOTest()
        //{
        //    IGameLogic BaseGameLogicTestClass = new BaseGameLogicTestClass();
        //    IGameBoardFactory gameBoardFactory = new GameBoardFactory();
        //    var board = gameBoardFactory.CreateDefaultGameBoard();

        //    Assert.True(BaseGameLogicTestClass.UpdateGameBoardAfterClick(board.Tiles[0, 1], "O"));
        //    Assert.Equal("O", board.Tiles[0, 1].Letter);
        //}

        //[Fact]
        //public void UpdateGameBoardAfterClickSecondPlayerOTest()
        //{
        //    IGameLogic BaseGameLogicTestClass = new BaseGameLogicTestClass();
        //    IGameBoardFactory gameBoardFactory = new GameBoardFactory();
        //    var board = gameBoardFactory.CreateDefaultGameBoard();

        //    Assert.True(BaseGameLogicTestClass.UpdateGameBoardAfterClick(board.Tiles[0, 1], "O"));
        //    Assert.Equal("O", board.Tiles[0, 1].Letter);
        //}

        //[Fact]
        //public void UpdateGameBoardAfterClickAlreadyOwnedTile()
        //{
        //    IGameLogic BaseGameLogicTestClass = new BaseGameLogicTestClass();
        //    IGameBoardFactory gameBoardFactory = new GameBoardFactory();
        //    var board = gameBoardFactory.CreateDefaultGameBoard();

        //    Assert.True(BaseGameLogicTestClass.UpdateGameBoardAfterClick(board.Tiles[0, 1], "S"));
        //    Assert.False(BaseGameLogicTestClass.UpdateGameBoardAfterClick(board.Tiles[0, 1], "O"));

        //    Assert.Equal("S", board.Tiles[0, 1].Letter);
        //}

        [Fact]
        public void CheckSNorthSOS()
        {
            IGameBoardFactory gameBoardFactory = new GameBoardFactory();
            var board = gameBoardFactory.CreateDefaultGameBoard();
            board.Tiles[0, 0].Letter = "S";
            board.Tiles[0, 1].Letter = "O";
            board.Tiles[0, 2].Letter = "S";

            var testClass = new BaseGameLogicTestClass();
            var result = testClass.CheckForScore(board.Tiles[0, 2], board);
            Assert.True(testClass.CheckForScore(board.Tiles[0, 2], board).Count == 1);            
        }

        [Fact]
        public void CheckSSouthSOS()
        {
            IGameBoardFactory gameBoardFactory = new GameBoardFactory();
            var board = gameBoardFactory.CreateDefaultGameBoard();
            board.Tiles[0, 0].Letter = "S";
            board.Tiles[0, 1].Letter = "O";
            board.Tiles[0, 2].Letter = "S";

            var testClass = new BaseGameLogicTestClass();
            var result = testClass.CheckForScore(board.Tiles[0, 0], board);
            Assert.True(testClass.CheckForScore(board.Tiles[0, 0], board).Count == 1);

        }
        [Fact]
        public void CheckSEastSOS() 
        {
            IGameBoardFactory gameBoardFactory = new GameBoardFactory();
            var board = gameBoardFactory.CreateDefaultGameBoard();
            board.Tiles[0, 1].Letter = "S";
            board.Tiles[1, 1].Letter = "O";
            board.Tiles[2, 1].Letter = "S";

            var testClass = new BaseGameLogicTestClass();
            var result = testClass.CheckForScore(board.Tiles[0, 1], board);
            Assert.True(testClass.CheckForScore(board.Tiles[0, 1], board).Count == 1);

        }
        [Fact]      
        public void CheckSWestSOS() 
        {
            IGameBoardFactory gameBoardFactory = new GameBoardFactory();
            var board = gameBoardFactory.CreateDefaultGameBoard();
            board.Tiles[0, 2].Letter = "S";
            board.Tiles[1, 2].Letter = "O";
            board.Tiles[2, 2].Letter = "S";

            var testClass = new BaseGameLogicTestClass();
            var result = testClass.CheckForScore(board.Tiles[0, 2], board);
            Assert.True(testClass.CheckForScore(board.Tiles[0, 2], board).Count == 1);

        }

        [Fact]
        public void CheckSNorthWestSOS()
        {
            IGameBoardFactory gameBoardFactory = new GameBoardFactory();
            var board = gameBoardFactory.CreateDefaultGameBoard();
            board.Tiles[0, 0].Letter = "S";
            board.Tiles[1, 1].Letter = "O";
            board.Tiles[2, 2].Letter = "S";

            var testClass = new BaseGameLogicTestClass();
            var result = testClass.CheckForScore(board.Tiles[2, 2], board);
            Assert.True(testClass.CheckForScore(board.Tiles[2, 2], board).Count == 1);
        }

        [Fact]
        public void CheckSSouthWestSOS()
        {
            IGameBoardFactory gameBoardFactory = new GameBoardFactory();
            var board = gameBoardFactory.CreateDefaultGameBoard();
            board.Tiles[2, 0].Letter = "S";
            board.Tiles[1, 1].Letter = "O";
            board.Tiles[0, 2].Letter = "S";

            var testClass = new BaseGameLogicTestClass();
            var result = testClass.CheckForScore(board.Tiles[2, 0], board);
            Assert.True(testClass.CheckForScore(board.Tiles[2, 0], board).Count == 1);

        }
        [Fact]
        public void CheckSNorthEastSOS()
        {
            IGameBoardFactory gameBoardFactory = new GameBoardFactory();
            var board = gameBoardFactory.CreateDefaultGameBoard();
            board.Tiles[0, 2].Letter = "S";
            board.Tiles[1, 1].Letter = "O";
            board.Tiles[2, 0].Letter = "S";

            var testClass = new BaseGameLogicTestClass();
            var result = testClass.CheckForScore(board.Tiles[0, 2], board);
            Assert.True(testClass.CheckForScore(board.Tiles[0, 2], board).Count == 1);

        }
        [Fact]
        public void CheckSSouthEastSOS()
        {
            IGameBoardFactory gameBoardFactory = new GameBoardFactory();
            var board = gameBoardFactory.CreateDefaultGameBoard();
            board.Tiles[0, 0].Letter = "S";
            board.Tiles[1, 1].Letter = "O";
            board.Tiles[2, 2].Letter = "S";

            var testClass = new BaseGameLogicTestClass();
            var result = testClass.CheckForScore(board.Tiles[0, 0], board);
            Assert.True(testClass.CheckForScore(board.Tiles[0, 0], board).Count == 1);

        }
        [Fact]
        public void CheckONorthEastSouthWestSOS()
        {
            IGameBoardFactory gameBoardFactory = new GameBoardFactory();
            var board = gameBoardFactory.CreateDefaultGameBoard();
            board.Tiles[0, 0].Letter = "S";
            board.Tiles[1, 1].Letter = "O";
            board.Tiles[2, 2].Letter = "S";

            var testClass = new BaseGameLogicTestClass();
            var result = testClass.CheckForScore(board.Tiles[1, 1], board);
            Assert.True(testClass.CheckForScore(board.Tiles[1, 1], board).Count == 1);

        }
        [Fact]
        public void CheckONorthSouthSOS()
        {
            IGameBoardFactory gameBoardFactory = new GameBoardFactory();
            var board = gameBoardFactory.CreateDefaultGameBoard();
            board.Tiles[1, 0].Letter = "S";
            board.Tiles[1, 1].Letter = "O";
            board.Tiles[1, 2].Letter = "S";

            var testClass = new BaseGameLogicTestClass();
            var result = testClass.CheckForScore(board.Tiles[1, 1], board);
            Assert.True(testClass.CheckForScore(board.Tiles[1, 1], board).Count == 1);

        }
        [Fact]
        public void CheckNorthEastSouthWestSOS()
        {
            IGameBoardFactory gameBoardFactory = new GameBoardFactory();
            var board = gameBoardFactory.CreateDefaultGameBoard();
            board.Tiles[2, 0].Letter = "S";
            board.Tiles[1, 1].Letter = "O";
            board.Tiles[0, 2].Letter = "S";

            var testClass = new BaseGameLogicTestClass();
            var result = testClass.CheckForScore(board.Tiles[1, 1], board);
            Assert.True(testClass.CheckForScore(board.Tiles[1, 1], board).Count == 1);

        }
        [Fact]
        public void CheckOWestEastSOS()
        {
            IGameBoardFactory gameBoardFactory = new GameBoardFactory();
            var board = gameBoardFactory.CreateDefaultGameBoard();
            board.Tiles[0, 1].Letter = "S";
            board.Tiles[1, 1].Letter = "O";
            board.Tiles[2, 1].Letter = "S";

            var testClass = new BaseGameLogicTestClass();
            var result = testClass.CheckForScore(board.Tiles[1, 1], board);
            Assert.True(testClass.CheckForScore(board.Tiles[1, 1], board).Count == 1);
        }

        [Fact]
        public void GetRandomLetterFromStringTest()
        {
            var gameLogicTest = new BaseGameLogicTestClass();
            var result = gameLogicTest.GetRandomLetterFromStringTest("TestString");
            for (int i = 0; i < 1000; i++) 
            {
                Assert.Contains(result, "TestString");

            }
        }

        [Fact]
        public void MiniMaxAlphaBetaTest()
        {
            var gameLogicTest = new BaseGameLogicTestClass();
            IGameBoardFactory gameBoardFactory = new GameBoardFactory();
            var board = gameBoardFactory.CreateDefaultGameBoard();

            var move = gameLogicTest.MiniMaxAlphaBetaTest(1, true, int.MaxValue, int.MinValue, board);
            Assert.NotNull(move);
            Assert.NotEqual(-1, move.X);
            Assert.NotEqual(-1, move.Y);
            Assert.True(Equals(move.Letter, "S") || Equals(move.Letter, "O"));
            Assert.True(move.Score >= 0);
            Assert.True(move.X < board.Size);
            Assert.True(move.Y < board.Size);
        }
    }
}