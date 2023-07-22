using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkinSelectBtn : EventTriggerEX
{
    protected string name;
    public string type { get; set; }

    GameObject head, cloth, wing;

    protected void Start()
    {
        init();

        head = GameObject.Find("ChUI").transform.FindChild("Head").gameObject;
        cloth = GameObject.Find("ChUI").transform.FindChild("Cloth").gameObject;
        wing = GameObject.Find("ChUI").transform.FindChild("Wing").gameObject;

        if (!DataManager.Single.Data.inGameData.ch.head.Equals(""))
        {
            head.SetActive(true);
            head.GetComponent<Image>().sprite = MainController.main.resource.head_skin_sprite[DataManager.Single.Data.inGameData.ch.head];
        }
        if (!DataManager.Single.Data.inGameData.ch.cloth.Equals(""))
        {
            cloth.SetActive(true);
            cloth.GetComponent<Image>().sprite = MainController.main.resource.cloth_skin_sprite[DataManager.Single.Data.inGameData.ch.cloth];
        }
        if (!DataManager.Single.Data.inGameData.ch.wing.Equals(""))
        {
            wing.SetActive(true);
            wing.GetComponent<Image>().sprite = MainController.main.resource.wing_skin_sprite[DataManager.Single.Data.inGameData.ch.wing];
        }
    }

    public string SetUI
    {
        set
        {
            name = value;

            if (value.Equals(""))
            {
                transform.GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.sprite["skin_none"];
            }
            else
            {
                switch (type)
                {
                    case "Head":
                        transform.GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.head_skin_sprite[value];
                        return;
                    case "Cloth":
                        transform.GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.cloth_skin_sprite[value];
                        return;
                    case "Wing":
                        transform.GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.wing_skin_sprite[value];
                        return;
                };
            }
        }
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");

        if (name.Equals(""))
        {
            switch (type)
            {
                case "Head":
                    DataManager.Single.Data.inGameData.ch.head = name;
                    head.SetActive(false);
                    return;
                case "Cloth":
                    DataManager.Single.Data.inGameData.ch.cloth = name;
                    cloth.SetActive(false);
                    return;
                case "Wing":
                    DataManager.Single.Data.inGameData.ch.wing = name;
                    wing.SetActive(false);
                    return;
            }
        }
        else
        {
            switch (type)
            {
                case "Head":
                    DataManager.Single.Data.inGameData.ch.head = name;
                    head.SetActive(true);
                    head.GetComponent<Image>().sprite = MainController.main.resource.head_skin_sprite[DataManager.Single.Data.inGameData.ch.head];
                    return;
                case "Cloth":
                    DataManager.Single.Data.inGameData.ch.cloth = name;
                    cloth.SetActive(true);
                    cloth.GetComponent<Image>().sprite = MainController.main.resource.cloth_skin_sprite[DataManager.Single.Data.inGameData.ch.cloth];
                    return;
                case "Wing":
                    DataManager.Single.Data.inGameData.ch.wing = name;
                    wing.SetActive(true);
                    wing.GetComponent<Image>().sprite = MainController.main.resource.wing_skin_sprite[DataManager.Single.Data.inGameData.ch.wing];
                    return;
            }
        }
    }
}
