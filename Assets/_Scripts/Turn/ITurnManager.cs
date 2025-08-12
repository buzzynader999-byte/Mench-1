using _Scripts.Players;

namespace _Scripts.Turn
{
    public interface ITurnManager
    {
        IPlayer GetCurrentPlayer();
        void SwitchTurn();
        void GrantExtraTurn();
    }
}