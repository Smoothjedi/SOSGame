using SOSGame.GUI.Data.Objects;

namespace SOSGame.GUI.Logic
{
    public abstract class BaseGameLogic : IGameLogic
    {
        public abstract bool CheckForGameOver(int firstPlayerScore, int SecondPlayerScore, GameBoard board); 

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

        public List<List<GameTile>> CheckForScore(GameTile tile, GameBoard gameBoard)
        {
            var scoreTiles = new List<List<GameTile>>();
            if (gameBoard == null) return new List<List<GameTile>>();
            var westTile = GetWestTile(tile, gameBoard);
            var northWestTile = GetNorthWestTile(tile, gameBoard);
            var northTile = GetNorthTile(tile, gameBoard);
            var northEastTile = GetNorthEastTile(tile, gameBoard);
            var eastTile = GetEastTile(tile, gameBoard);
            var southEastTile = GetSouthEastTile(tile, gameBoard);
            var southTile = GetSouthTile(tile, gameBoard);
            var southWestTile = GetSouthWestTile(tile, gameBoard);

            //var selectedTile = board.Tiles[x, y];
            if (string.Equals("S", tile.Letter))
            {
                //West
                if (string.Equals("O", westTile?.Letter))
                {
                    var secondWestTile = GetWestTile(westTile, gameBoard);
                    if (string.Equals("S", secondWestTile?.Letter))
                    {
                        scoreTiles.Add(new List<GameTile>() { tile, secondWestTile });
                    }
                }
                //Northwest
                if (string.Equals("O", northWestTile?.Letter))
                {
                    var secondNorthWestTile = GetNorthWestTile(northWestTile, gameBoard);
                    if (string.Equals("S", secondNorthWestTile?.Letter))
                    {
                        scoreTiles.Add(new List<GameTile>() { tile, secondNorthWestTile });
                    }
                }
                //North
                if (string.Equals("O", northTile?.Letter))
                {
                    var secondNorthTile = GetNorthTile(northTile, gameBoard);
                    if (string.Equals("S", secondNorthTile?.Letter))
                    {
                        scoreTiles.Add(new List<GameTile>() { tile, secondNorthTile });
                    }
                }
                //Northeast
                if (string.Equals("O", northEastTile?.Letter))
                {
                    var secondNorthEastTile = GetNorthEastTile(northEastTile, gameBoard);
                    if (string.Equals("S", secondNorthEastTile?.Letter))
                    {
                        scoreTiles.Add(new List<GameTile>() { tile, secondNorthEastTile });
                    }
                }
                //East
                if (string.Equals("O", eastTile?.Letter))
                {
                    var secondEastTile = GetEastTile(eastTile, gameBoard);
                    if (string.Equals("S", secondEastTile?.Letter))
                    {
                        scoreTiles.Add(new List<GameTile>() { tile, secondEastTile });
                    }
                }
                //SouthEast
                if (string.Equals("O", southEastTile?.Letter))
                {
                    var secondSouthEastTile = GetSouthEastTile(southEastTile, gameBoard);
                    if (string.Equals("S", secondSouthEastTile?.Letter))
                    {
                        scoreTiles.Add(new List<GameTile>() { tile, secondSouthEastTile });
                    }
                }
                //South
                if (string.Equals("O", southTile?.Letter))
                {
                    var secondSouthTile = GetSouthTile(southTile, gameBoard);
                    if (string.Equals("S", secondSouthTile?.Letter))
                    {
                        scoreTiles.Add(new List<GameTile>() { tile, secondSouthTile });
                    }
                }
                //Southwest
                if (string.Equals("O", southWestTile?.Letter))
                {
                    var secondSouthwestTile = GetSouthWestTile(southWestTile, gameBoard);
                    if (string.Equals("S", secondSouthwestTile?.Letter))
                    {
                        scoreTiles.Add(new List<GameTile>() { tile, secondSouthwestTile });
                    }
                }
            }
            else
            {
                //West + East
                if (string.Equals("S", westTile?.Letter)
                    && string.Equals("S", eastTile?.Letter))
                {
                    scoreTiles.Add(new List<GameTile>() { westTile, eastTile });
                }
                //Northwest + SouthEast
                if (string.Equals("S", northWestTile?.Letter)
                    && string.Equals("S", southEastTile?.Letter))
                {
                    scoreTiles.Add(new List<GameTile>() { northWestTile, southEastTile });
                }
                //North + South
                if (string.Equals("S", northTile?.Letter)
                    && string.Equals("S", southTile?.Letter))
                {
                    scoreTiles.Add(new List<GameTile>() { northTile, southTile });
                }
                //Northeast + Southwest
                if (string.Equals("S", northEastTile?.Letter)
                    && string.Equals("S", southWestTile?.Letter))
                {
                    scoreTiles.Add(new List<GameTile>() { northEastTile, southWestTile });
                }

            }
            return scoreTiles;
        }

        protected GameTile? GetNorthWestTile(GameTile? tile, GameBoard gameBoard)
        {
            if (tile != null 
                && tile.X - 1 >= 0 
                && tile.Y - 1 >= 0)
            {
                return gameBoard.Tiles[tile.X - 1, tile.Y - 1];
            }
            return null;
        }

