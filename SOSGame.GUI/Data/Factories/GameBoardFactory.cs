using SOSGame.GUI.Data.Objects;

namespace SOSGame.GUI.Data.Factories
{
    public class GameBoardFactory : IGameBoardFactory
    {
        public GameBoard CreateDefaultGameBoard()
        {
            return CreateGameBoard(3);
        }

        public GameBoard CreateGameBoard(int size)
        {
            if (size < 3)
            {
                throw new ArgumentException("Size must be three or more");
            }
            var gameboard = new GameBoard();
            var tiles = new GameTile[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    tiles[i, j] = new GameTile() { X = i, Y = j };
                }
            }
            gameboard.Tiles = tiles;
            gameboard.Size = size;
            gameboard.Dimensions = size * 60 + ((size + 1) * 2);

            return gameboard;
        }
    }
}
