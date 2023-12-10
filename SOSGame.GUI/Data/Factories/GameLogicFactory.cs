using SOSGame.GUI.Logic;

namespace SOSGame.GUI.Data.Factories
{
    public class GameLogicFactory : IGameLogicFactory
    {
        public IGameLogic GetGameLogic(string gameType)
        {
            if (Equals("general", gameType))
            {
                return new GeneralGameLogic();
            }
            else return new SimpleGameLogic();
        }
    }
}