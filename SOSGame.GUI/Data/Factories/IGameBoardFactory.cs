using SOSGame.GUI.Data.Objects;

namespace SOSGame.GUI.Data.Factories
{
    public interface IGameBoardFactory
    {
        public GameBoard CreateDefaultGameBoard();
        public GameBoard CreateGameBoard(int size);
    }
}