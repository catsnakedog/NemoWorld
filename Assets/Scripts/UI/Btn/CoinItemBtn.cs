using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CoinItemBtn : EventTriggerEX
{
    [SerializeField] private int PurchaseGold;
    [SerializeField] private int Price;
    public static string name;
    public static string price;

    private void Start()
    {
        init();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");
        name = transform.Find("ItemName").GetComponentInChildren<Text>().text;
        price = "£Ü " + Price.ToString();
        MainController.main.UI.UIsetting(Define.UIlevel.Level3, (Define.UItype)Enum.Parse(typeof(Define.UItype), "PurchaseCheckPanel"));
    }
}
