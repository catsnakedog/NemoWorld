using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResumeBtn : EventTriggerEX
{
    protected void Start()
    {
        init();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        Time.timeScale = 1f;
        Destroy(GameObject.FindWithTag("Level3").transform.GetChild(0).gameObject);
    }
}