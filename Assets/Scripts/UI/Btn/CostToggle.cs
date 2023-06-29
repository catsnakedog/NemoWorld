using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CostToggle : EventTriggerEX
{
    GameObject costInfoUI;
    bool isOn;

    protected void Start()
    {
        init();
        costInfoUI = GameObject.FindWithTag("Cost").transform.GetChild(1).gameObject;
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        if(costInfoUI == null)
        {
            costInfoUI = GameObject.FindWithTag("Cost").transform.GetChild(1).gameObject;
        }
        if(!isOn)
        {
            costInfoUI.SetActive(true);
            isOn = true;
        }
        else
        {
            costInfoUI.SetActive(false);
            isOn = false;
        }
    }
}