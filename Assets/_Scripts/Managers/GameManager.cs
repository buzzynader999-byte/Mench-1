using _Scripts.Boards;
using _Scripts.Dices;
using _Scripts.GameRules;
using _Scripts.Pieces.Move;
using _Scripts.Players;
using _Scripts.Turn;
using UnityEngine;

namespace _Scripts.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        private Board _board;
        private TurnManager _turnManager;
        private MoveHandler _moveHandler;
        private Dice _dice;
        private LudoRule _gameRule;

        private void Start()
        {
            _board.InitializeBoard();
            //turnManager = new TurnManager(new List<IPlayer> { new HumanPlayer(0), new AIPlayer(1) });
        }

        public void PlayTurn(int pieceIndex)
        {
            var player = _turnManager.GetCurrentPlayer();
            int diceValue = _dice.Roll();
            var piece = player.GetPieces()[pieceIndex];
            if (_moveHandler.ValidateMove(player, piece, diceValue, _board))
            {
                _moveHandler.ApplyMove(player, piece, diceValue, _board);
                if (_dice.CanRollAgain()) _turnManager.GrantExtraTurn();
                else _turnManager.SwitchTurn();
                if (_gameRule.IsGameOver(_board)) EndGame(_gameRule.GetWinner(_board));
            }
        }

        private void EndGame(IPlayer winner)
        {
            Debug.Log(winner != null ? $"Player {winner.GetId()} wins!" : "Game Over!");
        }
    }
}