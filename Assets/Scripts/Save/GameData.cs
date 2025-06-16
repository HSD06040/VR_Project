using EnumType;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class GameData
{
    public SerializableDictionary<string, bool> musicUnlockDic;

    public FameLevel fameLevel;

    public int gold;
    public int totalGold;

    public float masterVolume;
    public float bgmVolume;
    public float sfxVolume;

    public GameData()
    {
        musicUnlockDic = new SerializableDictionary<string, bool>();
        masterVolume = 1;
        bgmVolume = 1;
        sfxVolume = 1;
        fameLevel = FameLevel.Unknown;
        gold = 1000;
        totalGold = 0;
    }
}
