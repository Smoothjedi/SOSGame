using Blazor.Extensions;
using SOSGame.GUI.Data.Objects;

namespace SOSGame.GUI.Logic {
    public class CanvasLogic : ICanvasLogic {
        private int defaultLineWith = 2;
        private int scoreLineWith = 5;

        public async Task DrawLettersOnCanvas(Move move, 
            bool firstPlayer, 
            GameBoard gameBoard, 
            BECanvasComponent canvasReference) {
            var context = await canvasReference.CreateCanvas2DAsync();

            if (firstPlayer) {
                await context.SetFillStyleAsync("blue");
            } else {
                await context.SetFillStyleAsync("red");
            }
            await context.FillTextAsync(gameBoard.Tiles[move.X, move.Y].Letter,
                move.X * 62 + 15, move.Y * 62 + 45);
        }

        public async Task DrawScoreLines(List<GameTile> score, string color,
            BECanvasComponent canvasReference) {
            var context = await canvasReference.CreateCanvas2DAsync();

            await context.SetLineWidthAsync(scoreLineWith);
            await context.SetStrokeStyleAsync(color);

            var firstX = score.First().X;
            var firstY = score.First().Y;
            var lastX = score.Last().X;
            var lastY = score.Last().Y;
            await context.BeginPathAsync();
            await context.MoveToAsync(firstX * 62 + 31, firstY * 62 + 31);
            await context.LineToAsync(lastX * 62 + 31, lastY * 62 + 31);
            await context.StrokeAsync();

            await context.SetLineWidthAsync(defaultLineWith);
        }

        public async Task DrawBoardAsync(GameBoard gameBoard, BECanvasComponent canvasReference) {
            var context = await canvasReference.CreateCanvas2DAsync();
            await context.SetFontAsync("40px Arial");
            await context.SetLineWidthAsync(defaultLineWith);
            await context.SetStrokeStyleAsync("black");
            await context.BeginPathAsync();
            await context.MoveToAsync(0, 0);
            await context.LineToAsync(0, gameBoard.Dimensions);
            await context.MoveToAsync(0, gameBoard.Dimensions);
            await context.LineToAsync(gameBoard.Dimensions, gameBoard.Dimensions);
            await context.MoveToAsync(gameBoard.Dimensions, gameBoard.Dimensions);
            await context.LineToAsync(gameBoard.Dimensions, 0);
            await context.MoveToAsync(0, 0);
            await context.LineToAsync(gameBoard.Dimensions, 0);

            for (int i = 1; i < gameBoard.Size; i++) {
                await context.SetLineWidthAsync(defaultLineWith);

                await context.MoveToAsync(i * 62, 0);
                await context.LineToAsync(i * 62, gameBoard.Dimensions);

                await context.MoveToAsync(0, i * 62);
                await context.LineToAsync(gameBoard.Dimensions, i * 62);
            }
            await context.StrokeAsync();
        }
    }
}