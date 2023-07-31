using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PurchaseBtn : EventTriggerEX
{
    void Start()
    {
        init();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");
        ///¿Œæ€∞·¡¶
        //Destroy(GameObject.FindWithTag("Level3").transform.GetChild(0).gameObject);
    }
}
