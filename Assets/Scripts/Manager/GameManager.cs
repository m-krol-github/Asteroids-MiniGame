using System;
using Gameplay.GamePlayer;
using Gameplay.Obstacles;
using Gameplay.UI;
using UnityEngine;

namespace Gameplay
{

    public sealed class GameManager : Singleton<GameManager>
    {
        [SerializeField] private UIGameplay _gameplayUI;
        public UIGameplay UIGameplay => _gameplayUI;

        [SerializeField] private PlayerManager _playerManager;
        [SerializeField] private AsteroidsManager _asteroidsManager;

        [SerializeField] private float screenSizeY;
        [SerializeField] private float screenSizeX;

        private Camera mainCam;
        
        protected override void Awake()
        {
            base.Awake();

            _gameplayUI.InitGameplay(this);
            _playerManager.InitPlayerManager(this);

            mainCam = Camera.main;
            Debug.Log("GameInit");
        }
                
        private void Update()
        {

        }

    }
}