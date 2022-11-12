using UnityEngine;

namespace Gameplay.Obstacles
{
    [CreateAssetMenu]
    public class AsteroidsTypes : ScriptableObject
    {
        public BaseAsteroid[] asteroids;

        public GameObject asteroidTypeLarge;
        public GameObject asteroidTypeMedium;
        public GameObject asteroidTypeSmall;
    }
}