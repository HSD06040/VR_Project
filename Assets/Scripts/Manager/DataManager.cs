using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumType;
using System;

public class DataManager : MonoBehaviour, ISavable
{
    public FameLevel fameLevel;
    public Property<int> Gold { get; private set; } = new();
    public Property<int> TotalGold { get; private set; } = new();
    public Dictionary<string, bool> musicUnlockDic = new Dictionary<string, bool>();
    public MusicData[] musicDatas;

    public event Action<string> OnFameLevelChanged;

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

        OnFameLevelChanged(GetFamusKorean());
    }

    public string GetFamusKorean()
    {
        return (fameLevel) switch
        {
            FameLevel.Unknown => "무 명",
            FameLevel.Normal => "일 반",
            FameLevel.Recognized => "알려짐",
            FameLevel.Popular => "유 명",
            FameLevel.Celebrity => "셀 럽",
            FameLevel.Legendary => "역사에 남을",
            _ => "없음"
        };
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
