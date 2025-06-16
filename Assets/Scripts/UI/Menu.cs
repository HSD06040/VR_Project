using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Open()
    {
        anim.SetTrigger("In");
    }

    public void Close()
    {
        if (gameObject.activeSelf)
            anim.SetTrigger("Out");
    }

    public void SetFalse() => gameObject.SetActive(false);
}
