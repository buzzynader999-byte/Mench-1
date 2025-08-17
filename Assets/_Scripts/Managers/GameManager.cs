using System;
using System.Collections.Generic;
using _Scripts.Boards;
using _Scripts.Dices;
using _Scripts.GameRules;
using _Scripts.Pieces;
using _Scripts.Pieces.Move;
using _Scripts.Players;
using _Scripts.Turn;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private Board _board;
        private TurnManager _turnManager;
        MoveHandler _moveHandler = new MoveHandler();
        private Dice _dice = new Dice();
        private LudoRule _gameRule;
        [SerializeField] List<Player> players = new List<Player>();
        [SerializeField] [Range(0, 6)] private int fakeRoll;

        private void Start()
        {
            _board.InitializeBoard(players);
            _turnManager = new TurnManager(players);
        }

        public void PlayTurn()
        {
            var player = _turnManager.GetCurrentPlayer();
            var piece = player.GetPieces()[0]; //todo: use player selection piece
            PerformMove(player, piece);
        }

        void PerformMove(Player player, Piece piece)
        {
            var diceValue = fakeRoll == 0 ? _dice.Roll() : fakeRoll;
            print(diceValue);
            if (player.HasPiecesInPlay())
            {
                if (_moveHandler.ValidateMove(player, piece, diceValue, _board))
                {
                    _moveHandler.ApplyMove(player, piece, diceValue, _board);
                    if (fakeRoll == 0 ? _dice.CanRollAgain() : fakeRoll == 6)
                    {
                        _turnManager.GrantExtraTurn();
                    }
                    else _turnManager.SwitchTurn();
                    //if (_gameRule.IsGameOver(_board)) EndGame(_gameRule.GetWinner(_board));
                }
            }
            else if (diceValue == 6)
            {
                var newInPlayPiece = player.AddOnePieceToPlay();
                _moveHandler.ApplyMove(player,newInPlayPiece,1,_board);
            }
            else
            {
                _turnManager.SwitchTurn();
            }
        }

        private void Update()
        {
            if (Keyboard.current.mKey.wasPressedThisFrame)
            {
                PlayTurn();
            }
        }

        private void EndGame(IPlayer winner)
        {
            Debug.Log(winner != null ? $"Player {winner.GetId()} wins!" : "Game Over!");
        }
    }
}