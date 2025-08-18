using _Scripts.Pieces;
using UnityEngine;

namespace _Scripts.Tiles
{
    public interface ITile
    {
        //اشغال شده؟
        bool IsOccupied();

        // مهرشو بگیر
        IPiece GetPiece();

        // مهره داخلش بزار
        void SetPiece(IPiece piece);

        // نقطه امنه؟
        bool IsSafeZone();

        // نقطه شروعه؟
        bool IsStartTile();

        // نقطه آخر یا هدفه؟
        bool IsGoalTile { get; }
        public Vector3 GetPosition();
    }
}