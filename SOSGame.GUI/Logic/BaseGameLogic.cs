using SOSGame.GUI.Data.Objects;

namespace SOSGame.GUI.Logic
{
    public class BaseGameLogic : IBaseGameLogic
    {
        public GameBoard UpdateGameBoardAfterClick(int x, int y, GameBoard board, bool firstPlayer)
        {
            var selectedGameTile = board.Tiles[x, y];
            if (!selectedGameTile.FirstPlayerOwned.HasValue)
            {
                if (firstPlayer)
                {
                    selectedGameTile.Letter = board.FirstPlayerLetter;
                }
                else
                {
                    selectedGameTile.Letter = board.SecondPlayerLetter;
                }
                selectedGameTile.FirstPlayerOwned = firstPlayer;
            }
            return board;
        }

        public bool ChangeTurn(bool firstPlayer)
        {
            if (firstPlayer)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}