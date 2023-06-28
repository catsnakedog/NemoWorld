using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerJumpBtn : EventTriggerEX
{
    PlayerMove ch;
    protected void Start()
    {
        init();
        ch = GameObject.FindWithTag("Ch").transform.GetChild(0).GetComponent<PlayerMove>();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        ch.Jump();
    }
}
