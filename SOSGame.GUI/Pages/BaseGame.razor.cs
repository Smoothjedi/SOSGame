using Blazor.Extensions.Canvas.WebGL;
using Blazor.Extensions;
using Microsoft.AspNetCore.Components;
using SOSGame.GUI.Data.Factories;
using SOSGame.GUI.Data.Objects;
using SOSGame.GUI.Logic;
using Blazor.Extensions.Canvas.Canvas2D;
using Microsoft.AspNetCore.Components.Web;
using System;

namespace SOSGame.GUI.Pages
{
    public abstract partial class BaseGame
    {
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
            await ModifyCanvas(eventArgs.OffsetX, eventArgs.OffsetY);
        }

        protected async Task ModifyCanvas(double x, double y)
        {
            var calculatedX = (int)Math.Truncate(x / 62);
            var calculatedY = (int)Math.Truncate(y / 62);

            if (GameOver 
                || calculatedX < 0 
                || calculatedY < 0
                || calculatedX >= GameBoard.Size
                || calculatedY >= GameBoard.Size)
            {
                return;
            }

            if (GameLogic.UpdateGameBoardAfterClick(calculatedX, calculatedY, GameBoard, FirstPlayer))
            {
                await CanvasLogic.DrawLettersOnCanvas(calculatedX, calculatedY, FirstPlayer, GameBoard, _canvasReference);
                var scores = GameLogic.CheckForScore(calculatedX, calculatedY, GameBoard);
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
                if (GameLogic.CheckForGameOver(firstPlayerScores, secondPlayerScores, GameBoard))
                {
                    GameOver = true;
                }
                else
                {
                    FirstPlayer = GameLogic.ChangeTurn(FirstPlayer);
                }
            }
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
