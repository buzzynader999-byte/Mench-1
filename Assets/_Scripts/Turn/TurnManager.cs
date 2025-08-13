using System.Collections.Generic;
using _Scripts.Players;
using UnityEngine;

namespace _Scripts.Turn
{
    public class TurnManager : ITurnManager
    {
        private IPlayer _currentPlayer;
        private List<IPlayer> _players;
        private int _currentPlayerIndex = 0;

        public TurnManager(List<IPlayer> players)
        {
            _players = players;
            _currentPlayer = _players[0];
        }

        public IPlayer GetCurrentPlayer()
        {
            return _currentPlayer;
        }

        public void SwitchTurn()
        {
            _currentPlayerIndex++;
            _currentPlayer = _players[_currentPlayerIndex % _players.Count];
        }

        public void GrantExtraTurn()
        {
            throw new System.NotImplementedException();
        }
    }
}