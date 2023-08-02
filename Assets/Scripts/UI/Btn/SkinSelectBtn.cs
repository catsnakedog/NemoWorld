using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkinSelectBtn : EventTriggerEX
{
    protected string name;
    public string type { get; set; }
    public bool Get = false;


    protected void Start()
    {
        init();
    }

    public string SetUI
    {
        set
        {
            name = value;

            if (value.Equals(""))
            {
                transform.GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.sprite["skin_none"];
                GetComponent<Image>().sprite = MainController.main.resource.sprite["NormalSkinBG"];
                transform.GetChild(1).gameObject.SetActive(false);
                Get = true;
            }
            else
            {
                switch (value.Split('_')[0])
                {
                    case "Normal":
                        GetComponent<Image>().sprite = MainController.main.resource.sprite["NormalSkinBG"];
                        break;
                    case "Epic":
                        GetComponent<Image>().sprite = MainController.main.resource.sprite["EpicSkinBG"];
                        break;
                    case "Legend":
                        GetComponent<Image>().sprite = MainController.main.resource.sprite["LegendSkinBG"];
                        break;
                }
                switch (type)
                {
                    case "Head":
                        transform.GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.head_skin_sprite[value];
                        if (DataManager.Single.Data.inGameData.itemList.headItem.Contains(value)) Get = true;
                        else Get = false;
                            break;
                    case "Cloth":
                        transform.GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.cloth_skin_sprite[value];
                        if (DataManager.Single.Data.inGameData.itemList.clothItem.Contains(value)) Get = true;
                        else Get = false;
                        break;
                    case "Wing":
                        transform.GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.wing_skin_sprite[value];
                        if (DataManager.Single.Data.inGameData.itemList.wingItem.Contains(value)) Get = true;
                        else Get = false;
                        break;
                };
                if (Get)
                    transform.GetChild(1).gameObject.SetActive(false);
                else
                    transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        if (Get)
        {
            MainController.main.sound.Play("buttonSFX");
            SkinSet.UISet(type, name);
        }
    }
}
