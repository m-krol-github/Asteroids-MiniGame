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
        
        [SerializeField] private LevelsManager _levels;
        public LevelsManager Levels => _levels;

        [SerializeField] private PlayerManager _playerManager;

        [SerializeField] private float screenSizeY;
        [SerializeField] private float screenSizeX;

        private Camera mainCam;
        
        protected override void Awake()
        {
            base.Awake();

            _gameplayUI.InitGameplay(this);
            _playerManager.InitPlayerManager(this);
            _levels.Init(this);

            mainCam = Camera.main;
            Debug.Log("GameInit");
        }
                
        private void Update()
        {
            
        }

        public void GameOver()
        {

        }
    }
}