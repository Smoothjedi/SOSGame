using SOSGame.GUI.Data.Objects;

namespace SOSGame.GUI.Logic {
    public interface IGameLogic {
        bool ChangeTurn(bool firstPlayer);
        List<List<GameTile>> CheckForScore(GameTile tile, GameBoard board);
        bool CheckForGameOver(int firstPlayerScore, int SecondPlayerScore, GameBoard board);
        AIMove GetAIMove(GameBoard gameBoard);
    }
}