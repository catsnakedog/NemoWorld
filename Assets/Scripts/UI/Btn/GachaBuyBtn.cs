using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GachaBuyBtn : EventTriggerEX
{
    [SerializeField] private int cnt;
    [SerializeField] private int price;
    [SerializeField] private string cost;
    

    void Start()
    {
        init();
    }


    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");

        if (cost.Equals("Gold"))
        {
            if (price * cnt <= DataManager.Single.Data.inGameData.cost.gold)
            {
                DataManager.Single.Data.inGameData.cost.gold -= price * cnt;
                GachaManager.Gacha(cost, cnt);
            }
        }
        else
        {
            switch (GachaManager.page)
            {
                case 1:
                    if(price * cnt <= DataManager.Single.Data.inGameData.cost.headTicket)
                    {
                        DataManager.Single.Data.inGameData.cost.headTicket -= price * cnt;
                        GachaManager.Gacha(cost, cnt);
                    }
                    break;
                case 2:
                    if (price * cnt <= DataManager.Single.Data.inGameData.cost.clothTicket)
                    {
                        DataManager.Single.Data.inGameData.cost.clothTicket -= price * cnt;
                        GachaManager.Gacha(cost, cnt);
                    }
                    break;
                case 3:
                    if (price * cnt <= DataManager.Single.Data.inGameData.cost.wingTicket)
                    {
                        DataManager.Single.Data.inGameData.cost.wingTicket -= price * cnt;
                        GachaManager.Gacha(cost, cnt);
                    }
                    break;
            }
        }
    }
}
