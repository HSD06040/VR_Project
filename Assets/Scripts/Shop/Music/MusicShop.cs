using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicShop : MonoBehaviour
{
    [SerializeField] private Transform musicBarParent;
    [SerializeField] private GameObject musicBarPrefab;
    [SerializeField] private MusicData[] musicDatas;
    
    private void Awake()
    {
        for (int i = 0; i < musicDatas.Length; i++)
        {
            MusicBar musicBar = Instantiate(musicBarPrefab, musicBarParent).GetComponent<MusicBar>();
            musicBar.SetMusicBar(musicDatas[i]);
        }
    }
}
