using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] private MusicShop musicShop;


    public void MusicShop()
    {
        if(!musicShop.gameObject.activeSelf)
        {
            musicShop.gameObject.SetActive(true);
            musicShop.OpenMusicShop();
        }
        else
            musicShop.CloseMusicShop();
    }    
}
