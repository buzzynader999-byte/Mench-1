using _Scripts.Pieces;
using UnityEngine;

namespace _Scripts.Tiles
{
    public class Tile : MonoBehaviour, ITile
    {
        [SerializeField] private bool isSafe;
        [SerializeField] private bool isStart;
        [SerializeField] private bool isGoal;
        private IPiece _currentPiece;

        public bool IsOccupied()
        {
            throw new System.NotImplementedException();
        }

        public IPiece GetPiece()
        {
            throw new System.NotImplementedException();
        }

        public void SetPiece(IPiece piece)
        {
            throw new System.NotImplementedException();
        }

        public bool IsSafeZone()
        {
            throw new System.NotImplementedException();
        }

        public bool IsStartTile()
        {
            throw new System.NotImplementedException();
        }

        public bool IsGoalTile()
        {
            throw new System.NotImplementedException();
        }
    }
}