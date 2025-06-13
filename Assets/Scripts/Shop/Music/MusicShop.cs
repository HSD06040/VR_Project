using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicShop : MonoBehaviour
{
    [SerializeField] private Transform musicBarParent;
    [SerializeField] private GameObject musicBarPrefab;
    [SerializeField] private Animator anim;
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

    public void OpenMusicShop()
    {
        anim.SetTrigger("In");
    }
    public void CloseMusicShop()
    {
        anim.SetTrigger("Out");
    }
    public void SetFalse() => gameObject.SetActive(false);
}
