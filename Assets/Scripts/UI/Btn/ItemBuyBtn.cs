using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemBuyBtn : EventTriggerEX
{
    [SerializeField]
    int type;
    [SerializeField]
    int number;
    [SerializeField]
    int price;
    void Start()
    {
        init();   
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");
        if (DataManager.Single.Data.inGameData.cost.gold >= price)
        {
            DataManager.Single.Data.inGameData.cost.gold -= price;
            switch(type)
            {
                case 0:
                    DataManager.Single.Data.inGameData.inGameItem.shieldItemAmount += number;
                    return;
                case 1:
                    DataManager.Single.Data.inGameData.inGameItem.saveItemAmount += number;
                    return;
                case 2:
                    DataManager.Single.Data.inGameData.inGameItem.coinItemAmount += number;
                    return;
                case 3:
                    DataManager.Single.Data.inGameData.inGameItem.timeItemAmount += number;
                    return;
            }
        }
    }
}
