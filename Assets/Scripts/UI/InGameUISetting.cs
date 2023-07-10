using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameUISetting : MonoBehaviour
{
    Action inGameAction;
    TMP_Text goldText;

    protected void Start()
    {
        if (DataManager.Single.Data.inGameData.gameMode == "easy") transform.GetChild(1).gameObject.SetActive(true);
        if (DataManager.Single.Data.inGameData.gameMode == "hard") transform.GetChild(2).gameObject.SetActive(true);
        goldText = transform.GetChild(1).GetChild(1).GetComponent<TMP_Text>();

        inGameAction += CoinUI;
    }

    private void Update()
    {
        inGameAction?.Invoke();
    }

    void CoinUI()
    {
        goldText.text = DataManager.Single.Data.inGameData.coinGetAmount.ToString();
    }
}
