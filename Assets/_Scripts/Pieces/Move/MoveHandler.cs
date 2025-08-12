using _Scripts.Boards;
using _Scripts.Players;

namespace _Scripts.Pieces.Move
{
    public class MoveHandler:IMoveHandler
    {
        public bool ValidateMove(IPlayer player, IPiece piece, int diceValue, IBoard board)
        {
            throw new System.NotImplementedException();
        }

        public void ApplyMove(IPlayer player, IPiece piece, int diceValue, IBoard board)
        {
            throw new System.NotImplementedException();
        }

        public bool CanPieceEnterPlay(IPlayer player, int diceValue, IBoard board)
        {
            throw new System.NotImplementedException();
        }
    }
}