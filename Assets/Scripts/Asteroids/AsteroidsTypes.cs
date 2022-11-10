using UnityEngine;

namespace Gameplay.Obstacles
{
    [CreateAssetMenu]
    public class AsteroidsTypes : ScriptableObject
    {
        public BaseAsteroid[] asteroids;

        public LargeAsteroid asteroidTypeLarge;
        public MediumAsteroid asteroidTypeMedium;
        public SmallAsteroid asteroidTypeSmall;
    }
}