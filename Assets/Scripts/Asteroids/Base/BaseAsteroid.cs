using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Gameplay.Obstacles
{
    public class BaseAsteroid : MonoBehaviour
    {
        public IObjectPool<BaseAsteroid> Pool { get; set; }

        [SerializeField] protected float moveSpeed;
        [SerializeField] protected float maxMoveSpeed;

        [SerializeField] protected float rotateSpeed;

        [SerializeField] protected Vector2 moveDirection;

        [SerializeField] protected int scoreForPlayer;

        [SerializeField] protected Sprite[] asteroidSpriteSet;

        [SerializeField] protected Rigidbody2D rb;
        [SerializeField] protected Collider2D col;
        [SerializeField] protected SpriteRenderer asteroidRenderer;


        protected void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            col = GetComponent<Collider2D>();
            asteroidRenderer = GetComponent<SpriteRenderer>();
        }

        protected void Start()
        {
            int asteroid = Random.Range(0, asteroidSpriteSet.Length);
            asteroidRenderer.sprite = asteroidSpriteSet[asteroid];
        }

        public void ReturnToPool()
        {
            Pool.Release(this);
        }

        protected virtual void Update()
        {

        }

        public void SpawnAsteroid()
        {
            int asteroid = Random.Range(0, asteroidSpriteSet.Length);
            Instantiate(asteroidSpriteSet[asteroid]);


        }
    }
}