using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PurchaseBtn : EventTriggerEX
{
    public Text name;
    public Text price;

    void Start()
    {
        init();
        name.text = CoinItemBtn.name;
        price.text = CoinItemBtn.price;
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");
        ///¿Œæ€∞·¡¶
        //Destroy(GameObject.FindWithTag("Level3").transform.GetChild(0).gameObject);
    }
}
