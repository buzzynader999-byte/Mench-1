using UnityEngine;

namespace _Scripts.Dices
{
    public class Dice : IDice
    {
        private int _lastRoll;
        private bool _extraRoll;

        public int Roll()
        {
            Debug.Log("Fake roll");
            _lastRoll = 3;
            return _lastRoll;
        }

        public bool CanRollAgain()
        {
            return _lastRoll == 6;
        }
    }
}