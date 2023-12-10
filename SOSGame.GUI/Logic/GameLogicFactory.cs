namespace SOSGame.GUI.Logic {
    public class GameLogicFactory : IGameLogicFactory {
        public IGameLogic GetGameLogic(string gameType)
        {
            if (Equals("general", gameType)) {
                return new GeneralGameLogic();
            } else return new SimpleGameLogic();
        }
    }
}
