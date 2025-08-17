using _Scripts.Tiles;
using UnityEngine;

namespace _Scripts.Pieces
{
    public class Piece : MonoBehaviour, IPiece
    {
        private int _playerId;
        private ITile _currentTile;
        private bool _inPlay, _inGoal;
        public int CurrentTileIndex { private set; get; }
        public bool IsInPlay { set; get; }

        public int GetPlayerId()
        {
            return _playerId;
        }

        public void MoveToTile(ITile tile, int tileIndex)
        {
            CurrentTileIndex = tileIndex;
            transform.position = tile.GetPosition();
        }

        public bool IsInGoal()
        {
            throw new System.NotImplementedException();
        }
    }
}