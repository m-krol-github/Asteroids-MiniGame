using UnityEngine;

namespace Gameplay.Pool
{
    [System.Serializable]
    public sealed class PoolItem 
    {
        public GameObject poolItem;
        public string itemName;
        public int poolAmount;
        public bool growable;
    }
}