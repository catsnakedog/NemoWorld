using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    GameObject itemSelect;

    void Start()
    {
        DataManager.Single.Data.inGameData.inGameItem.isUseShieldItem = false;
        DataManager.Single.Data.inGameData.inGameItem.isUseSaveItem = false;
        DataManager.Single.Data.inGameData.inGameItem.isUseCoinItem = false;
        DataManager.Single.Data.inGameData.inGameItem.isUseTimeItem = false;

        itemSelect = transform.GetChild(3).gameObject;
        itemSelect.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = DataManager.Single.Data.inGameData.inGameItem.shieldItemAmount.ToString();
        itemSelect.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = DataManager.Single.Data.inGameData.inGameItem.saveItemAmount.ToString();
        itemSelect.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = DataManager.Single.Data.inGameData.inGameItem.coinItemAmount.ToString();
        itemSelect.transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = DataManager.Single.Data.inGameData.inGameItem.timeItemAmount.ToString();
    }
}
