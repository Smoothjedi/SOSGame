using Blazor.Extensions;
using SOSGame.GUI.Data.Objects;

namespace SOSGame.GUI.Logic
{
    public interface ICanvasLogic
    {
        Task DrawBoardAsync(GameBoard gameBoard, BECanvasComponent canvasReference);
        Task DrawLettersOnCanvas(int calculatedX, int calculatedY, 
            bool firstPlayer, GameBoard gameBoard, BECanvasComponent canvasReference);
        Task DrawScoreLines(List<GameTile> score, string color, BECanvasComponent canvasReference);
    }
}