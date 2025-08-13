using System.Collections.Generic;
using _Scripts.Players;
using _Scripts.Tiles;

namespace _Scripts.Boards
{
    public interface IBoard
    {

        ITile GetTile(int playerId, int index);
        ITile GetStartTile(int playerId);
        ITile GetGoalTile(int playerId);
        void InitializeBoard();
        List<Tile> GetPath(PlayerColor targetPlayer);
    }
}