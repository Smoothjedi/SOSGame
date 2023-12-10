namespace SOSGame.GUI.Data.Objects
{
    public class AIMove : Move {
        public AIMove(string letter = "", int score = 0, int x = -1, int y = -1) :
            base(letter, x, y) {
            Score = score;            
        }
        public int Score { get; set; } = 0;
    }
}
