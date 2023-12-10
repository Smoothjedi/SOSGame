namespace SOSGame.GUI.Logic {
    public interface IGameLogicFactory {
        IGameLogic GetGameLogic(string gameType);
    }
}