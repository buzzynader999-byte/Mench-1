using System.Collections.Generic;
using _Scripts.Players;

namespace _Scripts.Turn
{
    public class TurnManager : ITurnManager
    {
        private Player _currentPlayer;
        private List<Player> _players;
        private int _currentPlayerIndex = 0;

        public TurnManager(List<Player> players)
        {
            _players = players;
            _currentPlayer = _players[0];
        }

        public Player GetCurrentPlayer()
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
            //...
        }
    }
}