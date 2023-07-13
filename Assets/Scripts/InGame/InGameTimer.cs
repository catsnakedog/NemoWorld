using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class InGameTimer : MonoBehaviour
{
    TMP_Text time;
    StringBuilder sb;

    void Start()
    {
        sb = new StringBuilder();
        time = gameObject.transform.GetChild(0).GetComponent<TMP_Text>();
        StartCoroutine(Timer());
    }

    void Update()
    {
        sb.Clear();
        string temp1 = System.Math.Truncate(DataManager.Single.Data.inGameData.crruentQuest.time / 60f).ToString();
        string temp2 = (DataManager.Single.Data.inGameData.crruentQuest.time % 60).ToString();
        sb.Append(temp1);
        sb.Append(" : ");
        sb.Append(temp2);
        time.text = sb.ToString();
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        if(DataManager.Single.Data.inGameData.crruentQuest.time > 0)
        {
            DataManager.Single.Data.inGameData.crruentQuest.time--;
        }
        StartCoroutine(Timer());
    }
}
