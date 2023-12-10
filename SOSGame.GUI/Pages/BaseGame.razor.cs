using Blazor.Extensions;
using Microsoft.AspNetCore.Components;
using SOSGame.GUI.Data.Factories;
using SOSGame.GUI.Data.Objects;
using SOSGame.GUI.Logic;
using Microsoft.AspNetCore.Components.Web;
using System.Text;

namespace SOSGame.GUI.Pages
{
    public abstract partial class BaseGame
    {
        protected bool firstPlayerHuman = true;
        protected bool secondPlayerHuman = true;
        protected int firstPlayerScores = 0;
        protected int secondPlayerScores = 0;
        public ElementReference divCanvas;
        protected BECanvasComponent _canvasReference;
        protected bool FirstPlayer = true;
        protected List<string> LetterOptions = new List<string> { "S", "O" };
        protected bool GameOver = false;
        protected List<KeyValuePair<int, string>> GameHistory = new List<KeyValuePair<int, string>>();
        protected Queue<Move> ReplayMoves = new Queue<Move>();
        protected List<Move> GameMoves = new List<Move>();
        protected bool ReplayGame = true;

        protected IGameLogic GameLogic { get; set; } = null!;

        [Inject]
        protected IGameBoardFactory GameBoardFactory { get; set; } = null!;

        [Inject]
        protected IGameLogicFactory GameLogicFactory { get; set; } = null!;

        [Inject]
        protected ICanvasLogic CanvasLogic { get; set; } = null!;

        [Inject]
        protected IGameLogger GameLogger { get; set; }

        protected GameBoard GameBoard { get; set; }

        protected async Task CanvasClicked(MouseEventArgs eventArgs)
        {
            var move = new Move();
            move.X = (int)Math.Truncate(eventArgs.OffsetX / 62);
            move.Y = (int)Math.Truncate(eventArgs.OffsetY / 62);
            move.Letter = FirstPlayer ? GameBoard.FirstPlayerLetter : GameBoard.SecondPlayerLetter;
            if (GameOver
                || !firstPlayerHuman && !secondPlayerHuman
                || (FirstPlayer && !firstPlayerHuman)
                || (!FirstPlayer && !secondPlayerHuman)
                || move.X < 0
                || move.Y < 0
                || move.X >= GameBoard.Size
                || move.Y >= GameBoard.Size
                || !string.IsNullOrEmpty(GameBoard.Tiles[move.X, move.Y].Letter)
                || ReplayMoves.Any())
            {
                return;
            }
            await PerformTurn(move);
            if (FirstPlayer && !firstPlayerHuman && secondPlayerHuman && !GameOver
                || (!FirstPlayer && firstPlayerHuman && !secondPlayerHuman && !GameOver))
            {
                await PerformAIPlayerTurn();
            }
            return;
        }

        protected async Task PerformTurn(Move move)
        { 
            GameBoard.Tiles[move.X, move.Y].Letter = move.Letter;
            await ModifyCanvas(move);
            await FinishTurn(move);
        }

        private async Task PerformAIPlayerTurn()
        {
            var move = GameLogic.GetAIMove(GameBoard);
            if (FirstPlayer)
            {
                GameBoard.FirstPlayerLetter = move.Letter;
            }
            else
            {
                GameBoard.SecondPlayerLetter = move.Letter;
            }
            await PerformTurn(move);
            await Task.Delay(10);

        }

        protected async Task ModifyCanvas(Move move)
        {
            await CanvasLogic.DrawLettersOnCanvas(move, FirstPlayer, GameBoard, _canvasReference);
            var scores = GameLogic.CheckForScore(GameBoard.Tiles[move.X, move.Y], GameBoard);
            if (scores.Any())
            {
                foreach (var score in scores)
                {
                    if (FirstPlayer)
                    {
                        firstPlayerScores++;
                        await CanvasLogic.DrawScoreLines(score, "blue", _canvasReference);
                        await GameLogger.Log($"First Player scored! Line drawn from ({score.First().X}, {score.First().Y}) to ({score.Last().X}, {score.Last().Y})");
                    }
                    else
                    {
                        secondPlayerScores++;
                        await CanvasLogic.DrawScoreLines(score, "red", _canvasReference);
                        await GameLogger.Log($"Second Player scored! Line drawn from ({score.First().X}, {score.First().Y}) to ({score.Last().X}, {score.Last().Y})");
                    }
                }
            }
        }

        protected async Task ChangeToComputerPlayer()
        {
            await Task.Delay(50);

            while (!GameOver)
            {
                if (FirstPlayer && firstPlayerHuman || (!FirstPlayer && secondPlayerHuman))
                {
                    return;
                }

                if (!firstPlayerHuman && FirstPlayer
                    || !secondPlayerHuman && !FirstPlayer)
                {
                    await PerformAIPlayerTurn();
                    await Task.Delay(100);
                }
            }
        }

        private async Task FinishTurn(Move move)
        {
            GameMoves.Add(move);
            await GameLogger.Log($"{(FirstPlayer ? "FirstPlayer" : "SecondPlayer")} places {move.Letter} at ({move.X}, {move.Y})");
            if (GameLogic.CheckForGameOver(firstPlayerScores, secondPlayerScores, GameBoard))
            {
                GameOver = true;
                await GameLogger.Log("The game has ended!");
                await GameLogger.Log($"First Player scored {firstPlayerScores}");
                await GameLogger.Log($"Second Player scored {secondPlayerScores}");

                if (firstPlayerScores > secondPlayerScores)
                {
                    await GameLogger.Log($"First Player wins!");
                }
                if (firstPlayerScores < secondPlayerScores)
                {
                    await GameLogger.Log($"Second Player wins!");
                }
                if (Equals(firstPlayerScores, secondPlayerScores))
                {
                    await GameLogger.Log($"The game is a draw!");
                }
                await GameLogger.Log(string.Empty);
            }
            else
            {
                FirstPlayer = GameLogic.ChangeTurn(FirstPlayer);
            }

            return;
        }

        protected string SerializeGameMoves()
        {
            var stringBuilder = new StringBuilder();
            foreach (var move in GameMoves) 
            {
                stringBuilder.Append(move.ToString());
                if (move != GameMoves.Last())
                {
                    stringBuilder.Append(',');
                }
            }
            return stringBuilder.ToString();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();            
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await CanvasLogic.DrawBoardAsync(GameBoard, _canvasReference);
                await LogGameStartInformation();
                if (ReplayMoves.Any())
                {
                    while (ReplayMoves.TryDequeue(out var replayMoves))
                    {
                        await PerformTurn(replayMoves);
                        await Task.Delay(100);
                    }
                    _ = InvokeAsync(StateHasChanged);
                }
            }
        }

        protected abstract void StartNewGame(string size);

        protected abstract void StartNewGame(string size, string moves);

        protected abstract Task LogGameStartInformation();


    }
}
