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
                return new AIMove(score: CheckForScore(x, y, gameBoard).Count, x:x, y:y);
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