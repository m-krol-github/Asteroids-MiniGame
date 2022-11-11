using Gameplay.Pool;

using System.Collections;
using UnityEngine;

namespace Gameplay.Obstacles
{
    public sealed class AsteroidsManager : MonoBehaviour
    {
        [SerializeField] private PoolManager _pooling;
        [SerializeField] private AsteroidsTypes _types;

        public float spawnDistance = 12f;

        [SerializeField] private int minNumber;
        [SerializeField] private int maxNumber;

        private void Start()
        {
            SpawnAsteroids();
        }

        public void SpawnAsteroids()
        {
            int spawnNumber = Random.Range(minNumber, maxNumber);
            StartCoroutine(SpawnAsteroids(spawnNumber));
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
    }
}