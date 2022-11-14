using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Gameplay.UI
{
    public sealed class UIGameplay : BaseView
    {
        [SerializeField] private UIGameInfo _gameInfo;
        public UIGameInfo UIGameInfo => _gameInfo;

        [SerializeField] private UIPause _uiPause;
        public UIPause UIPause => _uiPause;

        [SerializeField] private UIGameOver _gameOver;
        
        [SerializeField] private Button pauseButton;

        private GameManager _manager;

        public void InitGameplay(GameManager manager)
        {
            this._manager = manager;
            
            _uiPause.InitPause(manager);
            _gameInfo.InitGameInfo(manager);
            _gameOver.InitGameOver(manager);
            
            _uiPause.HideView();
            _gameOver.HideView();
            
            _gameInfo.ShowView();
            
            AssignActions();
        }

        private void AssignActions()
        {
            pauseButton.onClick.AddListener(() =>
            {
               _manager.PauseUnpause(); 
            });
        }
    }
}