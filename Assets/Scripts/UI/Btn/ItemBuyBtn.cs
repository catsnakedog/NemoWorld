using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemBuyBtn : EventTriggerEX
{
    int type;
    [SerializeField]
    int price;

    void Start()
    {
        init();
        type = (int)Enum.Parse(typeof(Define.ItemShop), gameObject.name);
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");

        if(type == (int)Define.ItemShop.GachaTicket)
        {
            if(DataManager.Single.Data.inGameData.cost.gachaPiece >= 10)
            {
                DataManager.Single.Data.inGameData.cost.gachaPiece -= 10;
                DataManager.Single.Data.inGameData.cost.gachaTicket++;
            }
        }
        else if (DataManager.Single.Data.inGameData.cost.gold >= price)
        {
            DataManager.Single.Data.inGameData.cost.gold -= price;
            switch(type)
            {
                case (int)Define.ItemShop.Gold:
                    DataManager.Single.Data.inGameData.inGameItem.coinItemAmount++;
                    return;
                case (int)Define.ItemShop.Time:
                    DataManager.Single.Data.inGameData.inGameItem.timeItemAmount++;
                    return;
                case (int)Define.ItemShop.Shield:
                    DataManager.Single.Data.inGameData.inGameItem.shieldItemAmount++;
                    return;
                case (int)Define.ItemShop.Save:
                    DataManager.Single.Data.inGameData.inGameItem.saveItemAmount++;
                    return;
                case (int)Define.ItemShop.StartBooster:
                    DataManager.Single.Data.inGameData.inGameItem.boostItemAmount++;
                    return;
            }
        }
    }
}
