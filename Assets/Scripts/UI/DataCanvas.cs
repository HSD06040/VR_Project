using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataCanvas : MonoBehaviour
{
    [SerializeField] private TMP_Text goldText;
    [SerializeField] private TMP_Text fameText;

    private void OnEnable()
    {
        goldText.text = Manager.Data.Gold.Value.ToString();
        fameText.text = Manager.Data.GetFamusKorean();
        Manager.Data.Gold.AddEvent((int a) => goldText.text = a.ToString());
        Manager.Data.OnFameLevelChanged += ((string s) => fameText.text = s);
    }
}
