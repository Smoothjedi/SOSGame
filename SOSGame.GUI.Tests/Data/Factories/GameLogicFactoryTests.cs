using SOSGame.GUI.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSGame.GUI.Tests.Data.Factories
{
    public class GameLogicFactoryTests
    {
        [Fact]
        public void GetGeneralGameLogic()
        {
            IGameLogicFactory gameLogicFactory = new GameLogicFactory();
            var factory = gameLogicFactory.GetGameLogic("general");
            Assert.True(factory is GeneralGameLogic);
        }

        [Fact]
        public void GetSimpleGameLogic()
        {
            IGameLogicFactory gameLogicFactory = new GameLogicFactory();
            var factory = gameLogicFactory.GetGameLogic("simple");
            Assert.True(factory is SimpleGameLogic);
        }
    }
}
