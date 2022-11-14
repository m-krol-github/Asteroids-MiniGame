using Gameplay.Input;
using UnityEngine;
using Gameplay.Pool;
using System.Collections;

namespace Gameplay.GamePlayer
{

    public sealed class Player : ScreenWrap, IAsteroidCollision
    {
        [Header("Player Components"), Space]
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Collider2D col;

        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _shootPoint;

        [SerializeField] private Renderer _renderer;

        [Header("Player Move"), Space]
        [SerializeField] private PlayerMoveAndRotate _moveRoation;
       
        private float _moveSpeed;
        private float _shootForce = 25f;

        private Vector2 currentDirection;
        private Vector2 mousePointerPosition;

        private GameManager _manager;
        private PoolManager _pooling;
        private UserInputs _inputs;
        
        private void Awake()
        {
            _inputs = new UserInputs();
            _inputs.Shooting.Shoot.performed += (ctx) => Shoot();
        }

        private void OnEnable()
        {
            _inputs.Enable();
        }
        
        public void PlayerInit(GameManager manager, PoolManager pooling, float moveSpeed, float shootForce)
        {
            _manager = manager;
            _pooling = pooling;
            _moveSpeed = moveSpeed;
            _shootForce = shootForce;
        }

        protected override void Update()
        {
            base.Update();

            currentDirection = _inputs.Moving.MoveKeys.ReadValue<Vector2>();
            mousePointerPosition = _inputs.Moving.PointerPosition.ReadValue<Vector2>();

            _moveRoation.MoveShip(rb, currentDirection, _moveSpeed);

            _moveRoation.UpdateRotation(mousePointerPosition);
        }

        private bool IsVisible()
        {
            if (_renderer.isVisible)
            {
                return true;
            }
            
            return false;
        }

        private void Shoot()
        {
            StartCoroutine(ShootRoutine());
        }

        private IEnumerator ShootRoutine()
        {
            GameObject go = _pooling.UseObject(_bullet, _shootPoint.position, transform.rotation);
            Rigidbody2D bulletBody = go.GetComponent<Rigidbody2D>();

            bulletBody.AddForce(transform.up * _shootForce, ForceMode2D.Impulse);
            yield return null;
        }

        public void AsteroidCollision()
        {
            col.enabled = false;

            _manager.UIGameplay.UIGameInfo.TakeLife(1);
            _manager.PlayerManager.PlayerDispatch();

            Destroy(this.gameObject);
        }

        private void OnDisable()
        {
            _inputs.Disable();
        }
    }
}