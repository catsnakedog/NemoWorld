using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSelectBtn : EventTriggerEX
{
    [SerializeField]
    int number;
    [SerializeField]
    bool flag;
    [SerializeField]
    GameObject obj;

    void Start()
    {
        init();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");

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
    }

}
