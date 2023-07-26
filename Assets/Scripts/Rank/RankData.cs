using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RankData : MonoBehaviour
{
    const string URL = "https://script.google.com/macros/s/AKfycby5Ep0ycS-Ad-6lrHCXH8ql1WRORnLY7FcqmXpw3pI7PAmKuLtNj1IbjoJhvzgmiv1Q/exec";

    IEnumerator DataPost()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", DataManager.Single.Data.inGameData.name);
        form.AddField("type", "rankData");
        form.AddField("score", DataManager.Single.Data.inGameData.score);

        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.isDone) ;
            else StartCoroutine(DataPost());
        }
    }
}