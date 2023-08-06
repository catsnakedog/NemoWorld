using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data;

public class EnergyUI : MonoBehaviour
{
    DateTime beforeTime;
    Coroutine timer;
    TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TMP_Text>();

        beforeTime = Convert.ToDateTime(DataManager.Single.Data.timeData.beforeTime);

        if(!(DataManager.Single.Data.inGameData.cost.energy >= 15))
        {
            timer = StartCoroutine(Timer());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator Timer()
    {
        DateTime now = DateTime.Now;


        if(DataManager.Single.Data.inGameData.cost.energy >= 15)
        {
            gameObject.SetActive(false);
            StopCoroutine(timer);
        }
        if((now - beforeTime).TotalSeconds >= 300)
        {
            beforeTime = now;
            DataManager.Single.Data.inGameData.cost.energy++;

            if(DataManager.Single.Data.inGameData.cost.energy >= 15)
            {
                gameObject.SetActive(false);
            }

            DataManager.Single.Save();
        }

        TimeSpan temp = new TimeSpan(0, 5, 0);

        string format = @"mm\:ss";
        text.text = (temp - (now - beforeTime)).ToString(format);


        yield return new WaitForSeconds(1f);
        StartCoroutine(Timer());
    }
}
