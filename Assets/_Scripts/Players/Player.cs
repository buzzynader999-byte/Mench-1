using System;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Pieces;
using _Scripts.Tiles;
using UnityEngine;

namespace _Scripts.Players
{
    public abstract class Player : MonoBehaviour, IPlayer
    {
        public int Id => _id;
        [SerializeField] private int _id;
        [SerializeField] private List<Piece> pieces;
        [SerializeField] private PlayerColor color;
        public PlayerColor Color => color;
        public List<Tile> Path { set; get; }
        public List<Piece> Pieces => pieces;
        public static bool CanSelectPiece = false;
        private void OnEnable()
        {
            foreach (var piece in pieces)
            {
                piece.Player = this;
            }
        }
        
        public bool HasPiecesInPlay()
        {
            return pieces.Any(target => target.IsInPlay);
        }

        public Piece AddOnePieceToPlay()
        {
            foreach (var target in pieces.Where(target => !target.IsInPlay))
            {
                if (!target.IsInPlay)
                {
                    print("a piece added to play");
                    target.IsInPlay = true;
                    return target;
                }
            }

            print("All pieces are in play ...");
            return null;
        }

        public void CheckForWin()
        {
            int count = 0;
            foreach (var piece in pieces)
            {
                if (piece.IsInGoal())
                {
                    count++;
                }
            }

            if (count == pieces.Count)
            {
                print(Color + " Win! . . .");
            }
        }
    }
}