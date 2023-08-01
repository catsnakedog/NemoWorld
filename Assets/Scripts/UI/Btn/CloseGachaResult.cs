using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseGachaResult : EventTriggerEX
{
    
    void Start()
    {
        init();
        
    }
    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");

        if (GameObject.Find("1Result") != null)
            GameObject.Find("1Result").gameObject.SetActive(false);
        else if (GameObject.Find("10Result") != null)
            GameObject.Find("10Result").gameObject.SetActive(false);
    }
}
