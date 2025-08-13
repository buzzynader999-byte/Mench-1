using System;
using System.Collections.Generic;
using _Scripts.Pieces;
using UnityEngine;

namespace _Scripts.Players
{
    public enum PlayerColor
    {
        Blue,
        Red,
        Yellow,
        Green
    }

    public interface IPlayer
    {
        int GetId();
        List<Piece> GetPieces();
        PlayerColor GetColor();
    }
}