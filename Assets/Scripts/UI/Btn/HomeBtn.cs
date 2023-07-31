using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HomeBtn : EventTriggerEX
{
    protected void Start()
    {
        init();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");
        if(GameObject.FindWithTag("Level2").transform.childCount > 0)
            Destroy(GameObject.FindWithTag("Level2").transform.GetChild(0).gameObject);
        MainController.main.UI.UIsetting(Define.UIlevel.Level1, Define.UItype.MainLobby);
    }
}