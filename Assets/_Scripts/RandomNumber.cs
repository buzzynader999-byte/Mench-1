using UnityEngine;

namespace _Scripts
{
    public static class RandomNumber
    {
        public static int Pick()
        {
            return Random.Range(0, 7);
        }
    }
}