using System;
using System.Collections.Generic;
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
        List<Tile> Path { set; get; }
        int GetId();
        List<Piece> GetPieces();
        PlayerColor GetColor();
    }
}