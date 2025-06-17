using EnumType;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "M", menuName = "Data/MusicData")]
[Serializable]
public class MusicData : ScriptableObject
{
    public Sprite icon;
    public string musicName;
    public bool isUnlocked;
    public BGM bgm;
}
