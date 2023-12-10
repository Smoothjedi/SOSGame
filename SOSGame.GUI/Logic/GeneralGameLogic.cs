using SOSGame.GUI.Data.Objects;

namespace SOSGame.GUI.Logic {
    public class GeneralGameLogic : BaseGameLogic, IGameLogic {
        public override bool CheckForGameOver(int firstPlayerScore, int SecondPlayerScore, GameBoard board) {
            return CheckIfBoardIsFull(board);
        }
    }
}
