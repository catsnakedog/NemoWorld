using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseBtn : EventTriggerEX
{
    protected void Start()
    {
        init();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");
        Time.timeScale = 0f;
        MainController.main.UI.UIsetting(Define.UIlevel.Level3, Define.UItype.Pause);
    }
}
