using Gameplay.Obstacles;
using Gameplay.Pool;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPool : MonoBehaviour
{
    [SerializeField] private PoolManager _pool;

    [SerializeField] private GameObject asteroidBig;
    [SerializeField] private GameObject asteroidMiddle;
    [SerializeField] private GameObject asteroidSmall;

    private void Start()
    {

    }
    void OnGUI()
    {

        if (GUI.Button(new Rect(10, 10, 50, 50), "Spawn Drones"))
        _pool.UseObject(asteroidBig, _pool.transform.position,_pool.transform.rotation);

    }


}
