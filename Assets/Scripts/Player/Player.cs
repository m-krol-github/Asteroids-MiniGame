using Gameplay.Input;
using UnityEngine.InputSystem;
using UnityEngine;
using System;

namespace Gameplay.GamePlayer
{

    public sealed class Player : MonoBehaviour, IAsteroidCollision
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;

        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Collider2D col;

        [SerializeField] private int hp;

        [SerializeField] private Vector2 currentDirection;
        [SerializeField] private Vector2 moveDirection;
        [SerializeField] private Vector2 mousePointerPosition;

        [SerializeField] private PlayerMoveAndRotate _moveRoation;
        
        private GameManager _manager;
        private UserInputs _inputs;
        
        private void Awake()
        {
            _inputs = new UserInputs();
        }

        private void OnEnable()
        {
            _inputs.Enable();
        }
        
        public void PlayerInit(GameManager manager, float moveSpeed, float rotateSpeed)
        {
            _manager = manager;
            _moveSpeed = moveSpeed;
            _rotateSpeed = rotateSpeed;

            Values.PlayerValues.IsPlayerInitialized = true;
        }

        public void Update()
        {
            currentDirection = _inputs.Keyboard.MoveKeys.ReadValue<Vector2>();
            mousePointerPosition = _inputs.Mouse.PointerPosition.ReadValue<Vector2>();

            MoveShip();

            RotateShip();

            if(hp <= 0)
                LifeLost();    
        }

        private void RotateShip()
        {
            _moveRoation.UpdateRotation(mousePointerPosition);
        }

        private void MoveShip()
        {
            moveDirection = (transform.up * currentDirection.y) + (transform.right * currentDirection.x);
            moveDirection = moveDirection * _moveSpeed;
            rb.AddForce(moveDirection * Time.deltaTime, ForceMode2D.Force);
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