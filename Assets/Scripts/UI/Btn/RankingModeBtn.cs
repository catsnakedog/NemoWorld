using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RankingModeBtn : EventTriggerEX
{
    protected void Start()
    {
        init();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");
        DataManager.Single.Data.inGameData.gameMode = "rank";
        MainController.main.UI.UIsetting(Define.UIlevel.Level1, Define.UItype.RankLoading);
    }
}