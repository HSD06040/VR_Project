using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Manager instance;

    private static PlayerData playerData;

    #region Managers
    public static PlayerData PlayerData;
    #endregion

    private void Awake() => Init();

    private void Init()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        CreateManagers();
    }

    private T CreateMonoManager<T>() where T : MonoBehaviour
    {
        T instance = new GameObject(typeof(T).Name).AddComponent<T>();
        instance.transform.SetParent(instance.transform, false);
        return instance;
    }

    private void CreateManagers()
    {
        playerData = CreateMonoManager<PlayerData>();
    }
}
