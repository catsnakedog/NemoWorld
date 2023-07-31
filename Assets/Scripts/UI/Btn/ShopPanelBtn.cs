using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopPanelBtn : EventTriggerEX
{
    GameObject ShopUIPanel;

    private void Start()
    {
        init();
        if(gameObject.name.Equals("Coin"))
            MainController.main.UI.UIsetting(Define.UIlevel.Level2, (Define.UItype)Enum.Parse(typeof(Define.UItype), gameObject.name));

    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");
        MainController.main.UI.UIsetting(Define.UIlevel.Level2, (Define.UItype)Enum.Parse(typeof(Define.UItype), gameObject.name));
    }
}
