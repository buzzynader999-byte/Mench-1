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
using UnityEngine.Networking;
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

        private void Update()
        {
            if (Keyboard.current.mKey.wasPressedThisFrame)
            {
                PerformTurn();
            }
        }

        void PerformTurn()
        {
            StartCoroutine(PerformDice());
        }

        IEnumerator PerformDice()
        {
            _dice.FakeRoll(fakeRoll);
            print(_dice.LastRoll);
            if (_dice.CanRollAgain())
            {
                if (_dice.NumberOfSixes >= 3)
                {
                    print(_turnManager.GetCurrentPlayer().Color + " turn burned");
                    NextPlayer();
                }
                else
                {
                    yield return new WaitForSeconds(1);
                    print("Perform dice again");
                    StartCoroutine(PerformDice());
                }
            }
            else
            {
                print("Dice ended");
                StartCoroutine(PerformMove(_turnManager.GetCurrentPlayer()));
            }
        }

        private IEnumerator PerformMove(Player player)
        {
            var movablePieces = _moveHandler.ValidateMoveForAll(player, _dice.DiceRolls);
            if (movablePieces?.Count >= 1 && _dice.DiceRolls.Count >= 1)
            {
                print("we have movable pieces");
                // let player selects pieces
                //todo: handle player selection move


                var targetPiece = GetPiece(movablePieces);
                int selectedDice = 0;
                foreach (var diceDiceRoll in _dice.DiceRolls)
                {
                    if (!_moveHandler.ValidateMove(player, targetPiece, diceDiceRoll)) continue;
                    selectedDice = diceDiceRoll;
                }

                _dice.DiceRolls?.Remove(selectedDice);
                print("Dice available numbers count " + _dice.DiceRolls.Count);

                //if (_moveHandler.ValidateMove(player, targetPiece, selectedDice))
                //{
                _moveHandler.ApplyMove(player, targetPiece, selectedDice);
                yield return new WaitForSeconds(1);
                if (_dice.DiceRolls.Count >= 1)
                {
                    StartCoroutine(PerformMove(player));
                }
                else
                {
                    NextPlayer();
                }
                //}
            }
            else if (_dice?.DiceRolls[0] == 6)
            {
                var newInPlayPiece = player.AddOnePieceToPlay();
                if (!newInPlayPiece) // if it is null, then it mean all pieces are in play
                {
                    NextPlayer();
                }
                else
                {
                    _dice.DiceRolls.RemoveAt(0);
                    if (_dice.DiceRolls.Count >= 1)
                    {
                        StartCoroutine(PerformMove(player));
                    }
                }
            }
            else
            {
                NextPlayer();
            }
        }

        void NextPlayer()
        {
            _turnManager.SwitchTurn();
            _dice.Reset();
        }

        Piece GetPiece(List<Piece> movablePieces)
        {
            //todo: select with player choose later
            return movablePieces[Random.Range(0, movablePieces.Count)];
        }

        int GetSelectedDice()
        {
            return _dice.DiceRolls[Random.Range(0, _dice.DiceRolls.Count)];
        }

        private void EndGame(IPlayer winner)
        {
            Debug.Log(winner != null ? $"Player {winner.Id} wins!" : "Game Over!");
        }
    }
}