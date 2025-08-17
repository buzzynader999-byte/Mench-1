using System;
using System.Collections.Generic;
using _Scripts.Players;
using UnityEngine;

namespace _Scripts.Tiles
{
    public class PathKeeper : MonoBehaviour
    {
        [SerializeField] private List<Tile> yellowPath;
        [SerializeField] private List<Tile> bluePath;
        [SerializeField] private List<Tile> redPath;
        [SerializeField] private List<Tile> greenPath;
        private Dictionary<PlayerColor, List<Tile>> _registeredPaths = new();

        private void Awake()
        {
            RegisterPaths();
        }

        private void RegisterPaths()
        {
            _registeredPaths.Add(PlayerColor.Blue, bluePath);
            _registeredPaths.Add(PlayerColor.Red, redPath);
            _registeredPaths.Add(PlayerColor.Yellow, yellowPath);
            _registeredPaths.Add(PlayerColor.Green, greenPath);
        }

        public List<Tile> GetPath(PlayerColor color)
        {
            if (_registeredPaths.TryGetValue(color, out var path))
            {
                return path;
            }

            //Debug.LogError(color + " path not found");
            return null;
        }
    }
}