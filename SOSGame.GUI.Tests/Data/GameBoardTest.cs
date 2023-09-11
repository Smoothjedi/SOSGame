using SOSGame.GUI.Data.Objects;

namespace SOSGame.GUI.Tests.Data
{
    public class GameBoardTest
    {
        [Fact]
        public void GameBoardSizeFailure()
        {
            Assert.Throws<ArgumentException>(() => new GameBoard(2));
        }

        [Fact]
        public void GameBoardSizeSuccess()
        {
            List<int> size = new List<int> { 3, 4, 10 };
            foreach (int i in size) 
            {
                var board = new GameBoard(3);
                Assert.NotNull(board);
                Assert.NotNull(board.Tiles);
            }
        }
    }
}