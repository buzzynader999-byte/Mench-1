using System.Collections.Generic;
using _Scripts.Players;
using _Scripts.Tiles;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Boards
{
    public class Board : MonoBehaviour, IBoard
    {
        [SerializeField] PathKeeper pathKeeper;
        [SerializeField] private Tile[] startTiles;
        [SerializeField] private Tile[] goalTiles;

        public ITile GetTile(int playerId, int index)
        {
            throw new System.NotImplementedException();
        }

        public ITile GetStartTile(int playerId)
        {
            throw new System.NotImplementedException();
        }

        public ITile GetGoalTile(int playerId)
        {
            throw new System.NotImplementedException();
        }

        public void InitializeBoard()
        {
            
        }

        public List<Tile> GetPath(PlayerColor targetPlayer)
        {
            return pathKeeper.GetPath(targetPlayer);
        }
    }
}