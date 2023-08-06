using System;
using UnityEngine.EventSystems;

public class ItemBtn : EventTriggerEX
{
    
    private bool check = false;

    private void Start()
    {
        init();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");
        
        check = false;
        switch (gameObject.name)
        {
            case "HeadTicket": case "ClothTicket": case "WingTicket":
                if (DataManager.Single.Data.inGameData.cost.gachaPiece >= 10)
                    check = true;
                break;
            default:
                if (DataManager.Single.Data.inGameData.cost.gold >= 20)
                    check = true;
                break;
        }

        if (check)
        {
            MainController.main.UI.UIsetting(Define.UIlevel.Level3, Define.UItype.ItemBuyPanel);
            ItemManager.selectItem = gameObject.name;
        }

        /*
        if (flag)
        {
            switch (number)
            {
                case 0:
                    if (DataManager.Single.Data.inGameData.inGameItem.shieldItemAmount > 0)
                    {
                        obj.SetActive(true);
                        DataManager.Single.Data.inGameData.inGameItem.isUseShieldItem = true;
                    }
                    return;
                case 1:
                    if (DataManager.Single.Data.inGameData.inGameItem.saveItemAmount > 0)
                    {
                        obj.SetActive(true);
                        DataManager.Single.Data.inGameData.inGameItem.isUseSaveItem = true;
                    }
                    return;
                case 2:
                    if (DataManager.Single.Data.inGameData.inGameItem.coinItemAmount > 0)
                    {
                        obj.SetActive(true);
                        DataManager.Single.Data.inGameData.inGameItem.isUseCoinItem = true;
                    }
                    return;
                case 3:
                    if (DataManager.Single.Data.inGameData.inGameItem.timeItemAmount > 0)
                    {
                        obj.SetActive(true);
                        DataManager.Single.Data.inGameData.inGameItem.isUseTimeItem = true;
                    }
                    return;
                case 4:
                    if (DataManager.Single.Data.inGameData.inGameItem.boostItemAmount > 0)
                    {
                        obj.SetActive(true);
                        DataManager.Single.Data.inGameData.inGameItem.isUseBoostItem = true;
                    }
                    return;
            }
        }
        else
        {
            switch (number)
            {
                case 0:
                    if (DataManager.Single.Data.inGameData.inGameItem.shieldItemAmount > 0)
                    {
                        obj.SetActive(false);
                        DataManager.Single.Data.inGameData.inGameItem.isUseShieldItem = false;
                    }
                    return;
                case 1:
                    if (DataManager.Single.Data.inGameData.inGameItem.saveItemAmount > 0)
                    {
                        obj.SetActive(false);
                        DataManager.Single.Data.inGameData.inGameItem.isUseSaveItem = false;
                    }
                    return;
                case 2:
                    if (DataManager.Single.Data.inGameData.inGameItem.coinItemAmount > 0)
                    {
                        obj.SetActive(false);
                        DataManager.Single.Data.inGameData.inGameItem.isUseCoinItem = false;
                    }
                    return;
                case 3:
                    if (DataManager.Single.Data.inGameData.inGameItem.timeItemAmount > 0)
                    {
                        obj.SetActive(false);
                        DataManager.Single.Data.inGameData.inGameItem.isUseTimeItem = false;
                    }
                    return;
                case 4:
                    if (DataManager.Single.Data.inGameData.inGameItem.boostItemAmount > 0)
                    {
                        obj.SetActive(false);
                        DataManager.Single.Data.inGameData.inGameItem.isUseBoostItem = false;
                    }
                    return;
            }
        }
        */
    }
}
