using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Slider slider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        slider.value = Manager.Audio.bgmVolume;
    }

    public void Open()
    {
        anim.SetTrigger("In");
    }

    public void Close()
    {
        if(gameObject.activeSelf)
            anim.SetTrigger("Out");
    }

    public void SetFalse() => gameObject.SetActive(false);

    public void BgmVolume(float volume)
    {
        Manager.Audio.bgmVolume = volume;
        Manager.Audio.UpdateVolume();
    }
}
