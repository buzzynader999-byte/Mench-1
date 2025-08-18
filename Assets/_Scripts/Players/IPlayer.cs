using System;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Pieces;
using _Scripts.Tiles;

namespace _Scripts.Players
{
    public enum PlayerColor
    {
        Yellow = 0,
        Blue,
        Red,
        Green
    }

    public interface IPlayer
    {
        public bool HasPiecesInPlay()
        {
            return Pieces.Any(target => target.IsInPlay);
        }
        List<Tile> Path { set; get; }
        int Id { get; }
        List<Piece> Pieces { get; }
        PlayerColor Color { get; }
        void OnTurnStart();
        void OnTurnEnd();
    }
}