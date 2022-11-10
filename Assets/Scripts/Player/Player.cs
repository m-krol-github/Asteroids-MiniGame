using Gameplay.Input;
using UnityEngine.InputSystem;
using UnityEngine;
using System;
using Gameplay.Pool;
using System.Collections;
using Gameplay.Weapons;

namespace Gameplay.GamePlayer
{

    public sealed class Player : MonoBehaviour, IAsteroidCollision
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _shootForce = 25f;

        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Collider2D col;

        [SerializeField] private int hp;

        [SerializeField] private Vector2 currentDirection;
        [SerializeField] private Vector2 moveDirection;
        [SerializeField] private Vector2 mousePointerPosition;

        [SerializeField] private PlayerMoveAndRotate _moveRoation;

        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _shootPoint;

        private GameManager _manager;
        private PoolManager _pooling;
        private UserInputs _inputs;
        
        private void Awake()
        {
            _inputs = new UserInputs();
            _inputs.Mouse.PrimaryButton.performed += (ctx) => Shoot();
        }

        private void OnEnable()
        {
            _inputs.Enable();
        }
        
        public void PlayerInit(GameManager manager, PoolManager pooling, float moveSpeed)
        {
            _manager = manager;
            _pooling = pooling;
            _moveSpeed = moveSpeed;

            Values.PlayerValues.IsPlayerInitialized = true;
        }

        public void Update()
        {
            currentDirection = _inputs.Keyboard.MoveKeys.ReadValue<Vector2>();
            mousePointerPosition = _inputs.Mouse.PointerPosition.ReadValue<Vector2>();

            _moveRoation.MoveShip(rb, currentDirection, _moveSpeed);

            _moveRoation.UpdateRotation(mousePointerPosition);

            if (hp <= 0)
                LifeLost();    
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

        public void AsteroidCollision(int cost)
        {
            hp -= cost;
        }

        private void LifeLost()
        {
            
        }

        private void OnDisable()
        {
            _inputs.Disable();
        }

    }
}