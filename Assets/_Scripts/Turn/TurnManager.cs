using System.Collections.Generic;
using _Scripts.Players;

namespace _Scripts.Turn
{
    public class TurnManager : ITurnManager
    {
        private IPlayer currentPlayer;
        private List<IPlayer> players;

        public IPlayer GetCurrentPlayer()
        {
            throw new System.NotImplementedException();
        }

        public void SwitchTurn()
        {
            throw new System.NotImplementedException();
        }

        public void GrantExtraTurn()
        {
            throw new System.NotImplementedException();
        }
    }
}