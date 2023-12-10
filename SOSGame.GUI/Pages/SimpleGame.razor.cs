using SOSGame.GUI.Data.Objects;
using System.Drawing;
using System.Text.RegularExpressions;

namespace SOSGame.GUI.Pages {
    public partial class SimpleGame : BaseGame {
        protected override async Task LogGameStartInformation() {
            GameLogger.ResetLog();
            await GameLogger.Log($"Beginning new Simple game with size " +
                $"{GameBoard.Size} at {DateTime.Now}");
        }

        protected override void OnInitialized() {
            base.OnInitialized();
            if (string.IsNullOrEmpty(size) || (int.TryParse(size, out var boardSize) 
                && (boardSize < 3 || boardSize > 10))) {
                GameBoard = GameBoardFactory.CreateDefaultGameBoard();
            } else {
                GameBoard = GameBoardFactory.CreateGameBoard(boardSize);
            }
            GameLogic = GameLogicFactory.GetGameLogic("simple");

            if (!string.IsNullOrEmpty(moves)) {
                var splitMoves = moves.Split(',');
                foreach (var moveText in splitMoves) {
                    if (Regex.IsMatch(moveText, $"^[0-{GameBoard.Size - 1}]{{2}}[SO]$")) {
                        var moveArray = moveText.ToCharArray();
                        var move = new Move();
                        if (int.TryParse(moveArray[0].ToString(), out var x) && 
                            int.TryParse(moveArray[1].ToString(), out var y)) {
                            move.X = x;
                            move.Y = y;
                            move.Letter = moveArray[2].ToString();
                            ReplayMoves.Enqueue(move);
                        } else {
                            ReplayMoves.Clear();
                            break;
                        }
                    } else {
                        ReplayMoves.Clear();
                        break;
                    }
                }
            }
        }
    }
}