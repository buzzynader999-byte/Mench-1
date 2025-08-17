using System.Collections.Generic;
using System.Linq;
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

        public bool HasPiecesInPlay()
        {
            return pieces.Any(target => target.IsInPlay);
        }

        public Piece AddOnePieceToPlay()
        {
            foreach (var target in pieces.Where(target => !target.IsInPlay))
            {
                target.IsInPlay = true;
                return target;
            }
            print("All pieces are in play ...");
            return null;
        }
    }
}