using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StoryBtn : EventTriggerEX
{
    protected void Start()
    {
        init();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        DataManager.Single.Data.inGameData.gameMode = "easy";
        MainController.main.UI.UIsetting(Define.UIlevel.Level1, Define.UItype.Story);
    }
}