namespace SOSGame.GUI.Data.Objects
{
    public class AIMove
    {
        public AIMove(string letter = "", int score = 0, int x = -1, int y = -1)
        {
            X = x;
            Y = y;
            Letter = letter;
            Score = score;
        }

        public int X { get; set; } = -1;
        public int Y { get; set; } = -1;
        public string Letter { get; set; } = string.Empty;
        public int Score { get; set; } = 0;
    }
}
