using SOSGame.GUI.Logic;

namespace SOSGame.GUI.Data.Factories
{
    public interface IGameLogicFactory
    {
        IGameLogic GetGameLogic(string gameType);
    }
}