using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct TutorialInfo
{
    public Sprite icon;
    public string messsage;
}

public class Tutorial : MonoBehaviour
{
    [SerializeField] private TMP_Text tutoText;
    [SerializeField] private Image tutoIcon;

    [SerializeField] private TutorialInfo[] tuto;

    private Animator anim;

    private int curIdx;

    private void Awake()
    {
        StartCoroutine(TutoRoutine());
    }

    private IEnumerator TutoRoutine()
    {
        yield return new WaitForSeconds(1);

        anim = GetComponent<Animator>();

        if (Manager.Data.isFirstPlaying)
            StartTutorial();
        else
            Destroy(gameObject);
    }

    private void StartTutorial()
    {
        if (tuto.Length <= curIdx)
        {
            Manager.Data.isFirstPlaying = false;
            Destroy(gameObject);
            return;
        }

        tutoText.text = tuto[curIdx].messsage;
        tutoIcon.sprite = tuto[curIdx].icon;
        anim.SetTrigger("In");
    }

    public void ClearTutorial(int idx)
    {
        if (curIdx != idx) return;

        curIdx++;

        StartTutorial();
    }
}
