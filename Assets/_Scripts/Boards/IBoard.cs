using System.Collections.Generic;
using _Scripts.Players;
using _Scripts.Tiles;

namespace _Scripts.Boards
{
    public interface IBoard
    {

        ITile GetTile(PlayerColor color,int index);
        ITile GetStartTile(PlayerColor color);
        ITile GetGoalTile(PlayerColor color);
        void InitializeBoard(List<Player> players);
        List<Tile> GetPath(PlayerColor targetPlayer);
    }
}