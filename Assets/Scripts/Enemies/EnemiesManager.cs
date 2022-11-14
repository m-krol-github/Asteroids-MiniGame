using Gameplay.Pool;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] private Transform spawnBonusPosition;

    [SerializeField] private GameObject bonusEnemy;

    private void Start()
    {
        var timer = Random.Range(5, 10);
        StartCoroutine(SpawnBonusEnemy(timer));
    }

    private IEnumerator SpawnBonusEnemy(float t)
    {
        yield return new WaitForSeconds(t);
        PoolManager.Instance.UseObject(bonusEnemy, spawnBonusPosition.position, transform.rotation);


        var timeToSpawn = Random.Range(15, 40);
        StartCoroutine(SpawnBonusEnemy(timeToSpawn));
    }
}
