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

        musicName.text = data.name;
        musicIcon.sprite = data.icon;
        lockImage.gameObject.SetActive(!data.isUnlocked);
    }

    public void StartMusic()
    {
        if(musicData.isUnlocked)
        {
            Manager.Audio.PlayBGM(musicData.bgm);
        }
        else
        {
            Manager.UI.PopupStart("정말 구매하시겠습니까?", Buy);                
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
            Debug.Log("돈이 부족합니다.");
    }
}
