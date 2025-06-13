using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupString : MonoBehaviour
{
    [SerializeField] private TMP_Text message;
    [SerializeField] private Animator anim;

    public void SetupText(string text)
    {
        anim.SetTrigger("In");
        message.text = text;
    }

    public void SetFalse() => gameObject.SetActive(false);
}
