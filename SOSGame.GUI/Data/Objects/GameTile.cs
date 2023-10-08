using System.ComponentModel.DataAnnotations;
using System.Drawing;
//using static SOSGame.GUI.Data.Objects.TileEnums;

namespace SOSGame.GUI.Data.Objects
{
    public class GameTile
    {
        public bool? FirstPlayerOwned { get; set; }

        public string? Letter { get; set; }
    }
}
