using Gameplay.Pool;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Obstacles
{
    public sealed class AsteroidsManager : MonoBehaviour
    {
        [SerializeField] private PoolManager _pooling;
        [SerializeField] private AsteroidsTypes _types;

        [SerializeField] private int maxNumber;


        private void Start()
        {
            int spawnNumber = Random.Range(15, maxNumber);
            StartCoroutine(SpawnAsteroids(spawnNumber));
        }

        private IEnumerator SpawnAsteroids(int n)
        {
            for (int i = 0; i < _types.asteroids.Length; i++)
            {
                Vector2 pos = Random.insideUnitCircle * 10;
                _pooling.UseObject(_types.asteroids[i].gameObject, pos, transform.rotation);
                n--;
            }

            if (n > 0)
                StartCoroutine(SpawnAsteroids(n));

            yield return null;
        }
    }
}