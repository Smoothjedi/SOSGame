namespace SOSGame.GUI.Data.Objects
{
    public class GameBoard : IDisposable {
        public GameTile[,] Tiles { get; set; }
        public string FirstPlayerLetter { get; set; } = "S";
        public string SecondPlayerLetter { get; set; } = "S";
        public int Size { get; set; } = 3;
        public int Dimensions { get; set; }

        public void Dispose() {
            Tiles = null;
        }
    }
}
