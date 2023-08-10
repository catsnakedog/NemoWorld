using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;
using System;
using UnityEngine.Networking;
using JetBrains.Annotations;

public class GameResultText : MonoBehaviour
{
    void Start()
    {
        DataManager.Single.Data.inGameData.inGameItem.goldIncreaseAmount = 0.4f;

        if(DataManager.Single.Data.inGameData.itemList.IsLegendSkinSetComplete())
        {
            DataManager.Single.Data.inGameData.inGameItem.goldIncreaseAmount += 0.05f;
        }
        if (DataManager.Single.Data.inGameData.itemList.IsCommonSkinSetComplete())
        {
            DataManager.Single.Data.inGameData.inGameItem.goldIncreaseAmount += 0.05f;
        }

        StringBuilder sb = new StringBuilder();
        if (DataManager.Single.Data.inGameData.inGameItem.coinItem)
        {
            if(DataManager.Single.Data.inGameData.coinGetAmount < 10)
            {
                sb.Append("0");
                sb.Append(DataManager.Single.Data.inGameData.coinGetAmount);
            }
            else
            {
                sb.Append(DataManager.Single.Data.inGameData.coinGetAmount);
            }
            transform.GetChild(4).GetChild(0).GetComponent<TMP_Text>().text = "È¹µæ °ñµå (º¸³Ê½º Ãß°¡!)";
            transform.GetChild(4).GetChild(1).GetComponent<TMP_Text>().text = sb.ToString();

            if (DataManager.Single.Data.inGameData.coinGetAmount * DataManager.Single.Data.inGameData.inGameItem.goldIncreaseAmount < 10)
            {
                sb.Clear();
                sb.Append("0");
                sb.Append((int)(DataManager.Single.Data.inGameData.coinGetAmount * DataManager.Single.Data.inGameData.inGameItem.goldIncreaseAmount));
            }
            else
            {
                sb.Clear();
                sb.Append((int)(DataManager.Single.Data.inGameData.coinGetAmount * DataManager.Single.Data.inGameData.inGameItem.goldIncreaseAmount));
            }
            transform.GetChild(4).GetChild(2).GetComponent<TMP_Text>().text = sb.ToString();
        }
        else
        {
            if (DataManager.Single.Data.inGameData.coinGetAmount < 10)
            {
                sb.Append("0");
                sb.Append(DataManager.Single.Data.inGameData.coinGetAmount);
            }
            else
            {
                sb.Append(DataManager.Single.Data.inGameData.coinGetAmount);
            }
            transform.GetChild(4).GetChild(0).GetComponent<TMP_Text>().text = "È¹µæ °ñµå";
            transform.GetChild(4).GetChild(1).GetComponent<TMP_Text>().text = sb.ToString();
        }



        if (DataManager.Single.Data.inGameData.result == "die")
        {
            transform.GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.sprite["BG1_1"];
            transform.GetChild(1).GetComponent<Image>().sprite = MainController.main.resource.sprite["diePlayer"];
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(true);
            if (DataManager.Single.Data.inGameData.crruentQuest.gameMode == "rank")
            {
                transform.GetChild(9).gameObject.SetActive(true);
                transform.GetChild(6).gameObject.SetActive(true);
                DataManager.Single.Data.inGameData.score = ((int)(DataManager.Single.Data.inGameData.moveAmount * 300));
                transform.GetChild(6).GetChild(1).GetComponent<TMP_Text>().text = DataManager.Single.Data.inGameData.score.ToString();
                RankingData();
            }
        }
        else if (DataManager.Single.Data.inGameData.result == "clear")
        {
            transform.GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.sprite["BG1_4"];
            transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(1).GetComponent<Image>().sprite = MainController.main.resource.sprite["clearPlayer"];
            if(DataManager.Single.Data.inGameData.crruentQuest.gameMode == "hard")
            {
                if(UnityEngine.Random.Range(0,10) < 3)
                {
                    transform.GetChild(5).gameObject.SetActive(true);
                    switch (DataManager.Single.Data.inGameData.stage)
                    {
                        case 1:
                            transform.GetChild(5).GetChild(1).GetComponent<Image>().sprite = MainController.main.resource.sprite[Define.SpriteDict.HeadTicket.ToString()];
                            DataManager.Single.Data.inGameData.cost.headTicket++;
                            break;
                        case 2:
                            transform.GetChild(5).GetChild(1).GetComponent<Image>().sprite = MainController.main.resource.sprite[Define.SpriteDict.ClothTicket.ToString()];
                            DataManager.Single.Data.inGameData.cost.clothTicket++;
                            break;
                        case 3:
                            transform.GetChild(5).GetChild(1).GetComponent<Image>().sprite = MainController.main.resource.sprite[Define.SpriteDict.WingTicket.ToString()];
                            DataManager.Single.Data.inGameData.cost.wingTicket++;
                            break;
                    }
                }
            }
            if (DataManager.Single.Data.inGameData.crruentQuest.gameMode == "rank")
            {
                transform.GetChild(9).gameObject.SetActive(true);
                transform.GetChild(6).gameObject.SetActive(true);
                DataManager.Single.Data.inGameData.score = ((int)(DataManager.Single.Data.inGameData.moveAmount * 300 + DataManager.Single.Data.inGameData.crruentQuest.time * 1000));
                transform.GetChild(6).GetChild(1).GetComponent<TMP_Text>().text = DataManager.Single.Data.inGameData.score.ToString();
                RankingData();
            }
        }
    }

    void RankingData()
    {
        StartCoroutine(DataPost());
    }

    const string URL = "https://script.google.com/macros/s/AKfycbzD6pKj5-JGVICcb4Jkl39AzsJkjyhxYZ2-SKk__8G5RDpS6xUpna0tBm1tYQ4MFHo/exec";

    IEnumerator DataPost()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", DataManager.Single.Data.inGameData.name);
        form.AddField("type", "rankData");
        form.AddField("score", DataManager.Single.Data.inGameData.score.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.isDone) DataProcessing(www.downloadHandler.text);
            else StartCoroutine(DataPost());
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

        for (int i = 0; i < DataManager.Single.Data.rankingData.rankInfo.Count; i++)
        {
            if (DataManager.Single.Data.rankingData.rankInfo[i].name == DataManager.Single.Data.inGameData.name)
            {
                DataManager.Single.Data.rankingData.playerRank = DataManager.Single.Data.rankingData.rankInfo[i];
                DataManager.Single.Data.rankingData.rank = i + 1;
            }

        }

        DataManager.Single.Save();
        transform.GetChild(9).gameObject.SetActive(false);
    }

    int compare1(RankInfo a, RankInfo b)
    {
        return int.Parse(a.score) <= int.Parse(b.score) ? 1 : -1;
    }
}