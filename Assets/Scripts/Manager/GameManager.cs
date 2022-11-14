using System;
using Gameplay.GamePlayer;
using Gameplay.Input;
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

        public bool IsGamePaused { get; private set; }

        private UserInputs _inputs;

        protected override void Awake()
        {
            base.Awake();
            
            PlayerLifes = 3;
            Time.timeScale = 1;

            _inputs = new UserInputs();

            _gameplayUI.InitGameplay(this);
            _playerManager.InitPlayerManager(this);
            _levels.Init(this);

            _inputs.GameControls.Cancel.performed += (ctx) => PauseUnpause();

            Debug.Log("GameInit");
        }

        private void OnEnable()
        {
            _inputs.Enable();
        }

        public void PauseUnpause()
        {
            IsGamePaused = !IsGamePaused;

            if (IsGamePaused)
            {
                _gameplayUI.UIPause.ShowView();
                Time.timeScale = 0;
            }
            else if (!IsGamePaused)
            {
                _gameplayUI.UIPause.HideView();
                Time.timeScale = 1;
            }
        }

        public void GameOver()
        {
            SceneLoadManager.Instance.LoadScene(SceneLoadManager.SCENE_EXITGAME);
        }


        private void OnDisable()
        {
            _inputs.Disable();
        }
    }
}