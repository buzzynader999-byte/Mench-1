using System;
using System.Collections.Generic;
using _Scripts.Tiles;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Pieces
{
    public class Piece : MonoBehaviour, IPiece
    {
        private int _playerId;
        private ITile _currentTile;
        private bool _inPlay, _inGoal;
        public int CurrentTileIndex { private set; get; }

        public int GetPlayerId()
        {
            throw new System.NotImplementedException();
        }

        public void MoveToTile(ITile tile, int tileIndex)
        {
            CurrentTileIndex = tileIndex;
            transform.position = tile.GetPosition();
        }

        public bool IsInPlay()
        {
            throw new System.NotImplementedException();
        }

        public bool IsInGoal()
        {
            throw new System.NotImplementedException();
        }
    }
}