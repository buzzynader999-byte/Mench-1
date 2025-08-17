using System.Collections.Generic;
using _Scripts.Players;
using UnityEngine;

namespace _Scripts
{
    public class PlayerPieceStation : MonoBehaviour
    {
        [SerializeField] private List<Transform> piecePlaces;
        [SerializeField] private PlayerColor targetColor;
        public PlayerColor TargetColor => targetColor;

        public void SetUpPiecesInStation(Player targetPlayer)
        {
            var pieces = targetPlayer.GetPieces();
            for (var i = 0; i < pieces.Count; i++)
            {
                pieces[i].transform.position = piecePlaces[i].transform.position;
            }

            targetPlayer.transform.localPosition = targetPlayer.transform.position;
        }

        private void OnValidate()
        {
            if (piecePlaces.Count > 4)
            {
                piecePlaces.RemoveRange(4, piecePlaces.Count - 4);
            }
        }
    }
}