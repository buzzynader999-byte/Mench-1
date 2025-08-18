using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Dices
{
    public class Dice : IDice
    {
        public int LastRoll { get; private set; }
        public int NumberOfSixes { private set; get; } = 0;
        public List<int> DiceRolls { get; } = new List<int>();

        public int Roll()
        {
            LastRoll = Random.Range(1, 7);
            DiceRolls.Add(LastRoll);
            if (LastRoll == 6)
            {
                NumberOfSixes++;
            }

            return LastRoll;
        }

        public int FakeRoll(int target)
        {
            LastRoll = target == 0 ? Random.Range(1, 7) : target;
            DiceRolls.Add(LastRoll);
            if (LastRoll == 6)
            {
                NumberOfSixes++;
            }

            return LastRoll;
        }

        public bool CanRollAgain()
        {
            return LastRoll == 6;
        }

        public void Reset()
        {
            NumberOfSixes = 0;
            LastRoll = 0;
        }
    }
}