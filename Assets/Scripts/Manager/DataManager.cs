using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumType;

public class DataManager : MonoBehaviour, ISavable
{
    public FameLevel fameLevel;
    public Property<int> Gold { get; private set; } = new();
    public Property<int> TotalGold { get; private set; } = new();
    public Dictionary<string, bool> musicUnlockDic = new Dictionary<string, bool>();
    public MusicData[] musicDatas;

    private void Awake()
    {
        musicDatas = Resources.LoadAll<MusicData>("Data");
        musicDatas[0].isUnlocked = true;
    }

    public void AddGold(int amount)
    {
        Gold.Value += amount;
        TotalGold.Value += amount;
    }
    
    public bool RemoveGold(int amount)
    {
        if (amount <= Gold.Value)
        {
            Gold.Value -= amount;
            return true;
        }
        else
            return false;
    }

    private void TryFameLevelUp()
    {
        if (fameLevel == FameLevel.Legendary) return;

        int totalGold = TotalGold.Value;

        switch (fameLevel)
        {
            case FameLevel.Unknown:
                if (totalGold >= 5000)
                    fameLevel = FameLevel.Normal;
                break;
            case FameLevel.Normal:
                if (totalGold >= 10000)
                    fameLevel = FameLevel.Recognized;
                break;

            case FameLevel.Recognized:
                if (totalGold >= 20000)
                    fameLevel = FameLevel.Popular;
                break;

            case FameLevel.Popular:
                if (totalGold >= 50000)
                    fameLevel = FameLevel.Celebrity;
                break;

            case FameLevel.Celebrity:
                if (totalGold >= 100000)
                    fameLevel = FameLevel.Legendary;
                break;
        }
    }

    public void Save(ref GameData data)
    {        
        for (int i = 0; i < musicDatas.Length; i++)
        {
            data.musicUnlocks[i] = musicDatas[i].isUnlocked;
        }
    }

    public void Load(GameData data)
    {
        data.musicUnlocks = new bool[musicDatas.Length];

        for (int i = 0; i < musicDatas.Length; i++)
        {
            musicDatas[i].isUnlocked = data.musicUnlocks[i];
        }
    }
}
