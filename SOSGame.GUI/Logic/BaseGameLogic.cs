using SOSGame.GUI.Data.Objects;
using System.Collections.Generic;

namespace SOSGame.GUI.Logic
{
    public abstract class BaseGameLogic : IGameLogic
    {
        public abstract bool CheckForGameOver(int firstPlayerScore, int SecondPlayerScore, GameBoard board);

        public bool UpdateGameBoardAfterClick(int x, int y, GameBoard board, bool firstPlayer)
        {
            if (x >= board.Size ||  y >= board.Size)
            {
                return false;
            }
            var selectedGameTile = board.Tiles[x, y];
            if (string.IsNullOrEmpty(selectedGameTile.Letter))
            {
                if (firstPlayer)
                {
                    selectedGameTile.Letter = board.FirstPlayerLetter;
                }
                else
                {
                    selectedGameTile.Letter = board.SecondPlayerLetter;
                }
                return true;
            }
            return false;
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

        protected bool CheckIfBoardIsFull(GameBoard board)
        {
            foreach (var tile in board.Tiles)
            {
                if (string.IsNullOrEmpty(tile.Letter))
                {
                    return false;
                }
            }
            return true;
        }

        public List<List<GameTile>> CheckForScore(int x, int y, GameBoard board)
        {
            var scoreTiles = new List<List<GameTile>>();
            if (board == null) return new List<List<GameTile>>();

            var selectedTile = board.Tiles[x, y];
            if (string.Equals("S", selectedTile.Letter))
            {
                //West
                if (x - 1 > 0 && string.Equals("O", board.Tiles[x - 1, y].Letter))
                {
                    if (x - 2 >= 0 && string.Equals("S", board.Tiles[x - 2, y].Letter))
                    {
                        scoreTiles.Add(new List<GameTile>() { board.Tiles[x, y], board.Tiles[x - 2, y] });
                    }
                }
                //Northwest
                if (x - 1 > 0 && y - 1 > 0 && string.Equals("O", board.Tiles[x - 1, y - 1].Letter))
                {
                    if (x - 2 >= 0 && y - 2 >= 0 && string.Equals("S", board.Tiles[x - 2, y - 2].Letter))
                    {
                        scoreTiles.Add(new List<GameTile>() { board.Tiles[x, y], board.Tiles[x - 2, y - 2] });
                    }
                }
                //North
                if (y - 1 > 0 && string.Equals("O", board.Tiles[x, y - 1].Letter))
                {
                    if (y - 2 >= 0 && string.Equals("S", board.Tiles[x, y - 2].Letter))
                    {
                        scoreTiles.Add(new List<GameTile>() { board.Tiles[x, y], board.Tiles[x, y - 2] });
                    }
                }
                //Northeast
                if (x + 1 < board.Size && y - 1 > 0 && string.Equals("O", board.Tiles[x + 1, y - 1].Letter))
                {
                    if (x + 2 < board.Size && y - 2 >= 0 && string.Equals("S", board.Tiles[x + 2, y - 2].Letter))
                    {
                        scoreTiles.Add(new List<GameTile>() { board.Tiles[x, y], board.Tiles[x + 2, y - 2] });
                    }
                }
                //East
                if (x + 1 < board.Size && string.Equals("O", board.Tiles[x + 1, y].Letter))
                {
                    if (x + 2 < board.Size && string.Equals("S", board.Tiles[x + 2, y].Letter))
                    {
                        scoreTiles.Add(new List<GameTile>() { board.Tiles[x, y], board.Tiles[x + 2, y] });
                    }
                }
                //SouthEast
                if (x + 1 < board.Size && y + 1 < board.Size && string.Equals("O", board.Tiles[x + 1, y + 1].Letter))
                {
                    if (x + 2 < board.Size && y + 2 < board.Size && string.Equals("S", board.Tiles[x + 2, y + 2].Letter))
                    {
                        scoreTiles.Add(new List<GameTile>() { board.Tiles[x, y], board.Tiles[x + 2, y + 2] });
                    }
                }
                //South
                if (y + 1 < board.Size && string.Equals("O", board.Tiles[x, y + 1].Letter))
                {
                    if (y + 2 < board.Size && string.Equals("S", board.Tiles[x, y + 2].Letter))
                    {
                        scoreTiles.Add(new List<GameTile>() { board.Tiles[x, y], board.Tiles[x, y + 2] });
                    }
                }
                //Southwest
                if (x - 1 > 0 && y + 1 < board.Size && string.Equals("O", board.Tiles[x - 1, y + 1].Letter))
                {
                    if (x - 2 >= 0 && y + 2 < board.Size && string.Equals("S", board.Tiles[x - 2, y + 2].Letter))
                    {
                        scoreTiles.Add(new List<GameTile>() { board.Tiles[x, y], board.Tiles[x - 2, y + 2] });
                    }
                }
            }
            else
            {
                //West + East
                if (x - 1 >= 0 && x + 1 < board.Size 
                    && string.Equals("S", board.Tiles[x - 1, y].Letter) 
                    && string.Equals("S", board.Tiles[x + 1, y].Letter))
                {
                    scoreTiles.Add(new List<GameTile>() { board.Tiles[x - 1, y], board.Tiles[x + 1, y] });
                }
                //Northwest + SouthEast
                if (x - 1 >= 0 && y - 1 >= 0 && x + 1 < board.Size && y + 1 < board.Size
                    && string.Equals("S", board.Tiles[x - 1, y - 1].Letter)
                    && string.Equals("S", board.Tiles[x + 1, y + 1].Letter))
                {                  
                    scoreTiles.Add(new List<GameTile>() { board.Tiles[x - 1, y - 1], board.Tiles[x +1, y + 1] });                    
                }
                //North + South
                if (y - 1 >= 0 && y + 1 < board.Size
                    && string.Equals("S", board.Tiles[x, y - 1].Letter)
                    && string.Equals("S", board.Tiles[x, y + 1].Letter))
                { 
                    scoreTiles.Add(new List<GameTile>() { board.Tiles[x, y - 1], board.Tiles[x, y + 1] });                    
                }
                //Northeast + Southwest
                if (x + 1 < board.Size && y - 1 >= 0 && x - 1 >= 0 && y + 1 < board.Size
                    && string.Equals("S", board.Tiles[x + 1, y - 1].Letter)
                    && string.Equals("S", board.Tiles[x - 1, y + 1].Letter))
                {
                    scoreTiles.Add(new List<GameTile>() { board.Tiles[x + 1, y - 1], board.Tiles[x - 1, y + 1] });
                }

            }
            return scoreTiles;

        }
    }
}