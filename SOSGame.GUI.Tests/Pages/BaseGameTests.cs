using Moq;
using SOSGame.GUI.Data.Factories;
using SOSGame.GUI.Data.Objects;
using SOSGame.GUI.Logic;

namespace SOSGame.GUI.Tests.Pages
{
    public partial class BaseGameTests
    {

        [Fact]
        public void TileClickedSuccessfullyChangesTurnTest()
        {
            Mock<IBaseGameLogic> gblMock  = new Mock<IBaseGameLogic>();
            gblMock.Setup(m => m.UpdateGameBoardAfterClick(
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<GameBoard>(), It.IsAny<bool>())).Returns(true);
            gblMock.Setup(m => m.ChangeTurn(It.IsAny<bool>())).Returns(true);
            var baseGameTest = new BaseGameTest(new Mock<IGameBoardFactory>().Object, gblMock.Object);

            baseGameTest.TileClicked(0, 1);

            gblMock.Verify(m => m.ChangeTurn(It.IsAny<bool>()), Times.Once());
        }

        [Fact]
        public void TileClickedDoesNotChangeTurnTest()
        {
            Mock<IBaseGameLogic> gblMock = new Mock<IBaseGameLogic>();
            gblMock.Setup(m => m.UpdateGameBoardAfterClick(
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<GameBoard>(), It.IsAny<bool>())).Returns(false);
            gblMock.Setup(m => m.ChangeTurn(It.IsAny<bool>())).Returns(true);
            var baseGameTest = new BaseGameTest(new Mock<IGameBoardFactory>().Object, gblMock.Object);

            baseGameTest.TileClicked(0, 1);

            gblMock.Verify(m => m.ChangeTurn(It.IsAny<bool>()), Times.Never());
        }
    }
}
