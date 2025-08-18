using System.Collections.Generic;
using _Scripts.Players;

namespace _Scripts.Turn
{
    public interface ITurnManager
    {
        Player GetCurrentPlayer();
        void SwitchTurn();
        void GrantExtraTurn();
    }
}