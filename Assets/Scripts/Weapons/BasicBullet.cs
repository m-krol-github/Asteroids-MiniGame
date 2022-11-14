using Gameplay.Pool;
using UnityEngine;

namespace Gameplay.Weapons
{
    public sealed class BasicBullet : MonoBehaviour, IReturnToPool
    {
        [SerializeField] private float timeToDestroy = 2f;

        public void ReturnToPool(PoolManager pooling)
        {
            pooling.ReturnObject(this.gameObject, 2f);
        }

        private void OnEnable()
        {
            ReturnToPool(PoolManager.Instance);
        }
    }
}