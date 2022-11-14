using Gameplay.Pool;
using UnityEngine;

namespace Gameplay.GamePlayer
{

    public sealed class PlayerManager : MonoBehaviour
    {
        [Header("Player InGame Properties"), Space]
        [Range(100,300)]
        [SerializeField] private float playerSpeed;
        [Range(10,50)]
        [SerializeField] private float bulletShootForce;
        
        [Header("Player Ship Prefab"), Space]
        [SerializeField] private Player _player;
        [SerializeField] private Transform playerStartPoint;

        [Space]
        [Header("Pooling References")]
        [SerializeField] private PoolManager _pooling;

        private GameManager _manager;
        private Player playgamePlayer;

        public void InitPlayerManager(GameManager manager)
        {
            _manager = manager;
            
            PlayerDispatch();
        }

        public void PlayerDispatch()
        {
            if (playgamePlayer != null)
                Destroy(playgamePlayer.gameObject);

            if (_manager.PlayerLifes == 0)
            {
                _manager.GameOver();
                return;
            }

            Player player = Instantiate(_player, playerStartPoint.position, transform.rotation);
            playgamePlayer = player;
            player.PlayerInit(_manager, _pooling, playerSpeed, bulletShootForce);

            //take life from totalNumber of lifes
            _manager.PlayerLifes--;
        }
    }
}