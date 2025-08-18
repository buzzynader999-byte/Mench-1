using System.Collections.Generic;
using _Scripts.Boards;
using _Scripts.Players;
using UnityEngine;

namespace _Scripts.Pieces.Move
{
    public class MoveHandler : IMoveHandler
    {
        public bool ValidateMove(IPlayer player, IPiece piece, int diceValue)
        {
            var pieceTileIndex = piece.CurrentTileIndex;
            return pieceTileIndex + diceValue <= player.Path.Count;
        }

        public List<Piece> ValidateMoveForAll(IPlayer player, List<int> diceRolls)
        {
            List<Piece> movablePlayers = new List<Piece>();
            if (player.HasPiecesInPlay())
            {
                foreach (var piece in player.Pieces)
                {
                    foreach (var diceRoll in diceRolls)
                    {
                        if (piece.IsInPlay)
                        {
                            var pieceTileIndex = piece.CurrentTileIndex;
                            if (pieceTileIndex + diceRoll <= player.Path.Count)
                            {
                                if (!movablePlayers.Contains(piece))
                                    movablePlayers.Add(piece);
                            }
                        }
                    }
                }
            }

            return movablePlayers;
        }

        public void ApplyMove(IPlayer player, IPiece piece, int diceValue)
        {
            var targetPos = piece.CurrentTileIndex + diceValue;
            if (player.Path.Count > targetPos)
                piece.MoveToTile(player.Path[targetPos], targetPos);
        }

        public bool CanPieceEnterPlay(IPlayer player, int diceValue)
        {
            throw new System.NotImplementedException();
        }
    }
}