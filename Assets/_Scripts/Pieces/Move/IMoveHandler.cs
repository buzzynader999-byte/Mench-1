
using _Scripts.Boards;
using _Scripts.Players;

namespace _Scripts.Pieces.Move
{
    public interface IMoveHandler
    {
        bool ValidateMove(IPlayer player, IPiece piece, int diceValue, IBoard board);
        void ApplyMove(IPlayer player, IPiece piece, int diceValue, IBoard board);
        bool CanPieceEnterPlay(IPlayer player, int diceValue, IBoard board);
    }
}