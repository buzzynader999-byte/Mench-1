using System.Collections.Generic;
using _Scripts.Pieces;
using UnityEngine;

namespace _Scripts.Players
{
    public interface IPlayer
    {
        int GetId();
        List<IPiece> GetPieces();
        Color GetColor();
    }
}