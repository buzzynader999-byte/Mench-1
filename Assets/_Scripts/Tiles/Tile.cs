using _Scripts.Pieces;
using UnityEngine;

namespace _Scripts.Tiles
{
    public class Tile : MonoBehaviour, ITile
    {
        private IPiece _currentPiece;
        private bool _isSafe, _isStart, _isGoal;

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