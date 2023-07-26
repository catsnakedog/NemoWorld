using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerRank : MonoBehaviour
{
    void Start()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = DataManager.Single.Data.rankingData.rank.ToString();
        transform.GetChild(1).GetComponent<TMP_Text>().text = DataManager.Single.Data.rankingData.playerRank.name;
        transform.GetChild(2).GetComponent<TMP_Text>().text = DataManager.Single.Data.rankingData.playerRank.score;
    }
}
