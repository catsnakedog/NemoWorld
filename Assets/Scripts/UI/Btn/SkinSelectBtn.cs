using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkinSelectBtn : EventTriggerEX
{
    protected int number;
    public string type { get; set; }

    protected void Start()
    {
        init();
    }

    public int SetUI
    {
        set
        {
            number = value;
            switch (type)
            {
                case "Head":
                    if (value < DataManager.Single.Data.inGameData.itemList.headItem.Count)
                    {
                        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.sprite[DataManager.Single.Data.inGameData.itemList.headItem[value]];
                    }
                    return;
                case "Cloth":
                    if (value < DataManager.Single.Data.inGameData.itemList.clothItem.Count)
                    {
                        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.sprite[DataManager.Single.Data.inGameData.itemList.clothItem[value]];
                    }
                    return;
                case "Wing":
                    if (value < DataManager.Single.Data.inGameData.itemList.wingItem.Count)
                    {
                        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.sprite[DataManager.Single.Data.inGameData.itemList.wingItem[value]];
                    }
                    return;
            };
        }
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        switch(type)
        {
            case "Head":
                if (number < DataManager.Single.Data.inGameData.itemList.headItem.Count)
                {
                    DataManager.Single.Data.inGameData.ch.head = DataManager.Single.Data.inGameData.itemList.headItem[number];
                }
                return;
            case "Cloth":
                if (number < DataManager.Single.Data.inGameData.itemList.clothItem.Count)
                {
                    DataManager.Single.Data.inGameData.ch.cloth = DataManager.Single.Data.inGameData.itemList.clothItem[number];
                }
                return;
            case "Wing":
                if (number < DataManager.Single.Data.inGameData.itemList.wingItem.Count)
                {
                    DataManager.Single.Data.inGameData.ch.wing = DataManager.Single.Data.inGameData.itemList.wingItem[number];
                }
                return;
        }
    }
}
