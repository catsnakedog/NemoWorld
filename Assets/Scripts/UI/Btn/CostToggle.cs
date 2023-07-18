using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CostToggle : EventTriggerEX
{
    GameObject costInfoUI;
    Image toggle;
    bool isOn;

    protected void Start()
    {
        init();
        costInfoUI = GameObject.FindWithTag("Cost").transform.GetChild(1).gameObject;
        toggle = transform.GetChild(0).GetComponent<Image>();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");
        if (costInfoUI == null)
        {
            costInfoUI = GameObject.FindWithTag("Cost").transform.GetChild(1).gameObject;
        }
        if(!isOn)
        {
            costInfoUI.SetActive(true);
            toggle.sprite = MainController.main.resource.sprite["Down"];
            isOn = true;
        }
        else
        {
            costInfoUI.SetActive(false);
            toggle.sprite = MainController.main.resource.sprite["Up"];
            isOn = false;
        }
    }
}
