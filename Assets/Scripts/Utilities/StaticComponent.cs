using UnityEngine;
// generic class to use as singleton
// call StaticComponent<YourType>.Instance.YourMethod()
public static class StaticComponent<T> where T : Component
{
    public static readonly T Instance;

    static StaticComponent()
    {
        #if UNITY_EDITOR
            if (!UnityEditor.EditorApplication.isPlaying)
                return;
        #endif

        GameObject gameObject = new GameObject(typeof(T).Name);
        Object.DontDestroyOnLoad(gameObject);
        Instance = gameObject.AddComponent<T>();
    }
}
