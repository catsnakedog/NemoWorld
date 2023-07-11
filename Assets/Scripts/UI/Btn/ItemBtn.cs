using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemBtn : EventTriggerEX
{
    [SerializeField]
    int number;

    bool flag;

    private void Start()
    {
        flag = false;
        init();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        if(!flag)
        {
            switch (number)
            {
                case 0:
                    flag = !flag;
                    if (DataManager.Single.Data.inGameData.inGameItem.shieldItemAmount > 0)
                    {
                        transform.GetChild(1).gameObject.SetActive(true);
                        DataManager.Single.Data.inGameData.inGameItem.isUseShieldItem = true;
                    }
                    return;
                case 1:
                    flag = !flag;
                    if (DataManager.Single.Data.inGameData.inGameItem.saveItemAmount > 0)
                    {
                        transform.GetChild(1).gameObject.SetActive(true);
                        DataManager.Single.Data.inGameData.inGameItem.isUseSaveItem = true;
                    }
                    return;
                case 2:
                    flag = !flag;
                    if (DataManager.Single.Data.inGameData.inGameItem.coinItemAmount > 0)
                    {
                        transform.GetChild(1).gameObject.SetActive(true);
                        DataManager.Single.Data.inGameData.inGameItem.isUseCoinItem = true;
                    }
                    return;
                case 3:
                    flag = !flag;
                    if (DataManager.Single.Data.inGameData.inGameItem.timeItemAmount > 0)
                    {
                        transform.GetChild(1).gameObject.SetActive(true);
                        DataManager.Single.Data.inGameData.inGameItem.isUseTimeItem = true;
                    }
                    return;
            }
        }
        else
        {
            switch (number)
            {
                case 0:
                    flag = !flag;
                    if (DataManager.Single.Data.inGameData.inGameItem.shieldItemAmount > 0)
                    {
                        transform.GetChild(1).gameObject.SetActive(false);
                        DataManager.Single.Data.inGameData.inGameItem.isUseShieldItem = false;
                    }
                    return;
                case 1:
                    flag = !flag;
                    if (DataManager.Single.Data.inGameData.inGameItem.saveItemAmount > 0)
                    {
                        transform.GetChild(1).gameObject.SetActive(false);
                        DataManager.Single.Data.inGameData.inGameItem.isUseSaveItem = false;
                    }
                    return;
                case 2:
                    flag = !flag;
                    if (DataManager.Single.Data.inGameData.inGameItem.coinItemAmount > 0)
                    {
                        transform.GetChild(1).gameObject.SetActive(false);
                        DataManager.Single.Data.inGameData.inGameItem.isUseCoinItem = false;
                    }
                    return;
                case 3:
                    flag = !flag;
                    if (DataManager.Single.Data.inGameData.inGameItem.timeItemAmount > 0)
                    {
                        transform.GetChild(1).gameObject.SetActive(false);
                        DataManager.Single.Data.inGameData.inGameItem.isUseTimeItem = false;
                    }
                    return;
            }
        }
    }
}
