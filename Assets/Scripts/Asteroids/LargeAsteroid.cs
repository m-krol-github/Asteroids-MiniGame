using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Obstacles
{
    public class LargeAsteroid : BaseAsteroid
    {
        protected override void SetTrajectory(Vector2 direction)
        {
            base.SetTrajectory(direction);

        }

        protected override void OnCollisionEnter2D(Collision2D collision)
        {
            base.OnCollisionEnter2D(collision);

            if (collision.gameObject.CompareTag("Bullet"))
            {
                GameManager.Instance.UIGameplay.UIGameInfo.AddScore(100);
            }
        }
    }
}