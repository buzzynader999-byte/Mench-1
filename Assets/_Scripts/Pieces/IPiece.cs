using _Scripts.Tiles;

namespace _Scripts.Pieces
{
    public interface IPiece
    {
        bool IsInPlay { set;get; }
        public int CurrentTileIndex { get; }
        int GetPlayerId();
        void MoveToTile(ITile tile,int tileIndex);
        bool IsInGoal();
    }
}