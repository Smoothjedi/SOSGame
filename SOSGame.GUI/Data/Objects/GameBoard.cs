namespace SOSGame.GUI.Data.Objects
{
    public class GameBoard
    {
        public GameTile[,] Tiles { get; set; }
        public string FirstPlayerLetter { get; set; } = "S";
        public string SecondPlayerLetter { get; set; } = "S";
        public int Size { get; set; } = 3;
    }
}
