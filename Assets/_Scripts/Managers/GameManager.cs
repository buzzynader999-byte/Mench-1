using System;
using System.Collections.Generic;
using _Scripts.Boards;
using _Scripts.Dices;
using _Scripts.GameRules;
using _Scripts.Pieces.Move;
using _Scripts.Players;
using _Scripts.Turn;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField]private Board _board;
        private TurnManager _turnManager;
        MoveHandler _moveHandler = new MoveHandler();
        private Dice _dice = new Dice();
        private LudoRule _gameRule;
        [SerializeField] private Player p1;
        [SerializeField] private Player p2;
        private void Start()
        {
            _board.InitializeBoard();
            _turnManager = new TurnManager(new List<IPlayer> { p1,p2 });
        }

        public void PlayTurn(int pieceIndex)
        {
            var player = _turnManager.GetCurrentPlayer();
            int diceValue = _dice.Roll();
            var piece = player.GetPieces()[pieceIndex];
            if (_moveHandler.ValidateMove(player, piece, diceValue, _board))
            {
                _moveHandler.ApplyMove(player, piece, diceValue, _board);
                //if (_dice.CanRollAgain()) _turnManager.GrantExtraTurn();
                //else _turnManager.SwitchTurn();
                //if (_gameRule.IsGameOver(_board)) EndGame(_gameRule.GetWinner(_board));
            }
        }

        private void Update()
        {
            if (Keyboard.current.mKey.wasPressedThisFrame)
            {
                PlayTurn(0);
            }
        }

        private void EndGame(IPlayer winner)
        {
            Debug.Log(winner != null ? $"Player {winner.GetId()} wins!" : "Game Over!");
        }
    }
}