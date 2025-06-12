using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicShop : MonoBehaviour
{
    [SerializeField] private Transform musicBarParent;
    [SerializeField] private GameObject musicBarPrefab;
    private MusicData[] musicDatas;
    
    private void Start()
    {
        musicDatas = Manager.Data.musicDatas;

        for (int i = 0; i < musicDatas.Length; i++)
        {
            MusicBar musicBar = Instantiate(musicBarPrefab, musicBarParent).GetComponent<MusicBar>();
            musicBar.SetMusicBar(musicDatas[i]);
        }
    }
}
