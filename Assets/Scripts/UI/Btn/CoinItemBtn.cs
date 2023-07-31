using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CoinItemBtn : EventTriggerEX
{
    [SerializeField]private int PurchaseGold;
    [SerializeField] private int Price;

    private void Start()
    {
        init();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");
        MainController.main.UI.UIsetting(Define.UIlevel.Level3, (Define.UItype)Enum.Parse(typeof(Define.UItype), "PurchaseCheckPanel"));
    }
}
