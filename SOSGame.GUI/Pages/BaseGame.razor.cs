using Blazor.Extensions.Canvas.WebGL;
using Blazor.Extensions;
using Microsoft.AspNetCore.Components;
using SOSGame.GUI.Data.Factories;
using SOSGame.GUI.Data.Objects;
using SOSGame.GUI.Logic;
using Blazor.Extensions.Canvas.Canvas2D;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.ComponentModel;

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
        protected IGameLogic GameLogic { get; set; } = null!;

        [Inject]
        protected IGameBoardFactory GameBoardFactory { get; set; } = null!;

        [Inject]
        protected IGameLogicFactory GameLogicFactory { get; set; } = null!;

        [Inject]
        protected ICanvasLogic CanvasLogic { get; set; } = null!;

        protected GameBoard GameBoard { get; set; }

        protected async Task CanvasClicked(MouseEventArgs eventArgs)
        {
            var x = (int)Math.Truncate(eventArgs.OffsetX / 62);
            var y = (int)Math.Truncate(eventArgs.OffsetY / 62);
            if (GameOver 
                || !firstPlayerHuman && !secondPlayerHuman
                || (FirstPlayer && !firstPlayerHuman)
                || (!FirstPlayer && !secondPlayerHuman)
                || x < 0
                || y < 0
                || x >= GameBoard.Size
                || y >= GameBoard.Size
                || !string.IsNullOrEmpty(GameBoard.Tiles[x,y].Letter))
            {
                return;
            }
            await ModifyCanvas(x, y);
            FinishTurn();
            if (FirstPlayer && !firstPlayerHuman && secondPlayerHuman && !GameOver
                || (!FirstPlayer && firstPlayerHuman && !secondPlayerHuman && !GameOver))
            {
                await PerformAIPlayerTurn();
                return;
            }
        }

        protected async Task ModifyCanvas(int x, int y)
        {
            if (GameLogic.UpdateGameBoardAfterClick(x, y, GameBoard, FirstPlayer))
            {
                await CanvasLogic.DrawLettersOnCanvas(x, y, FirstPlayer, GameBoard, _canvasReference);
                var scores = GameLogic.CheckForScore(x, y, GameBoard);
                if (scores.Any())
                {
                    foreach (var score in scores)
                    {
                        if (FirstPlayer)
                        {
                            firstPlayerScores++;
                            await CanvasLogic.DrawScoreLines(score, "blue", _canvasReference);
                        }
                        else
                        {
                            secondPlayerScores++;
                            await CanvasLogic.DrawScoreLines(score, "red", _canvasReference);
                        }
                    }
                }
            }
        }

        protected async Task ChangeToComputerPlayer()
        {
            if (GameOver)
            {
                return;
            }
            await Task.Delay(10);
            if (FirstPlayer && firstPlayerHuman || (!FirstPlayer && secondPlayerHuman))
            {
                return;
            }
            if (FirstPlayer && !firstPlayerHuman && secondPlayerHuman && !GameOver
                || (!FirstPlayer && firstPlayerHuman && !secondPlayerHuman && !GameOver))
            {
                await PerformAIPlayerTurn();
            }
            if (!firstPlayerHuman && !secondPlayerHuman && !GameOver)
            {
                while (!firstPlayerHuman && !secondPlayerHuman && !GameOver)
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
                    await ModifyCanvas(move.X, move.Y);
                    FinishTurn();
                    await Task.Delay(10);
                    Console.WriteLine($"Placed {move.Letter} at {move.X}, {move.Y} for Player {(FirstPlayer ? 1 : 2)}");
                }
                return;
            }
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
            await ModifyCanvas(move.X, move.Y);
            FinishTurn();
        }

        private void FinishTurn()
        {
            if (GameLogic.CheckForGameOver(firstPlayerScores, secondPlayerScores, GameBoard))
            {
                GameOver = true;
            }
            else
            {
                FirstPlayer = GameLogic.ChangeTurn(FirstPlayer);
            }
            return;
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
            }
        }

        protected abstract void StartNewGame(string size);

    }
}
