using SOSGame.GUI.Data.Objects;
using SOSGame.GUI.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSGame.GUI.Tests.Logic
{
    public class BaseGameLogicTestClass : BaseGameLogic
    {
        public override bool CheckForGameOver(int firstPlayerScore, int SecondPlayerScore, GameBoard board)
        {
            return false;
        }
    }
}
