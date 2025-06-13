using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_Manager : MonoBehaviour
{
    public PopupText Popup;
    public PopupString PopupString;

    private void Start()
    {
        Popup = FindObjectOfType<PopupText>(true);
        PopupString = FindObjectOfType<PopupString>(true);
    }

    public void PopupStart(string text, UnityAction yes, UnityAction no = null)
    {
        Popup.gameObject.SetActive(true);
        Popup.SetupPopUp(text, yes, no);

    }

    public void PopUpStringStart(string text)
    {
        PopupString.gameObject.SetActive(true);
        PopupString.SetupText(text);
    }
}
