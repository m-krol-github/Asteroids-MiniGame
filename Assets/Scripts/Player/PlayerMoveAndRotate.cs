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

        public void MovePosition(Vector2 mousePosition, float speed, float smoothTime, float minDistance)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(mousePosition);
            // Offsets the target position so that the object keeps its distance.
            mousePos += ((Vector2)transform.position - mousePos).normalized * minDistance;
            transform.position = Vector2.SmoothDamp(transform.position, mousePos, ref currentVelocity, smoothTime, speed);

        }

        public void MoveKeysPosition(Rigidbody2D rb,Vector2 direction, float speed)
        {
            
        }
    }
}