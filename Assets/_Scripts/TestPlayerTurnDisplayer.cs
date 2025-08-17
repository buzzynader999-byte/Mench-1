using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class TestPlayerTurnDisplayer:MonoBehaviour
    {
        public static TestPlayerTurnDisplayer Instance;
        [SerializeField] private Transform displayer;
        [SerializeField] private List<Transform> positions;
        private void Awake()
        {
            Instance = this;
        }

        public void ChangePlayer(int index)
        {
            displayer.transform.position = positions[index].position;
        }
    }
}