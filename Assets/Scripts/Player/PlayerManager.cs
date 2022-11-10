using Gameplay.Pool;

using UnityEngine;

namespace Gameplay.GamePlayer
{

    public sealed class PlayerManager : MonoBehaviour
    {
        [Header("InGame Player(null in editor)"), SerializeField]
        private Player playgamePlayer;
        
        [Header("Player InGame Properties")]
        [Space]
        [SerializeField] private float playerSpeed;
        [SerializeField] private int playerLives;
        [Space]
        [Header("Player Ship Prefab")]
        [SerializeField] private Player _player;

        [SerializeField] private Transform playerStartPoint;

        [SerializeField] private PoolManager _pooling;
        private GameManager _manager;

        public void InitPlayerManager(GameManager manager)
        {
            _manager = manager;
            
            PlayerDispatch();
        }

        private void PlayerDispatch()
        {
            Player player = Instantiate(_player, playerStartPoint.position, transform.rotation);
            playgamePlayer = player;
            player.PlayerInit(_manager, _pooling, playerSpeed);
        }
        
        
    }
}