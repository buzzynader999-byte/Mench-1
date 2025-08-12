using System.Collections.Generic;
using _Scripts.Players;
using UnityEngine;

namespace _Scripts.Turn
{
    public class TurnManager : Singleton<TurnManager>, ITurnManager
    {
        private IPlayer _currentPlayer;
        private List<IPlayer> _players;

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