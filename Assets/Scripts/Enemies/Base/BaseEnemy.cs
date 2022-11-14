
using Gameplay.GamePlayer;
using Gameplay.Pool;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Obstacles
{
    public class BaseEnemy : ScreenWrap
    {
        [SerializeField] private int scoreForPlayer;
        [Range(1, 500)]
        [SerializeField] protected float moveSpeed;
        [Range(1,50)]
        [SerializeField] protected float trajectoryVariance;
        [SerializeField] protected Rigidbody2D rb;
        [SerializeField] protected Collider2D col;

        protected void Awake()
        {
            rb.gravityScale = 0;
        }

        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                PoolManager.Instance.ReturnObject(collision.gameObject, 0f);
                PoolManager.Instance.ReturnObject(this.gameObject, 0f);
                GameManager.Instance.UIGameplay.UIGameInfo.AddScore(scoreForPlayer);
            }

            if (collision.gameObject.CompareTag("Enemy"))
            {
                Vector2 dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                rb.AddForce(dir * moveSpeed, ForceMode2D.Force);
            }

            if (collision.gameObject.GetComponent<Player>())
            {
                col.enabled = false;
                GameManager.Instance.UIGameplay.UIGameInfo.AddScore(scoreForPlayer);
                PoolManager.Instance.ReturnObject(this.gameObject, 0f);
                Destroy(collision.gameObject);

                GameManager.Instance.PlayerManager.PlayerDispatch();
            }
        }
    }
}