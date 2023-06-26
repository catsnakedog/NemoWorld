using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StageSelectLeftBtn : EventTriggerEX
{
    protected void Start()
    {
        init();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        Destroy(GameObject.FindWithTag("Level2").transform.GetChild(0).gameObject);
    }
}
