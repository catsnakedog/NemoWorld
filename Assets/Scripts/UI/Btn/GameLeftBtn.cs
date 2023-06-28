using System.Collections;
using System.Collections.Generic;
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
        Destroy(GameObject.FindWithTag("Level2").transform.GetChild(0).gameObject);
        Destroy(GameObject.FindWithTag("Level3").transform.GetChild(0).gameObject);
        Destroy(GameObject.FindWithTag("Map").transform.GetChild(0).gameObject);
        if (DataManager.Single.Data.inGameData.gameMode == "hard") MainController.main.UI.UIsetting(Define.UIlevel.Level1, Define.UItype.Adventure);
        if (DataManager.Single.Data.inGameData.gameMode == "easy") MainController.main.UI.UIsetting(Define.UIlevel.Level1, Define.UItype.Story);
    }
}