using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AdventureSelectBtn : EventTriggerEX
{
    [SerializeField]
    int stage;
    protected void Start()
    {
        init();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");
        DataManager.Single.Data.inGameData.stage = stage;
        MainController.main.UI.UIsetting(Define.UIlevel.Level2, Define.UItype.AdventureSelect);
    }
}