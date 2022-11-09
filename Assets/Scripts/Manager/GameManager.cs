using System;
using Gameplay.GamePlayer;
using Gameplay.UI;
using UnityEngine;

namespace Gameplay
{

    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] private UIGameplay _gameplayUI;
        [SerializeField] private PlayerManager _playerManager;

        [SerializeField] private float sizeY;
        [SerializeField] private float sizeX;

        private Camera mainCam;
        
        private void Awake()
        {
            _gameplayUI.InitGameplay(this);
            _playerManager.InitPlayerManager(this);

            mainCam = Camera.main;
            Debug.Log("GameInit");
        }

        private void Start()
        {
            Values.GameValues.IsGameInitialized = true;
        }
        
        private void Update()
        {
            if(Values.GameValues.IsGameInitialized)
                _playerManager.UpdatePlayerManager();

            sizeX = mainCam.sensorSize.x;
            sizeY = mainCam.sensorSize.y;
        }

    }
}