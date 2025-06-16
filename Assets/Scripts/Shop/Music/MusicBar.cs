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
    private MusicData musicData;

    public void SetMusicBar(MusicData data)
    {
        musicData = data;

        musicName.text = data.musicName;
        musicIcon.sprite = data.icon;
        lockImage.gameObject.SetActive(!data.isUnlocked);
    }

    public void StartMusic()
    {
        if(musicData.isUnlocked)
        {
            Manager.Audio.PlayBGM(musicData.bgm);
            Manager.Audio.PlaySFX(SFX.Select);
        }
        else
        {
            Manager.UI.PopupStart("���� �����Ͻðڽ��ϱ�?", Buy);                
        }
    }

    private void Buy()
    {
        if (Manager.Data.RemoveGold(1000))
        {
            musicData.isUnlocked = true;
            lockImage.gameObject.SetActive(false);
        }
        else
            Manager.UI.PopUpStringStart("���� �����մϴ�.");
    }
}
