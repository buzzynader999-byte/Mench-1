using _Scripts.Tiles;

namespace _Scripts.Pieces
{
    public interface IPiece
    {
        int GetPlayerId();
        ITile GetCurrentTile();
        void MoveToTile(ITile tile);
        bool IsInPlay();
        bool IsInGoal();
    }
}