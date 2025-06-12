using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

[Serializable]
public class MusicData : ScriptableObject
{
    public Sprite icon;
    public string musicName;
    public bool isUnlocked;
    public AudioSource audioSource;
}
