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
            transform.GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = "È¹µæ °ñµå (º¸³Ê½º Ãß°¡!)";
            transform.GetChild(3).GetChild(1).GetComponent<TMP_Text>().text = sb.ToString();
            if (DataManager.Single.Data.inGameData.coinGetAmount * DataManager.Single.Data.inGameData.inGameItem.goldIncreaseAmount < 10)
            {
                sb.Clear();
                sb.Append("0");
                sb.Append(DataManager.Single.Data.inGameData.coinGetAmount * DataManager.Single.Data.inGameData.inGameItem.goldIncreaseAmount);
            }
            else
            {
                sb.Clear();
                sb.Append(DataManager.Single.Data.inGameData.coinGetAmount * DataManager.Single.Data.inGameData.inGameItem.goldIncreaseAmount);
            }
            transform.GetChild(3).GetChild(2).GetComponent<TMP_Text>().text = sb.ToString();
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
            transform.GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = "È¹µæ °ñµå";
            transform.GetChild(3).GetChild(1).GetComponent<TMP_Text>().text = sb.ToString();
        }

        if (DataManager.Single.Data.inGameData.result == "die")
        {
            transform.GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.sprite["BG1_1"];
            transform.GetChild(1).GetComponent<Image>().sprite = MainController.main.resource.sprite["diePlayer"];
            transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
        }
        else if (DataManager.Single.Data.inGameData.result == "clear")
        {
            transform.GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.sprite["BG1_4"];
            transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).GetComponent<Image>().sprite = MainController.main.resource.sprite["clearPlayer"];
            if(DataManager.Single.Data.inGameData.crruentQuest.gameMode == "hard")
            {
                transform.GetChild(4).gameObject.SetActive(true);
            }
        }
    }
}