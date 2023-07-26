using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RankAwardCheck : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DataPost());
    }

    const string URL = "https://script.google.com/macros/s/AKfycbzD6pKj5-JGVICcb4Jkl39AzsJkjyhxYZ2-SKk__8G5RDpS6xUpna0tBm1tYQ4MFHo/exec";

    IEnumerator DataPost()
    {
        WWWForm form = new WWWForm();
        form.AddField("type", "weekCheck");

        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.isDone) CheckWeek(www.downloadHandler.text);
            else StartCoroutine(DataPost());
        }
    }

    void CheckWeek(string text)
    {
        if(DataManager.Single.Data.timeData.lastWeek < int.Parse(text))
        {
            DataManager.Single.Data.inGameData.isRankAward = true;
        }
        else
        {
            DataManager.Single.Data.inGameData.isRankAward = false;
        }

        DataManager.Single.Data.timeData.lastWeek = int.Parse(text);
    }
}