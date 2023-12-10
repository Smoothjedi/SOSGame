using SOSGame.GUI.Data.Factories;

namespace SOSGame.GUI.Tests.Data.Factories {
    public class GameBoardFactoryTest {
        [Fact]
        public void CreateGameBoardSizeFailure() {
            IGameBoardFactory factory = new GameBoardFactory();
            Assert.Throws<ArgumentException>(() => factory.CreateGameBoard(2));
        }

        [Fact]
        public void CreateGameBoardSizeSuccess() {
            IGameBoardFactory factory = new GameBoardFactory();
            List<int> size = new List<int> { 3, 4, 10 };
            foreach (int i in size) {
                var board = factory.CreateGameBoard(i);
                Assert.NotNull(board);
                Assert.NotNull(board.Tiles);
                Assert.Equal(i, board.Size);
                Assert.NotNull(board.Tiles[i - 1, i - 1]);
            }
        }

        [Fact]
        public void GameBoardDefaultSizeSuccess() {
            IGameBoardFactory factory = new GameBoardFactory();
            var board = factory.CreateDefaultGameBoard();
            Assert.NotNull(board);
            Assert.NotNull(board.Tiles);
            Assert.Equal(3, board.Size);
        }
    }
}