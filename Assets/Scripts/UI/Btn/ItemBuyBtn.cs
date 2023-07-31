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

        switch (ItemManager.selectItem)
        {
            case "HeadTicket":
                DataManager.Single.Data.inGameData.cost.gachaPiece -= ItemManager.count * ItemManager.price;
                DataManager.Single.Data.inGameData.cost.headTicket += ItemManager.count;
                break;
            case "ClothTicket":
                DataManager.Single.Data.inGameData.cost.gachaPiece -= ItemManager.count * ItemManager.price;
                DataManager.Single.Data.inGameData.cost.clothTicket += ItemManager.count;
                break;
            case "WingTicket":
                DataManager.Single.Data.inGameData.cost.gachaPiece -= ItemManager.count * ItemManager.price;
                DataManager.Single.Data.inGameData.cost.wingTicket += ItemManager.count;
                break;
            case "Gold":
                DataManager.Single.Data.inGameData.cost.gold -= ItemManager.count * ItemManager.price;
                DataManager.Single.Data.inGameData.inGameItem.coinItemAmount += ItemManager.count;
                break;
            case "Time":
                DataManager.Single.Data.inGameData.cost.gold -= ItemManager.count * ItemManager.price;
                DataManager.Single.Data.inGameData.inGameItem.timeItemAmount += ItemManager.count;
                break;
            case "Shield":
                DataManager.Single.Data.inGameData.cost.gold -= ItemManager.count * ItemManager.price;
                DataManager.Single.Data.inGameData.inGameItem.shieldItemAmount += ItemManager.count;
                break;
            case "Save":
                DataManager.Single.Data.inGameData.cost.gold -= ItemManager.count * ItemManager.price;
                DataManager.Single.Data.inGameData.inGameItem.saveItemAmount += ItemManager.count;
                break;
            case "StartBooster":
                DataManager.Single.Data.inGameData.cost.gold -= ItemManager.count * ItemManager.price;
                DataManager.Single.Data.inGameData.inGameItem.boostItemAmount += ItemManager.count;
                break;
        }

        Destroy(GameObject.FindWithTag("Level3").transform.GetChild(0).gameObject);
    }
}
