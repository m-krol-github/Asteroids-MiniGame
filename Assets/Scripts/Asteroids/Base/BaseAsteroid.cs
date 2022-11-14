using Gameplay.GamePlayer;
using Gameplay.Pool;
using UnityEngine;

namespace Gameplay.Obstacles
{
    public sealed class BaseAsteroid : ScreenWrap
    {
        [SerializeField] private int scoreForPlayer;
        [Header("Asteroid Move Properties"), Space]
        [Range(20,100)]
        [SerializeField] private float moveSpeed;
        [Range(0f, 45f)]
        [SerializeField] private float trajectoryVariance = 15f;


        [Header("Asteroid Sprite Set Random"), Space]
        [SerializeField] private Sprite[] asteroidSpriteSet;

        [Header("Asteroid Components to fill"), Space]
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Collider2D col;
        [SerializeField] private SpriteRenderer asteroidRenderer;


        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            col = GetComponent<Collider2D>();
            asteroidRenderer = GetComponent<SpriteRenderer>();
        }


        private void OnEnable()
        {
            int asteroid = Random.Range(0, asteroidSpriteSet.Length);
            asteroidRenderer.sprite = asteroidSpriteSet[asteroid];

            transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);

            Vector2 moveDirection = Random.insideUnitCircle.normalized;

            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Vector2 trajectory = rotation * -moveDirection;
            SetTrajectory(trajectory);
        }

        private void SetTrajectory(Vector2 direction)
        {
            rb.AddForce(direction * moveSpeed);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                PoolManager.Instance.ReturnObject(collision.gameObject, 0f);
                GameManager.Instance.Levels.AsteroidHit(this.gameObject);
                GameManager.Instance.UIGameplay.UIGameInfo.AddScore(scoreForPlayer);
            }

            if (collision.gameObject.CompareTag("Asteroid"))
            {
                Vector2 dir = new Vector2(Random.Range(-1f, 1f),Random.Range(-1f,1f));
                rb.AddForce(dir * moveSpeed, ForceMode2D.Force);
            }

            if (collision.gameObject.GetComponent<Player>())
            {
                col.enabled = false;
                GameManager.Instance.UIGameplay.UIGameInfo.AddScore(scoreForPlayer);
                GameManager.Instance.Levels.AsteroidHit(this.gameObject);
                collision.gameObject.GetComponent<Player>().AsteroidCollision();
            }
        }
    }
}