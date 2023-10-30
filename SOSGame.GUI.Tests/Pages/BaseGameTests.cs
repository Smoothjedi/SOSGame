using Blazor.Extensions;
using Blazor.Extensions.Canvas.Canvas2D;
using Microsoft.AspNetCore.Components.Web;
using Moq;
using SOSGame.GUI.Data.Factories;
using SOSGame.GUI.Data.Objects;
using SOSGame.GUI.Logic;
using System.Windows.Input;

namespace SOSGame.GUI.Tests.Pages
{
    public partial class BaseGameTests
    {

        [Fact]
        public void CanvasClickedSuccessfullyChangesTurnTest()
        {
            Mock<IGameLogic> gblMock  = new Mock<IGameLogic>();
            gblMock.Setup(m => m.UpdateGameBoardAfterClick(
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<GameBoard>(), It.IsAny<bool>())).Returns(true);
            gblMock.Setup(m => m.CheckForScore(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<GameBoard>())).Returns(new List<List<GameTile>>());
            gblMock.Setup(m => m.ChangeTurn(It.IsAny<bool>())).Returns(true);
            var canvasMock = new Mock<ICanvasLogic>();
            canvasMock.Setup(m => m.DrawBoardAsync(It.IsAny<GameBoard>(), It.IsAny<BECanvasComponent>()));
            canvasMock.Setup(m => m.DrawScoreLines(It.IsAny<List<GameTile>>(), It.IsAny<string>(), It.IsAny<BECanvasComponent>()));
            canvasMock.Setup(m => m.DrawLettersOnCanvas(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<GameBoard>(), It.IsAny<BECanvasComponent>()));


            var baseGameTest = new BaseGameTest(new Mock<IGameBoardFactory>().Object, gblMock.Object);
            baseGameTest.SetGameBoard(new GameBoard());
            baseGameTest.SetCanvasLogic(canvasMock.Object);
            baseGameTest.ModifyCanvasTest(20, 40);

            gblMock.Verify(m => m.ChangeTurn(It.IsAny<bool>()), Times.Once());
        }

        [Fact]
        public void CanvasClickedDoesNotChangeTurnTest()
        {
            Mock<IGameLogic> gblMock = new Mock<IGameLogic>();
            gblMock.Setup(m => m.UpdateGameBoardAfterClick(
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<GameBoard>(), It.IsAny<bool>())).Returns(true);
            gblMock.Setup(m => m.CheckForScore(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<GameBoard>())).Returns(new List<List<GameTile>>());
            gblMock.Setup(m => m.ChangeTurn(It.IsAny<bool>())).Returns(true);
            var canvasMock = new Mock<ICanvasLogic>();
            canvasMock.Setup(m => m.DrawBoardAsync(It.IsAny<GameBoard>(), It.IsAny<BECanvasComponent>()));
            canvasMock.Setup(m => m.DrawScoreLines(It.IsAny<List<GameTile>>(), It.IsAny<string>(), It.IsAny<BECanvasComponent>()));
            canvasMock.Setup(m => m.DrawLettersOnCanvas(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<GameBoard>(), It.IsAny<BECanvasComponent>()));


            var baseGameTest = new BaseGameTest(new Mock<IGameBoardFactory>().Object, gblMock.Object);
            baseGameTest.SetGameBoard(new GameBoard());
            baseGameTest.SetCanvasLogic(canvasMock.Object);
            baseGameTest.ModifyCanvasTest(20, 400000);

            gblMock.Verify(m => m.ChangeTurn(It.IsAny<bool>()), Times.Never());
        }

        [Fact]
        public void CanvasClickedDoesNotChangeTurnGameOverTest()
        {
            Mock<IGameLogic> gblMock = new Mock<IGameLogic>();
            gblMock.Setup(m => m.UpdateGameBoardAfterClick(
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<GameBoard>(), It.IsAny<bool>())).Returns(true);
            gblMock.Setup(m => m.CheckForScore(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<GameBoard>())).Returns(new List<List<GameTile>>());
            gblMock.Setup(m => m.ChangeTurn(It.IsAny<bool>())).Returns(true);
            var canvasMock = new Mock<ICanvasLogic>();
            canvasMock.Setup(m => m.DrawBoardAsync(It.IsAny<GameBoard>(), It.IsAny<BECanvasComponent>()));
            canvasMock.Setup(m => m.DrawScoreLines(It.IsAny<List<GameTile>>(), It.IsAny<string>(), It.IsAny<BECanvasComponent>()));
            canvasMock.Setup(m => m.DrawLettersOnCanvas(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<GameBoard>(), It.IsAny<BECanvasComponent>()));


            var baseGameTest = new BaseGameTest(new Mock<IGameBoardFactory>().Object, gblMock.Object);
            var board = new GameBoard();
            
            baseGameTest.SetGameBoard(new GameBoard());
            baseGameTest.SetGameOver(true);

            baseGameTest.SetCanvasLogic(canvasMock.Object);
            baseGameTest.ModifyCanvasTest(20, 40);

            gblMock.Verify(m => m.ChangeTurn(It.IsAny<bool>()), Times.Never());
        }
    }
}
