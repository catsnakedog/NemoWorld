using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class GameResultText : MonoBehaviour
{
    void Start()
    {
        StringBuilder sb = new StringBuilder("È¹µæ °ñµå\n");

        if (DataManager.Single.Data.inGameData.inGameItem.coinItem)
        {
            sb.Append(DataManager.Single.Data.inGameData.coinGetAmount);
            sb.Append(" + ");
            sb.Append((int)(DataManager.Single.Data.inGameData.coinGetAmount * DataManager.Single.Data.inGameData.inGameItem.goldIncreaseAmount));
            transform.GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = sb.ToString();
        }
        else
        {
            sb.Append(DataManager.Single.Data.inGameData.coinGetAmount);
            transform.GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = sb.ToString();
        }

        if (DataManager.Single.Data.inGameData.result == "die")
        {
            transform.GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.sprite["diePlayer"];
            transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = "FAIL";
        }
        else if (DataManager.Single.Data.inGameData.result == "clear")
        {
            transform.GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.sprite["clearPlayer"];
            transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = "SUCCESS";
        }
    }
}