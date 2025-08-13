using _Scripts.Tiles;

namespace _Scripts.Pieces
{
    public interface IPiece
    {
        public int CurrentTileIndex { get; }
        int GetPlayerId();
        ITile GetCurrentTile();
        void MoveToTile(ITile tile,int tileIndex);
        bool IsInPlay();
        bool IsInGoal();
    }
}