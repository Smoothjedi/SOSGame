namespace SOSGame.GUI.Data.Objects
{
    public class GameBoard
    {
        public GameTile[,] Tiles { get; set; }

        public GameBoard(int size)
        {
            if (size < 3)
            {
                throw new ArgumentException("Size must be three or more");
            }
            var tiles = new GameTile[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    tiles[i, j] = new GameTile();
                }
            }
            Tiles = tiles;
        }
    }
}
