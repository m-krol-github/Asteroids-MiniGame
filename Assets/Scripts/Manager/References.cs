using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    [System.Serializable]
    public class References 
    {
        [field: SerializeField] public Camera GameCamera { get; private set; }
    }
}