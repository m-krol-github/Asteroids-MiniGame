using Gameplay.Pool;

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Gameplay.Obstacles
{
    public sealed class LevelsManager : MonoBehaviour
    {
        public int CurrentLevel { get; set; }

        public float spawnDistance = 12f;

        [SerializeField] private LevelsAsset[] levels;

        [SerializeField] private PoolManager _pooling;
        [SerializeField] private AsteroidsTypes _types;


        private int minNumber;
        private int maxNumber;

        private int astLargeNumber;
        private int astMediumNumber;
        private int astSmallNumber;

        private GameManager manager;

        private List<GameObject> totalAsteroids = new();

        public void Init(GameManager manager)
        {
            this.manager = manager;

            this.astLargeNumber = levels[CurrentLevel].astLargeNumber;
            this.astMediumNumber = levels[CurrentLevel].mediumAsteroidsNumber;
            this.astSmallNumber = levels[CurrentLevel].smallAsteroidsNumber;

            StartCoroutine( SpawnAsteroids(20));
        }

        public void SpawnAsteroids()
        {
            Vector2 spawnDirection = Random.insideUnitCircle.normalized;
            Vector3 spawnPoint = spawnDirection * spawnDistance;

            spawnPoint += transform.position;

            GameObject aster = null;

            for (int i = 0; i < astSmallNumber; i++)
            {
                aster = _pooling.UseObject(_types.asteroids[0].gameObject, spawnPoint, transform.rotation);
            }

            for (int i = 0; i < astMediumNumber; i++)
            {
                aster = _pooling.UseObject(_types.asteroids[1].gameObject, spawnPoint, transform.rotation);
            }

            for (int i = 0; i < astLargeNumber; i++)
            {
                aster = _pooling.UseObject(_types.asteroids[2].gameObject, spawnPoint, transform.rotation);
            }

            totalAsteroids.Add(aster);
        }

        private IEnumerator SpawnAsteroids(int n)
        {
            Vector2 spawnDirection = Random.insideUnitCircle.normalized;
            Vector3 spawnPoint = spawnDirection * spawnDistance;

            // Offset the spawn point by the position of the spawner so its
            // relative to the spawner location
            spawnPoint += transform.position;

            for (int i = 0; i < _types.asteroids.Length; i++)
            {
                //Vector2 pos = Random.insideUnitCircle * 10;
                _pooling.UseObject(_types.asteroids[i].gameObject, spawnPoint, transform.rotation);
                n--;
            }

            if (n > 0)
                StartCoroutine(SpawnAsteroids(n));

            yield return null;
        }

        public void AsteroidHit(GameObject aster)
        {
            totalAsteroids.Remove(aster);
        }

        public void LevelComplete()
        {
            int totalLevels = levels.Length;
            totalAsteroids.Clear();

            if (totalLevels < CurrentLevel)
            {
                CurrentLevel += 1;
                manager.UIGameplay.UIGameInfo.AddLevel(1);
                return;
            }

            if (totalLevels >= CurrentLevel)
            {
                manager.GameOver();
            }
        }
    }
}