using EnumType;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicBar : MonoBehaviour
{
    [SerializeField] private TMP_Text musicName;
    [SerializeField] private Image musicIcon;
    [SerializeField] private Image lockImage;    
    private BGM bgm;

    public void SetMusicBar(MusicData data)
    {
        musicName.text = data.name;
        musicIcon.sprite = data.icon;
        lockImage.gameObject.SetActive(!data.isUnlocked);
    }

    public void StartMusic()
    {
        Manager.Audio.PlayBGM(bgm);
    }
}
