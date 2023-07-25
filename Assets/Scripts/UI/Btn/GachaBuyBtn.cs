using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GachaBuyBtn : EventTriggerEX
{
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
            //TODO : Gacha Item Code
            //DataManager.Single.Data.inGameData.gachaPercent > È®·ü
        }
    }
}
