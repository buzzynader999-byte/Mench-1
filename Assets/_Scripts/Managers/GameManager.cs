using System;
using System.Collections;
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
using Random = UnityEngine.Random;

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
            //var piece = player.Pieces[0]; //todo: use player selection piece
            PerformTurn(player); //, piece);
        }

        IEnumerator PerformDice()
        {
            var diceValue = fakeRoll == 0 ? _dice.Roll() : fakeRoll;
            print(diceValue);
            if (diceValue == 6)
            {
                _dice.NumberOfSixes++;
                if (_dice.NumberOfSixes >= 3)
                {
                    print(_turnManager.GetCurrentPlayer().Color + " turn burned");
                    _turnManager.SwitchTurn();
                    _dice.NumberOfSixes = 0;
                }
                else
                {
                    _turnManager.DiceRolls.Add(diceValue);
                    yield return new WaitForSeconds(1);
                    print("Perform dice again");
                    StartCoroutine(PerformDice());
                }
            }
            else
            {
                _turnManager.DiceRolls.Add(diceValue);
                _dice.NumberOfSixes = 0;
                StartCoroutine(PerformMove(_turnManager.GetCurrentPlayer()));
            }

            print("Dice ended");
        }

        IEnumerator PerformMove(Player player)
        {
            var allMovablePieces = _moveHandler.ValidateMoveForAll(player, _turnManager.DiceRolls);
            if (allMovablePieces?.Count >= 1)
            {
                // let player selects pieces
                //todo: handle player selection move

                var targetPiece = allMovablePieces[Random.Range(0, allMovablePieces.Count)];
                allMovablePieces.Remove(targetPiece);

                var selectedDice = _turnManager.DiceRolls[Random.Range(0, _turnManager.DiceRolls.Count)];
                _turnManager.DiceRolls.Remove(selectedDice);
                if (_moveHandler.ValidateMove(player, targetPiece, selectedDice))
                {
                    _moveHandler.ApplyMove(player, targetPiece, selectedDice);
                    yield return new WaitForSeconds(1);
                    if (_turnManager.DiceRolls.Count >= 1)
                    {
                        StartCoroutine(PerformMove(player));
                    }
                    else
                    {
                        _turnManager.SwitchTurn();
                        _dice.NumberOfSixes = 0;
                    }
                }
            }
            else if (_turnManager?.DiceRolls[0] == 6)
            {
                var newInPlayPiece = player.AddOnePieceToPlay();
                if (!newInPlayPiece) // if it is null, then it mean all pieces are in play
                {
                    _turnManager.SwitchTurn();
                    _dice.NumberOfSixes = 0;
                }
                else
                {
                    _turnManager.DiceRolls.RemoveAt(0);
                    if (_turnManager.DiceRolls.Count >= 1)
                    {
                        StartCoroutine(PerformMove(player));
                        /*allMovablePieces = _moveHandler.ValidateMoveForAll(player, _turnManager.DiceRolls);
                        if (allMovablePieces?.Count >= 1)
                        {
                            // let player selects pieces
                            //todo: handle player selection move
                            var targetPiece = allMovablePieces[Random.Range(0, allMovablePieces.Count)];
                            if (_moveHandler.ValidateMove(player, targetPiece, diceValue))
                            {
                                _moveHandler.ApplyMove(player, targetPiece, diceValue);
                            }
                        }*/
                    }
                }
            }
            else
            {
                _turnManager.SwitchTurn();
                _dice.NumberOfSixes = 0;
            }
        }

        void PerformTurn(Player player)
        {
            StartCoroutine(PerformDice());


            /*if (player.HasPiecesInPlay() && _moveHandler.ValidateMove(player, piece, diceValue, _board))
            {
                _moveHandler.ApplyMove(player, piece, diceValue, _board);
                if (fakeRoll == 0 ? _dice.CanRollAgain() : fakeRoll == 6)
                {
                    _turnManager.GrantExtraTurn();
                }
                else _turnManager.SwitchTurn();
                //if (_gameRule.IsGameOver(_board)) EndGame(_gameRule.GetWinner(_board));
            }
            else if (diceValue == 6)
            {
                print(player.HasPiecesInPlay() + " no in play pieces yet. will added");
                var newInPlayPiece = player.AddOnePieceToPlay();
                _moveHandler.ApplyMove(player, newInPlayPiece, 0, _board);
            }
            else
            {
                _turnManager.SwitchTurn();
            }*/
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
            Debug.Log(winner != null ? $"Player {winner.Id} wins!" : "Game Over!");
        }
    }
}