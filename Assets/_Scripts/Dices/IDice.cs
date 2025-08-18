using System.Collections.Generic;

namespace _Scripts.Dices
{
    public interface IDice
    {
        public int LastRoll { get;}
        public int NumberOfSixes { get; }
        public List<int> DiceRolls { get; }
        int Roll();
        int FakeRoll(int target);
        bool CanRollAgain();
        public void Reset();
    }
}