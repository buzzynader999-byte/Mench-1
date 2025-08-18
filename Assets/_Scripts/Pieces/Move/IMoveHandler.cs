
using _Scripts.Boards;
using _Scripts.Players;

namespace _Scripts.Pieces.Move
{
    public interface IMoveHandler
    {
        bool ValidateMove(IPlayer player, IPiece piece, int diceValue);
        void ApplyMove(IPlayer player, IPiece piece, int diceValue);
        bool CanPieceEnterPlay(IPlayer player, int diceValue);
    }
}