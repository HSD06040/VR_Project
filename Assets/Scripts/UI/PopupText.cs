using EnumType;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PopupText : MonoBehaviour
{
    [SerializeField] private TMP_Text popupText;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();   
    }

    public void SetupPopUp(string text, UnityAction yes, UnityAction no = null)
    {
        anim.SetTrigger("In");

        popupText.text = text;
        yesButton.onClick.AddListener(yes);
        yesButton.onClick.AddListener(ClosePopup);
        yesButton.onClick.AddListener(PlaySFX);

        if(no != null)
        {
            noButton.onClick.AddListener(no);
            noButton.onClick.AddListener(ClosePopup);
            noButton.onClick.AddListener(PlaySFX);
        }
        else
            noButton.onClick.AddListener(ClosePopup);
    }

    private void PlaySFX() => Manager.Audio.PlaySFX(SFX.Select);

    private void OnDisable()
    {
        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();
    }

    private void ClosePopup()
    {
        anim.SetTrigger("Out");        
    }

    public void SetActivateFalse() => gameObject.SetActive(false);
}
