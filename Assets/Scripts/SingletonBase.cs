using UnityEngine;

public abstract class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    /// <summary>
    /// Awake
    /// </summary>
    protected virtual void Awake()
    {
        if (Instance == null || Instance is null)
        {
            Instance = GetComponent<T>();
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
