using SOSGame.GUI.Data.Objects;

namespace SOSGame.GUI.Logic
{
    public interface IGameLogic
    {
        bool ChangeTurn(bool firstPlayer);
        bool UpdateGameBoardAfterClick(int x, int y, GameBoard board, bool firstPlayer);
        List<List<GameTile>> CheckForScore(int x, int y, GameBoard board);
        bool CheckForGameOver(int firstPlayerScore, int SecondPlayerScore, GameBoard board);
    }
}