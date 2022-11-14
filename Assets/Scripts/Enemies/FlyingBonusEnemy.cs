using Gameplay.Pool;
using System.Collections;
using UnityEngine;

namespace Gameplay.Obstacles
{
    public class FlyingBonusEnemy : BaseEnemy
    {
        [SerializeField] private float lifeTimer;
        [SerializeField] private float moveTimer;

        [SerializeField] private float direction;

        private void OnEnable()
        {
            ReturnEnemy(lifeTimer);

            direction = 1;

            SetMove(direction);
        }

        private void ReturnEnemy(float t)
        {
            PoolManager.Instance.ReturnObject(this.gameObject, t);
        }

        private void SetMove(float dir)
        {
            rb.AddForce(new Vector2(dir, 4) * moveSpeed, ForceMode2D.Force);
        }

        protected override void OnCollisionEnter2D(Collision2D collision)
        {
            base.OnCollisionEnter2D(collision);

            if (collision.gameObject.CompareTag("Asteroid"))
            {
                direction = -direction;
                SetMove(direction);
            }
        }
    }
}