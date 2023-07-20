using System.Collections;
using System.Collections.Generic;
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
                        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.head_skin_sprite[DataManager.Single.Data.inGameData.itemList.headItem[value]];
                    }
                    return;
                case "Cloth":
                    if (value < DataManager.Single.Data.inGameData.itemList.clothItem.Count)
                    {
                        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.cloth_skin_sprite[DataManager.Single.Data.inGameData.itemList.clothItem[value]];
                    }
                    return;
                case "Wing":
                    if (value < DataManager.Single.Data.inGameData.itemList.wingItem.Count)
                    {
                        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.wing_skin_sprite[DataManager.Single.Data.inGameData.itemList.wingItem[value]];
                    }
                    return;
            };
        }
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");
        SkinSet.SetSkin(type, number);
    }
}
