using _Scripts.Boards;
using _Scripts.Players;

namespace _Scripts.GameRules
{
    public abstract class BaseGameRule : IGameRule
    {
        public virtual bool IsGameOver(IBoard board)
        {
            throw new System.NotImplementedException();
        }

        public virtual IPlayer GetWinner(IBoard board)
        {
            throw new System.NotImplementedException();
        }
    }
}