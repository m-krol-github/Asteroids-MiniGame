using Gameplay.GamePlayer;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Obstacles
{
    public class SmallAsteroid : BaseAsteroid
    {

       

        protected override void OnCollisionEnter2D(Collision2D collision)
        {
            base.OnCollisionEnter2D(collision);

            if (collision.gameObject.CompareTag("Bullet"))
            {
                GameManager.Instance.UIGameplay.UIGameInfo.AddScore(400);
            }

            if (collision.gameObject.GetComponent<Player>())
            {
                GameManager.Instance.UIGameplay.UIGameInfo.AddScore(400);
                GameManager.Instance.Levels.AsteroidHit(this.gameObject);
                collision.gameObject.GetComponent<Player>().AsteroidCollision();
            }
        }
    }
}