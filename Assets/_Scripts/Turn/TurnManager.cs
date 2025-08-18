using System.Collections.Generic;
using _Scripts.Players;
using UnityEngine;

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
            ChangePlayer(0);
        }

        public Player GetCurrentPlayer()
        {
            return _currentPlayer;
        }

        public void SwitchTurn()
        {
            _currentPlayerIndex++;
            ChangePlayer(_currentPlayerIndex % _players.Count);
            DiceRolls.Clear();
        }

        public void GrantExtraTurn()
        {
            //...
        }

        public List<int> DiceRolls { get; } = new List<int>();

        void ChangePlayer(int index)
        {
            _currentPlayer = _players[index];
            TestPlayerTurnDisplayer.Instance.ChangePlayer((int)_currentPlayer.Color);
            //Debug.Log(_currentPlayer.Color + " Turn");
            //Debug.Log(_currentPlayer.Color + "------------------------");
        }
    }
}