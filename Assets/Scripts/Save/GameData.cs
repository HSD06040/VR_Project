using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class GameData
{

    public float masterVolume;
    public float bgmVolume;
    public float sfxVolume;

    public GameData()
    {
        masterVolume = 1;
        bgmVolume = 1;
        sfxVolume = 1;
    }
}
