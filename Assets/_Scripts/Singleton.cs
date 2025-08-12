using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        private static readonly object _lock = new object();
        private static bool _applicationIsQuitting;

        [SerializeField] bool isSingletonGlobal = true;

        public static T Instance
        {
            get
            {
                if (_applicationIsQuitting)
                {
                    Debug.LogWarning($"[Singleton] Instance of {typeof(T).Name} already destroyed. Returning null.");
                    return null;
                }

                lock (_lock)
                {
                    if (!_instance)
                    {
                        _instance = FindFirstObjectByType<T>();

                        if (!_instance)
                        {
                            GameObject singletonObject = new GameObject();
                            _instance = singletonObject.AddComponent<T>();
                            singletonObject.name = $"[Singleton] {typeof(T).Name}";

                            DontDestroyOnLoad(singletonObject);

                            Debug.Log($"[Singleton] Created new instance of {typeof(T).Name}.");
                        }
                        else
                        {
                            Debug.Log($"[Singleton] Found existing instance of {typeof(T).Name}.");
                        }
                    }

                    return _instance;
                }
            }
        }

        private void Awake()
        {
            if (!_instance)
            {
                _instance = this as T;
                if (isSingletonGlobal)
                    DontDestroyOnLoad(gameObject);
            }
            else if (_instance != this)
            {
                Debug.LogWarning(
                    $"[Singleton] Another instance of {typeof(T).Name} already exists. Destroying this duplicate.");
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            if (_instance == this)
            {
                _applicationIsQuitting = true;
            }
        }
    }
}