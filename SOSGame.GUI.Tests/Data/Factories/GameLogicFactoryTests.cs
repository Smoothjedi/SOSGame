using SOSGame.GUI.Data.Factories;
using SOSGame.GUI.Logic;

namespace SOSGame.GUI.Tests.Data.Factories
{
    public class GameLogicFactoryTests {
        [Fact]
        public void GetGeneralGameLogic() {
            IGameLogicFactory gameLogicFactory = new GameLogicFactory();
            var factory = gameLogicFactory.GetGameLogic("general");
            Assert.True(factory is GeneralGameLogic);
        }

        [Fact]
        public void GetSimpleGameLogic() {
            IGameLogicFactory gameLogicFactory = new GameLogicFactory();
            var factory = gameLogicFactory.GetGameLogic("simple");
            Assert.True(factory is SimpleGameLogic);
        }
    }
}