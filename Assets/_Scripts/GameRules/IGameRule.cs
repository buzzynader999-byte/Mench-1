using _Scripts.Boards;
using _Scripts.Players;

namespace _Scripts.GameRules
{
    public interface IGameRule
    {
        bool IsGameOver(IBoard board);
        IPlayer GetWinner(IBoard board);
    }
}