using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.GamePlayer
{

    public class PlayerManager : MonoBehaviour
    {
        [Header("Player InGame Properties")]
        [SerializeField] private int playerLives;
        [Space]
        [SerializeField] private float playerSpeed;
        [Space]
        [Header("Player Ship Prefab")]
        [SerializeField] private Player _player;

        [SerializeField] private Transform playerStartPoint;
        
        private GameManager _manager;

        public void InitPlayerManager(GameManager manager)
        {
            _manager = manager;
        }

        private void PlayerDispatch()
        {
            Player player = Instantiate(_player, playerStartPoint.position, transform.rotation);
            
        }
    }
}