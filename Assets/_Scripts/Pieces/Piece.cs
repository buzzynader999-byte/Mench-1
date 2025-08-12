using _Scripts.Tiles;
using UnityEngine;

namespace _Scripts.Pieces
{
    public class Piece : MonoBehaviour, IPiece
    {
        private int _playerId;
        private ITile _currentTile;
        private bool _inPlay, _inGoal;

        public int GetPlayerId()
        {
            throw new System.NotImplementedException();
        }

        public ITile GetCurrentTile()
        {
            throw new System.NotImplementedException();
        }

        public void MoveToTile(ITile tile)
        {
            throw new System.NotImplementedException();
        }

        public bool IsInPlay()
        {
            throw new System.NotImplementedException();
        }

        public bool IsInGoal()
        {
            throw new System.NotImplementedException();
        }
    }
}