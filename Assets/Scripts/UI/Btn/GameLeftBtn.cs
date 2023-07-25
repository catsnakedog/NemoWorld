using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameLeftBtn : EventTriggerEX
{
    protected void Start()
    {
        init();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");
        if (DataManager.Single.Data.inGameData.inGameItem.coinItem)
        {
            DataManager.Single.Data.inGameData.cost.gold += (int)(DataManager.Single.Data.inGameData.coinGetAmount * ((DataManager.Single.Data.inGameData.inGameItem.goldIncreaseAmount) + 1));
        }
        else
        {
            DataManager.Single.Data.inGameData.cost.gold += DataManager.Single.Data.inGameData.coinGetAmount;
        }

        Time.timeScale = 1f;
        Destroy(GameObject.FindWithTag("Level2").transform.GetChild(0).gameObject);
        if(GameObject.FindWithTag("Level3").transform.GetComponentsInChildren<Transform>().Length > 1)
        {
            Destroy(GameObject.FindWithTag("Level3").transform.GetChild(0).gameObject);
        }
        Transform[] transforms = GameObject.FindWithTag("Map").GetComponentsInChildren<Transform>();
        for (int i = 1; i < transforms.Length; i++)
        {
            Destroy(transforms[i].gameObject);
        }
        if (GameObject.FindWithTag("Ch").transform.GetComponentsInChildren<Transform>().Length > 1)
        {
            Destroy(GameObject.FindWithTag("Ch").transform.GetChild(0).gameObject);
        }
        if (DataManager.Single.Data.inGameData.gameMode == "hard") MainController.main.UI.UIsetting(Define.UIlevel.Level1, Define.UItype.Adventure);
        if (DataManager.Single.Data.inGameData.gameMode == "easy") MainController.main.UI.UIsetting(Define.UIlevel.Level1, Define.UItype.Story);
        if (DataManager.Single.Data.inGameData.gameMode == "rank") MainController.main.UI.UIsetting(Define.UIlevel.Level1, Define.UItype.RankingMode);
        MainController.main.sound.Play("mainBGM");
    }
}