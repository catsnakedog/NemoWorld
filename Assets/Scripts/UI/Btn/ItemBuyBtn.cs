using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemBuyBtn : EventTriggerEX
{
    void Start()
    {
        init();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");

        ItemManager.ItemBuy();
    }
}
