using SOSGame.GUI.Logic;

namespace SOSGame.GUI.Tests.Logic
{
    public class BaseGameLogicTests
    {
        [Fact]
        public void ChangeTurnTrueToFalseTest()
        {
            var baseGameLogic = new BaseGameLogic();
            Assert.False(baseGameLogic.ChangeTurn(true));
        }
        [Fact]
        public void ChangeTurnFalseToTrueTest()
        {
            var baseGameLogic = new BaseGameLogic();
            Assert.True(baseGameLogic.ChangeTurn(false));
        }
    }
}