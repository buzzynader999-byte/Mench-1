using System.Collections.Generic;
using _Scripts.Tiles;
using UnityEngine;

namespace _Scripts.Boards
{
    public class Board :ScriptableObject, IBoard
    {
        private List<ITile>[] paths = new List<ITile>[4];
        private ITile[] startTiles;
        private ITile[] goalTiles;

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
            throw new System.NotImplementedException();
        }

        public List<ITile> GetPath(int playerId)
        {
            throw new System.NotImplementedException();
        }
    }
}