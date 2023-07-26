using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserRank : MonoBehaviour
{
    void Start()
    {
        for(int i = 0; i < 50; i++)
        {
            if (i >= DataManager.Single.Data.rankingData.rankInfo.Count) break;
            GameObject temp = transform.GetChild(i).gameObject;
            temp.transform.GetChild(0).GetComponent<TMP_Text>().text = (i + 1).ToString();
            temp.transform.GetChild(1).GetComponent<TMP_Text>().text = DataManager.Single.Data.rankingData.rankInfo[i].name;
            temp.transform.GetChild(2).GetComponent<TMP_Text>().text = DataManager.Single.Data.rankingData.rankInfo[i].score;
        }
    }
}
