using System.Collections.Generic;
using System.Linq;
using _Scripts.Players;
using _Scripts.Tiles;
using UnityEngine;

namespace _Scripts.Boards
{
    public class Board : MonoBehaviour, IBoard
    {
        [SerializeField] PathKeeper pathKeeper;
        [SerializeField] List<PlayerPieceStation> playerPieceStations;

        public ITile GetTile(PlayerColor color, int index)
        {
            return pathKeeper.GetPath(color)[index];
        }

        public ITile GetStartTile(PlayerColor color)
        {
            return pathKeeper.GetPath(color)[0];
        }

        public ITile GetGoalTile(PlayerColor color)
        {
            return pathKeeper.GetPath(color)[^1];
        }

        public void InitializeBoard(List<Player> players)
        {
            foreach (var player in players)
            {
                player.Path = (pathKeeper.GetPath(player.GetColor()));
            }

            foreach (var station in playerPieceStations)
            {
                foreach (var player in players.Where(t => station.TargetColor == t.GetColor()))
                {
                    station.SetUpPiecesInStation(player);
                }
            }
        }

        public List<Tile> GetPath(PlayerColor targetPlayer)
        {
            return pathKeeper.GetPath(targetPlayer);
        }
    }
}