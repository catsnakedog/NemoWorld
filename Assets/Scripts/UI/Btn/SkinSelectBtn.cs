using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkinSelectBtn : EventTriggerEX
{
    protected string name;
    public string type { get; set; }


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
        SkinSet.UISet(type, name);
    }
}
