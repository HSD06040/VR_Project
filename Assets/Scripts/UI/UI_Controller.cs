using EnumType;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] private MusicShop musicShop;
    [SerializeField] private Setting setting;
    [SerializeField] private Menu menu;

    public void Menu()
    {
        if (!menu.gameObject.activeSelf)
        {
            menu.gameObject.SetActive(true);
            menu.Open();
            Manager.Audio.PlaySFX(SFX.Open);
        }
        else
        {
            menu.Close();
            setting.Close();
            musicShop.Close();
            Manager.Audio.PlaySFX(SFX.Close);
        }
    }

    public void Setting()
    {
        if (!setting.gameObject.activeSelf)
        {
            setting.gameObject.SetActive(true);
            setting.Open();
            Manager.Audio.PlaySFX(SFX.Open);
        }
        else
        {
            setting.Close();
            Manager.Audio.PlaySFX(SFX.Close);
        }
    }

    public void MusicShop()
    {
        if (!musicShop.gameObject.activeSelf)
        {
            musicShop.gameObject.SetActive(true);
            musicShop.Open();
            Manager.Audio.PlaySFX(SFX.Open);
        }
        else
        {
            musicShop.Close();
            Manager.Audio.PlaySFX(SFX.Close);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
