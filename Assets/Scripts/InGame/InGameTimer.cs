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
    Coroutine effect;

    void Start()
    {
        DataManager.Single.Data.inGameData.isTimeUp = false;
        DataManager.Single.Data.inGameData.isTimeDown = false;
        sb = new StringBuilder();
        time = gameObject.transform.GetChild(0).GetComponent<TMP_Text>();
        StartCoroutine(Timer());
    }

    void Update()
    {
        if(DataManager.Single.Data.inGameData.isTimeUp)
        {
            if(effect != null)
            {
                StopCoroutine(effect);
            }
            time.color = Color.black;
            gameObject.transform.localPosition = new Vector3(0, 440, 0);
            effect = StartCoroutine(TimeUpEffect());
            DataManager.Single.Data.inGameData.isTimeUp = false;
        }
        if (DataManager.Single.Data.inGameData.isTimeDown)
        {
            if (effect != null)
            {
                StopCoroutine(effect);
            }
            time.color = Color.black;
            gameObject.transform.localPosition = new Vector3(0, 440, 0);
            effect = StartCoroutine(TimeDownEffect());
            DataManager.Single.Data.inGameData.isTimeDown = false;
        }
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

    IEnumerator TimeDownEffect()
    {
        time.color = Color.red;
        gameObject.transform.localPosition = new Vector3(-5, 440, 0);
        yield return new WaitForSeconds(0.05f);
        gameObject.transform.localPosition = new Vector3(5, 440, 0);
        yield return new WaitForSeconds(0.05f);
        gameObject.transform.localPosition = new Vector3(0, 440, 0);
        yield return new WaitForSeconds(0.9f);
        time.color = Color.black;
    }

    IEnumerator TimeUpEffect()
    {
        time.color = Color.blue;
        gameObject.transform.localPosition = new Vector3(-5, 440, 0);
        yield return new WaitForSeconds(0.05f);
        gameObject.transform.localPosition = new Vector3(5, 440, 0);
        yield return new WaitForSeconds(0.05f);
        gameObject.transform.localPosition = new Vector3(0, 440, 0);
        yield return new WaitForSeconds(0.9f);
        time.color = Color.black;
    }
}
