using System;
using Gameplay.GamePlayer;
using Gameplay.Obstacles;
using Gameplay.UI;

using MainMenu;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay
{

    public sealed class GameManager : Singleton<GameManager>
    {
        [SerializeField] private UIGameplay _gameplayUI;
        public UIGameplay UIGameplay => _gameplayUI;
        
        [SerializeField] private LevelsManager _levels;
        public LevelsManager Levels => _levels;

        [SerializeField] private PlayerManager _playerManager;
        public PlayerManager PlayerManager => _playerManager;

        [field: SerializeField] public PlayerInformation PlayerInformation { get; private set; }

        public int PlayerLifes { get; set; }

        private Camera mainCam;
        
        protected override void Awake()
        {
            base.Awake();
            PlayerLifes = 3;

            _gameplayUI.InitGameplay(this);
            _playerManager.InitPlayerManager(this);
            _levels.Init(this);

            mainCam = Camera.main;
            Debug.Log("GameInit");
        }

        public void GameOver()
        {
            SceneLoadManager.Instance.LoadScene(SceneLoadManager.SCENE_EXITGAME);
        }
    }
}