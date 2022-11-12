using Gameplay.Pool;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Gameplay.Obstacles
{
    public class BaseAsteroid : MonoBehaviour
    {
        [SerializeField] protected int scoreForPlayer;
        [Header("Asteroid Move Properties"), Space]
        [Range(0f, 20f)]
        [SerializeField] protected float minMoveSpeed;
        [Range(20f, 45f)]
        [SerializeField] protected float maxMoveSpeed;
        [SerializeField] protected float moveSpeed;
        [Range(0f, 45f)]
        [SerializeField] protected float trajectoryVariance = 15f;


        [Header("Asteroid Sprite Set Random"), Space]
        [SerializeField] protected Sprite[] asteroidSpriteSet;

        [Header("Asteroid Components to fill"), Space]
        [SerializeField] protected Rigidbody2D rb;
        [SerializeField] protected Collider2D col;
        [SerializeField] protected SpriteRenderer asteroidRenderer;


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

            Vector2 trajectory = rotation * -spawnDirection;
            SetTrajectory(trajectory);
        }

        protected virtual void SetTrajectory(Vector2 direction)
        {
            float speed = Random.Range(minMoveSpeed, maxMoveSpeed);
            rb.AddForce(direction * speed);
        }

        protected void Update()
        {
            PositionLimits();
        }

        private void PositionLimits()
        {
            float positionX = Mathf.Clamp(transform.position.x, -Values.GameValues.SCREEN_SIZE_X / 2, Values.GameValues.SCREEN_SIZE_X / 2);
            float positionY = Mathf.Clamp(transform.position.y, -Values.GameValues.SCREEN_SIZE_Y / 2, Values.GameValues.SCREEN_SIZE_Y / 2);


            //Debug.Log(positionX.ToString() + " " + positionY.ToString() + " ");
            //Vector3 screenPosition = transform.position;

            if (transform.position.x > 12)
            {
                transform.position = new Vector2(-12, transform.position.y);
            }

            else if (transform.position.x < -12)
            {
                transform.position = new Vector2(12, transform.position.y);
            }

            else if (transform.position.y > 7.5f)
            {
                transform.position = new Vector2(transform.position.x, -7.5f);
            }

            else if (transform.position.y < -7.5)
            {
                transform.position = new Vector2(transform.position.x, 7.5f);
            }

        }

        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                PoolManager.Instance.ReturnObject(collision.gameObject, 0f);
                
                PoolManager.Instance.ReturnObject(this.gameObject, 0f);

                GameManager.Instance.Levels.AsteroidHit(this.gameObject);
            }

            if (collision.gameObject.CompareTag("Asteroid"))
            {
                Vector2 dir = new Vector2(Random.Range(-1f, 1f),Random.Range(-1f,1f));
                rb.AddForce(dir * minMoveSpeed, ForceMode2D.Force);
            }
        }
    }
}