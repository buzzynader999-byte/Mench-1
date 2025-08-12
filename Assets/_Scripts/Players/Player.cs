using System.Collections.Generic;
using _Scripts.Pieces;
using UnityEngine;

namespace _Scripts.Players
{
    public abstract class Player : IPlayer
    {
        private int id;
        private List<IPiece> pieces;
        private Color color;

        public int GetId()
        {
            throw new System.NotImplementedException();
        }

        public List<IPiece> GetPieces()
        {
            throw new System.NotImplementedException();
        }

        public Color GetColor()
        {
            throw new System.NotImplementedException();
        }
    }
}