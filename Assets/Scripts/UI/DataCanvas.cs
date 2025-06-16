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
        Manager.OnCreateManager += AddGoldEvent;
        Manager.OnCreateManager += AddFameEvent;
    }

    private void AddFameEvent()
    {
        Manager.Data.OnFameLevelChanged += ((string s) => fameText.text = s);
        fameText.text = Manager.Data.GetFamusKorean();
    }

    private void AddGoldEvent()
    {        
        Manager.Data.Gold.AddEvent((int a) => goldText.text = a.ToString());
        goldText.text = Manager.Data.Gold.Value.ToString();
    }
}
