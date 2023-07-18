using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AdventureBtn : EventTriggerEX
{
    protected void Start()
    {
        init();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");
        DataManager.Single.Data.inGameData.gameMode = "hard";
        MainController.main.UI.UIsetting(Define.UIlevel.Level1, Define.UItype.Adventure);
    }
}
