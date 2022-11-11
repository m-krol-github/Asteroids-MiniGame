using Gameplay.Pool;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Gameplay.Obstacles
{
    public class BaseAsteroid : MonoBehaviour
    {
        [SerializeField] protected float minMoveSpeed;
        [SerializeField] protected float maxMoveSpeed;
        [SerializeField] protected float moveSpeed;
        [SerializeField] protected float rotateSpeed;
        [SerializeField] protected Vector2 moveDirection;

        [SerializeField] protected int scoreForPlayer;

        [SerializeField] protected Sprite[] asteroidSpriteSet;

        [SerializeField] protected Rigidbody2D rb;
        [SerializeField] protected Collider2D col;
        [SerializeField] protected SpriteRenderer asteroidRenderer;

        [Range(0f, 45f)]
        [SerializeField] protected float trajectoryVariance = 15f;

        protected void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            col = GetComponent<Collider2D>();
            asteroidRenderer = GetComponent<SpriteRenderer>();
        }

        protected void OnEnable()
        {

            int asteroid = Random.Range(0, asteroidSpriteSet.Length);
            asteroidRenderer.sprite = asteroidSpriteSet[asteroid];

            transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);

            Vector2 spawnDirection = Random.insideUnitCircle.normalized;

            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            // Set the trajectory to move in the direction of the spawner
            Vector2 trajectory = rotation * -spawnDirection;
            SetTrajectory(trajectory);
        }

        protected virtual void SetTrajectory(Vector2 direction)
        {
            float speed = Random.Range(minMoveSpeed, maxMoveSpeed);
            rb.AddForce(direction * speed);
        }

        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                PoolManager.Instance.ReturnObject(collision.gameObject, 0f);
                
                PoolManager.Instance.ReturnObject(this.gameObject, 0f);
            }
        }
    }
}