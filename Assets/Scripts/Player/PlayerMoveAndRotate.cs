using UnityEngine;

namespace Gameplay.GamePlayer
{
    public sealed class PlayerMoveAndRotate : MonoBehaviour
    {
        [SerializeField] private Vector2 currentVelocity;
        private Camera cam;

        private void Awake()
        {
            cam = Camera.main;
        }

        public void UpdateRotation(Vector2 mousePosition)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(mousePosition);

            currentVelocity = mousePos - transform.position;
            float angle = Vector2.SignedAngle(Vector2.up, currentVelocity);
            transform.eulerAngles = new Vector3(0, 0, angle);
        }

        public void MoveShip(Rigidbody2D rb, Vector2 currentDirection, float _moveSpeed)
        {
            Vector2 moveDirection = (transform.up * currentDirection.y) + (transform.right * currentDirection.x);
            moveDirection = moveDirection * _moveSpeed;
            rb.AddForce(moveDirection * Time.deltaTime, ForceMode2D.Force);
        }
    }
}