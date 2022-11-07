using System;
using Gameplay.UI;
using UnityEngine;

namespace Gameplay
{

    public class GameManager : MonoBehaviour
    {
        [SerializeField] private UIGameplay _gameplay;
        private void Awake()
        {
            _gameplay.InitGameplay(this);
            Debug.Log("GameInit");
        }
    }
}