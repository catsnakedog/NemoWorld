using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RankLoading : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DataGet());
    }

    const string URL = "https://script.google.com/macros/s/AKfycbzD6pKj5-JGVICcb4Jkl39AzsJkjyhxYZ2-SKk__8G5RDpS6xUpna0tBm1tYQ4MFHo/exec";

    IEnumerator DataGet()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(URL))
        {
            yield return www.SendWebRequest();

            if (www.isDone) DataProcessing(www.downloadHandler.text);
            else StartCoroutine(DataGet());
        }
    }

    void DataProcessing(string text)
    {
        string[] splitText = text.Split(',');
        DataManager.Single.Data.rankingData.rankInfo.Clear();

        for (int i = 0; i < splitText.Length / 2; i++)
        {
            RankInfo temp = new RankInfo(splitText[i * 2 + 0], splitText[i * 2 + 1]);
            DataManager.Single.Data.rankingData.rankInfo.Add(temp);
        }

        DataManager.Single.Data.rankingData.rankInfo.Sort(compare1);
        
        for(int i = 0; i < DataManager.Single.Data.rankingData.rankInfo.Count; i++)
        {
            if (DataManager.Single.Data.rankingData.rankInfo[i].name == DataManager.Single.Data.inGameData.name)
            {
                DataManager.Single.Data.rankingData.playerRank = DataManager.Single.Data.rankingData.rankInfo[i];
                DataManager.Single.Data.rankingData.rank = i + 1;
            }

        }
        if(DataManager.Single.Data.inGameData.isRankAward)
        {
            StartCoroutine(AwardCheck());
        }
        else
        {
            MainController.main.UI.UIsetting(Define.UIlevel.Level1, Define.UItype.RankingMode);
        }
    }

    int compare1(RankInfo a, RankInfo b)
    {
        return int.Parse(a.score) < int.Parse(b.score) ? 1 : -1;
    }

    IEnumerator AwardCheck()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", DataManager.Single.Data.inGameData.name);
        form.AddField("type", "awardCheck");

        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.isDone) Award(int.Parse(www.downloadHandler.text));
            else StartCoroutine(AwardCheck());
        }
    }

    void Award(int a)
    {
        if(a == 1)
        {
            DataManager.Single.Data.rankingData.awardType = 1;
        }
        else if(a == 2)
        {
            DataManager.Single.Data.rankingData.awardType = 2;
        }
        else if (a == 3)
        {
            DataManager.Single.Data.rankingData.awardType = 3;
        }
        else if (a >= 10)
        {
            DataManager.Single.Data.rankingData.awardType = 4;
        }
        else if (a >= 30)
        {
            DataManager.Single.Data.rankingData.awardType = 5;
        }
        else
        {
            DataManager.Single.Data.rankingData.awardType = 6;
        }

        MainController.main.UI.UIsetting(Define.UIlevel.Level1, Define.UItype.RankingMode);
    }
}
