using Gameplay.Pool;

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Gameplay.Obstacles
{
    public sealed class LevelsManager : MonoBehaviour
    {
        [field: SerializeField] public int CurrentLevel { get; set; }

        public float minSpawnDistance = 12f;
        public float maxSpawnDistance = 12f;

        [SerializeField] private LevelsAsset[] levels;

        [SerializeField] private PoolManager _pooling;
        [SerializeField] private AsteroidsTypes _types;

        private int asteroidsNumber;

        private GameManager manager;

        public List<GameObject> totalAsteroids = new();

        public void Init(GameManager manager)
        {
            this.manager = manager;
            CurrentLevel = 0;
        }

        private void Start()
        {
            StartLevel();
        }

        private void StartLevel()
        {
            this.asteroidsNumber = levels[CurrentLevel].asteroidsNumber;

            StartCoroutine(SpawnAsteroids(asteroidsNumber, _types.asteroids[0].gameObject));
            StartCoroutine(SpawnAsteroids(asteroidsNumber, _types.asteroids[1].gameObject));
            StartCoroutine(SpawnAsteroids(asteroidsNumber, _types.asteroids[2].gameObject));
        }

        private IEnumerator SpawnAsteroids(int n, GameObject asteroid)
        {

            for (int i = 0; i < asteroidsNumber; i++)
            {
                float spawnDistance = Random.Range(minSpawnDistance, maxSpawnDistance);
                Vector3 randomPos = Random.insideUnitSphere * spawnDistance;
                randomPos += transform.position;
                randomPos.y = 0f;

                Vector3 direction = randomPos - transform.position;
                direction.Normalize();

                float dotProduct = Vector3.Dot(transform.forward, direction);
                float dotProductAngle = Mathf.Acos(dotProduct / transform.forward.magnitude * direction.magnitude);

                randomPos.x = Mathf.Cos(dotProductAngle) * spawnDistance + transform.position.x;
                randomPos.y = Mathf.Sin(dotProductAngle * (Random.value > 0.5f ? 1f : -1f)) * spawnDistance + transform.position.y;
                randomPos.z = transform.position.z;

                //Vector2 pos = Random.insideUnitCircle * 10;
                GameObject aster = _pooling.UseObject(asteroid, randomPos, transform.rotation);
                totalAsteroids.Add(aster);
                n--;
            }

            if (n > 0)
                StartCoroutine(SpawnAsteroids(n, asteroid));

            yield return null;
        }

        public void AsteroidHit(GameObject aster)
        {
            totalAsteroids.Remove(aster);

            if (totalAsteroids.Count == 0)
                LevelComplete();
        }

        public void LevelComplete()
        {
            int totalLevels = levels.Length;

            if (CurrentLevel < totalLevels)
            {
                CurrentLevel += 1;
                manager.UIGameplay.UIGameInfo.AddLevel(1);
                StartLevel();
                return;
            }

            if (totalLevels >= CurrentLevel)
            {
                manager.GameOver();
            }
        }
    }
}