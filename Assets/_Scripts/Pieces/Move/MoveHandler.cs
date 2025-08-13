using _Scripts.Boards;
using _Scripts.Players;
using UnityEngine;

namespace _Scripts.Pieces.Move
{
    public class MoveHandler:IMoveHandler
    {
        public bool ValidateMove(IPlayer player, IPiece piece, int diceValue, IBoard board)
        {
            Debug.Log("Fake validate");
            return true;
        }

        public void ApplyMove(IPlayer player, IPiece piece, int diceValue, IBoard board)
        {
            var targetPos = piece.CurrentTileIndex + diceValue;
            var path = board.GetPath(player.GetColor());
            piece.MoveToTile(path[targetPos],targetPos);
        }

        public bool CanPieceEnterPlay(IPlayer player, int diceValue, IBoard board)
        {
            throw new System.NotImplementedException();
        }
    }
}