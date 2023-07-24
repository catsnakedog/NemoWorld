using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    void Start()
    {
        DataManager.Single.Data.inGameData.inGameItem.isUseShieldItem = false;
        DataManager.Single.Data.inGameData.inGameItem.isUseSaveItem = false;
        DataManager.Single.Data.inGameData.inGameItem.isUseCoinItem = false;
        DataManager.Single.Data.inGameData.inGameItem.isUseTimeItem = false;
        DataManager.Single.Data.inGameData.inGameItem.isUseBoostItem = false;

        transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = DataManager.Single.Data.inGameData.inGameItem.coinItemAmount.ToString();
        transform.GetChild(0).GetChild(3).GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = DataManager.Single.Data.inGameData.inGameItem.coinItemAmount.ToString();
        transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = DataManager.Single.Data.inGameData.inGameItem.timeItemAmount.ToString();
        transform.GetChild(1).GetChild(3).GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = DataManager.Single.Data.inGameData.inGameItem.timeItemAmount.ToString();
        transform.GetChild(2).GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = DataManager.Single.Data.inGameData.inGameItem.shieldItemAmount.ToString();
        transform.GetChild(2).GetChild(3).GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = DataManager.Single.Data.inGameData.inGameItem.shieldItemAmount.ToString();
        transform.GetChild(3).GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = DataManager.Single.Data.inGameData.inGameItem.saveItemAmount.ToString();
        transform.GetChild(3).GetChild(3).GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = DataManager.Single.Data.inGameData.inGameItem.saveItemAmount.ToString();
        transform.GetChild(4).GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = DataManager.Single.Data.inGameData.inGameItem.boostItemAmount.ToString();
        transform.GetChild(4).GetChild(3).GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = DataManager.Single.Data.inGameData.inGameItem.boostItemAmount.ToString();
    }
}
