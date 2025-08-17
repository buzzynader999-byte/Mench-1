using System.Collections.Generic;
using _Scripts.Pieces;
using _Scripts.Tiles;
using UnityEngine;

namespace _Scripts.Players
{
    public abstract class Player : MonoBehaviour, IPlayer
    {
        [SerializeField] private int _id;
        [SerializeField] private List<Piece> pieces;
        [SerializeField] private PlayerColor color;
        public List<Tile> Path { set; get; }
        public int GetId()
        {
            return _id;
        }

        public List<Piece> GetPieces()
        {
            return pieces;
        }

        public PlayerColor GetColor()
        {
            return color;
        }
    }
}