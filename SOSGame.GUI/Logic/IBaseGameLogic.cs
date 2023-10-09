using SOSGame.GUI.Data.Objects;

namespace SOSGame.GUI.Logic
{
    public interface IBaseGameLogic
    {
        bool ChangeTurn(bool firstPlayer);
        bool UpdateGameBoardAfterClick(int x, int y, GameBoard board, bool firstPlayer);
    }
}