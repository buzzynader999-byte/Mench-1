using UnityEngine;

namespace _Scripts.Dices
{
    public class Dice : IDice
    {
        private int _lastRoll;
        private bool _extraRoll;

        public int Roll()
        {
            _lastRoll = Random.Range(1, 7);
            return _lastRoll;
        }

        public bool CanRollAgain()
        {
            return _lastRoll == 6;
        }
    }
}