using SOSGame.GUI.Data.Objects;

namespace SOSGame.GUI.Logic
{
    public class SimpleGameLogic : BaseGameLogic, IGameLogic
    {
        public override bool CheckForGameOver(int firstPlayerScore, int SecondPlayerScore, GameBoard board)
        {
            if (firstPlayerScore > 0 || SecondPlayerScore > 0 || CheckIfBoardIsFull(board))
            {
                return true;
            }
            return false;
        }
    }
}
