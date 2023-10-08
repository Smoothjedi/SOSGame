namespace SOSGame.Logic
{
    public class BaseGameLogic : IBaseGameLogic
    {
        public bool ChangeTurn(bool firstPlayer)
        {
            if (firstPlayer)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}