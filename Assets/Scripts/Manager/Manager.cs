using FMOD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Manager instance;

    private static DataManager dataManager;
    private static AudioManager audioManager;
    private static UI_Manager uiManager;
    #region Managers
    public static DataManager Data { get { return dataManager; } }
    public static AudioManager Audio { get { return audioManager; } }
    public static UI_Manager UI { get { return uiManager; } }
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
        instance.transform.parent = transform;
        return instance;
    }

    private void CreateManagers()
    {
        dataManager = CreateMonoManager<DataManager>();
        audioManager = CreateMonoManager<AudioManager>();
        uiManager = CreateMonoManager<UI_Manager>();
    }
}
