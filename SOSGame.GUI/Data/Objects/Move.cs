using System.Text;

namespace SOSGame.GUI.Data.Objects {
    public class Move {
        public Move(string letter = "", int x = -1, int y = -1) {
            X = x;
            Y = y;
            Letter = letter;
        }

        public int X { get; set; } = -1;
        public int Y { get; set; } = -1;
        public string Letter { get; set; } = string.Empty;

        public override string ToString() {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(X).Append(Y).Append(Letter);
            return stringBuilder.ToString();
        }
    }
}