        protected GameTile? GetNorthTile(GameTile? tile, GameBoard gameBoard)
        {
            if (tile != null 
                && tile.Y - 1 >= 0)
            {
                return gameBoard.Tiles[tile.X, tile.Y - 1];
            }
            return null;
        }

        protected GameTile? GetNorthEastTile(GameTile? tile, GameBoard gameBoard)
        {
            if (tile != null 
                && tile.X + 1 < gameBoard.Size 
                && tile.Y - 1 >= 0)
            {
                return gameBoard.Tiles[tile.X + 1, tile.Y - 1];
            }
            return null;
        }

        protected GameTile? GetEastTile(GameTile? tile, GameBoard gameBoard)
        {
            if (tile != null 
                && tile.X + 1 < gameBoard.Size)
            {
                return gameBoard.Tiles[tile.X + 1, tile.Y];
            }
            return null;
        }

        protected GameTile? GetSouthEastTile(GameTile? tile, GameBoard gameBoard)
        {
            if (tile != null 
                && tile.X + 1 < gameBoard.Size 
                && tile.Y + 1 < gameBoard.Size)
            {
                return gameBoard.Tiles[tile.X + 1, tile.Y + 1];
            }
            return null;
        }

        protected GameTile? GetSouthTile(GameTile? tile, GameBoard gameBoard)
        {
            if (tile != null 
                && tile.Y + 1 < gameBoard.Size)
            {
                return gameBoard.Tiles[tile.X, tile.Y + 1];
            }
            return null;
        }

        protected GameTile? GetSouthWestTile(GameTile? tile, GameBoard gameBoard)
        {
            if (tile != null 
                && tile.X - 1 >= 0 
                && tile.Y + 1 < gameBoard.Size)
            {
                return gameBoard.Tiles[tile.X - 1, tile.Y + 1];
            }
            return null;
        }

        protected GameTile? GetWestTile(GameTile? tile, GameBoard gameBoard)
        {
            if (tile != null 
                && tile.X - 1 >= 0)
            {
                return gameBoard.Tiles[tile.X - 1, tile.Y];
            }
            return null;
        }


        protected string GetRandomLetterFromString(string text, Random random)
        {
            int randomIndex = random.Next(0, text.Length);
            return text[randomIndex].ToString();
        }

        public AIMove GetAIMove(GameBoard gameBoard)
        {
            var move = MiniMaxAlphaBeta(1, true, int.MinValue, int.MaxValue, gameBoard);
            //Adding some randomness to the selection if no potential scores can be found.
            //Otherwise, AI vs AI would just fill all up with one letter.
            if (Equals(move.Score, 0))
            {
                Random random = new Random();
                var x = random.Next(gameBoard.Size);
                var y = random.Next(gameBoard.Size);

                while (!string.IsNullOrEmpty(gameBoard.Tiles[x, y].Letter))
                {
                    x = random.Next(gameBoard.Size);
                    y = random.Next(gameBoard.Size);
                }
                move.X = x;
                move.Y = y;
                move.Letter = GetRandomLetterFromString("OS", random);
            }
            return move;
        }

        protected AIMove MiniMaxAlphaBeta(int depth, bool maximizingPlayer, int alpha, int beta, GameBoard gameBoard, int x = -1, int y = -1)
        {
            //base case
            if (CheckIfBoardIsFull(gameBoard) || depth == 0)
            {
                return new AIMove(score: CheckForScore(gameBoard.Tiles[x,y], gameBoard).Count, x:x, y:y);
            }            

            AIMove bestMove = new();
            bestMove.Score = maximizingPlayer ? int.MinValue : int.MaxValue;

            // iterate through possible moves
            for (int i = 0; i < gameBoard.Tiles.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.Tiles.GetLength(1); j++)
                {
                    if (string.IsNullOrEmpty(gameBoard.Tiles[i, j].Letter))
                    {
                        // check O options
                        gameBoard.Tiles[i, j].Letter = "O";

                        var move = MiniMaxAlphaBeta(depth - 1, !maximizingPlayer, alpha, beta, gameBoard, i, j);                        

                        if (maximizingPlayer)
                        {
                            if (move.Score > bestMove.Score)
                            {
                                bestMove = move;
                                bestMove.Letter = "O";
                            }

                            alpha = Math.Max(alpha, move.Score);
                        }
                        else
                        {
                            if (move.Score < bestMove.Score)
                            {
                                bestMove = move;
                                bestMove.Letter = "O";
                            }

                            beta = Math.Min(beta, move.Score);
                        }
                        // check S options
                        gameBoard.Tiles[i, j].Letter = "S";
                        move = MiniMaxAlphaBeta(depth - 1, !maximizingPlayer, alpha, beta, gameBoard, i, j);

                        if (maximizingPlayer)
                        {
                            if (move.Score > bestMove.Score)
                            {
                                bestMove = move;
                                bestMove.Letter = "S";
                            }

                            alpha = Math.Max(alpha, move.Score);
                        }
                        else
                        {
                            if (move.Score < bestMove.Score)
                            {
                                bestMove = move;
                                bestMove.Letter = "S";
                            }

                            beta = Math.Min(beta, move.Score);
                        }
                        // undo assignment
                        gameBoard.Tiles[i, j].Letter = string.Empty; 
                        if (beta <= alpha)
                            break; 
                    }
                }
            }

            return bestMove;
        }
    }
}