using Blazor.Extensions;
using Moq;
using SOSGame.GUI.Data.Factories;
using SOSGame.GUI.Data.Objects;
using SOSGame.GUI.Logic;

namespace SOSGame.GUI.Tests.Pages { 
    public partial class BaseGameTests {

        [Fact]
        public void CanvasClickedCallsToDrawLine() {
            Mock<IGameLogic> gblMock = new Mock<IGameLogic>();
            //gblMock.Setup(m => m.UpdateGameBoardAfterClick(It.IsAny<GameTile>(), It.IsAny<string>())).Returns(true);
            gblMock.Setup(m => m.CheckForScore(It.IsAny<GameTile>(), It.IsAny<GameBoard>()))
                .Returns(new List<List<GameTile>>()
                {
                    {
                        new List<GameTile>
                        {
                            new GameTile() { X = 0, Y = 1, Letter = "S" },
                            new GameTile() { X = 2, Y = 1, Letter="S" }
                        }
                    }
                });
            Mock<IGameLogger> logMock = new Mock<IGameLogger>();
            //gblMock.
            gblMock.Setup(m => m.ChangeTurn(It.IsAny<bool>())).Returns(true);
            var canvasMock = new Mock<ICanvasLogic>();
            canvasMock.Setup(m => m.DrawBoardAsync(It.IsAny<GameBoard>(), 
                It.IsAny<BECanvasComponent>()));
            canvasMock.Setup(m => m.DrawScoreLines(It.IsAny<List<GameTile>>(), 
                It.IsAny<string>(), It.IsAny<BECanvasComponent>()));
            canvasMock.Setup(m => m.DrawLettersOnCanvas(It.IsAny<Move>(), 
                It.IsAny<bool>(), It.IsAny<GameBoard>(), It.IsAny<BECanvasComponent>()));

            var gameBoard = new GameBoardFactory().CreateDefaultGameBoard();
            gameBoard.Tiles[0, 1].Letter = "S";
            gameBoard.Tiles[2, 1].Letter = "S";
            var baseGameTest = new BaseGameTest(new Mock<IGameBoardFactory>().Object, 
                gblMock.Object);
            baseGameTest.SetGameBoard(gameBoard);
            baseGameTest.SetCanvasLogic(canvasMock.Object);
            logMock.Setup(m => m.Log(It.IsAny<string>()));
            baseGameTest.SetLogging(logMock.Object);
            var move = new Move("O", 1, 1);
            baseGameTest.ModifyCanvasTest(move);

            //gblMock.Verify(m => m.ChangeTurn(It.IsAny<bool>()), Times.Once());

            canvasMock.Verify(m => m.DrawScoreLines(It.IsAny<List<GameTile>>(), It.IsAny<string>(),
                It.IsAny<BECanvasComponent>()), Times.Once());
        }

        [Fact]
        public void CanvasClickedDoesNotDrawLine() {
            Mock<IGameLogic> gblMock = new Mock<IGameLogic>();
            gblMock.Setup(m => m.CheckForScore(It.IsAny<GameTile>(), It.IsAny<GameBoard>()))
                .Returns(new List<List<GameTile>>());
            gblMock.Setup(m => m.ChangeTurn(It.IsAny<bool>())).Returns(true);
            var canvasMock = new Mock<ICanvasLogic>();
            canvasMock.Setup(m => m.DrawBoardAsync(It.IsAny<GameBoard>(), 
                It.IsAny<BECanvasComponent>()));
            canvasMock.Setup(m => m.DrawScoreLines(It.IsAny<List<GameTile>>(), 
                It.IsAny<string>(), It.IsAny<BECanvasComponent>()));
            canvasMock.Setup(m => m.DrawLettersOnCanvas(It.IsAny<Move>(), It.IsAny<bool>(), 
                It.IsAny<GameBoard>(), It.IsAny<BECanvasComponent>()));


            var baseGameTest = new BaseGameTest(new Mock<IGameBoardFactory>().Object, gblMock.Object);
            var gameBoard = new GameBoardFactory().CreateDefaultGameBoard();

            baseGameTest.SetGameBoard(gameBoard);
            baseGameTest.SetGameOver(true);

            baseGameTest.SetCanvasLogic(canvasMock.Object);
            var move = new Move("O", 0, 0);
            baseGameTest.ModifyCanvasTest(move);

            canvasMock.Verify(m => m.DrawScoreLines(It.IsAny<List<GameTile>>(), It.IsAny<string>(), 
                It.IsAny<BECanvasComponent>()), Times.Never());
        }
    }
}
