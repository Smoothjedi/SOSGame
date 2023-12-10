using SOSGame.GUI.Data.Objects;

namespace SOSGame.GUI.Logic
{
    public interface IGameLogger
    {
        Task Log(string moveData);
        void ResetLog();
    }
}