using UnityEngine;

public abstract class Singleton<T>: MonoBehaviour where T: MonoBehaviour
{
    public static T Instance = null;

    protected virtual void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
        {
            Instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
    }
}
