using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GachaBuyBtn : EventTriggerEX
{
    private int cnt;
    private int price;
    private string cost;
    
    

    void Start()
    {
        init();

        cnt = int.Parse(gameObject.name.Split('_')[0]);
        cost = gameObject.name.Split('_')[1];
        if (cost.Equals("Gold"))
            price = 200;
        else if (cost.Equals("Ticket"))
            price = 1;
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");

        bool check = false;

        if(price == 200) // Gold
        {
            if(price * cnt <= DataManager.Single.Data.inGameData.cost.gold)
            {
                DataManager.Single.Data.inGameData.cost.gold -= price * cnt;
                GachaManager.Gacha(cost, cnt);
            }
        }
        else // Ticket
        {
            switch (GachaManager.GachaType)
            {
                case "Head":
                    if (price * cnt <= DataManager.Single.Data.inGameData.cost.headTicket)
                    {
                        check = true;
                        DataManager.Single.Data.inGameData.cost.headTicket -= price * cnt;
                    }
                    break;
                case "Cloth":
                    if (price * cnt <= DataManager.Single.Data.inGameData.cost.clothTicket)
                    {
                        check = true;
                        DataManager.Single.Data.inGameData.cost.clothTicket -= price * cnt;
                    }
                    break;
                case "Wing":
                    if (price * cnt <= DataManager.Single.Data.inGameData.cost.wingTicket)
                    {
                        check = true;
                        DataManager.Single.Data.inGameData.cost.wingTicket -= price * cnt;
                    }
                    break;
            }
            if (check)
            {
                GachaManager.Gacha(cost, cnt);
            }
        }
    }
}
