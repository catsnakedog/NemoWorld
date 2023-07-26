using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RankModeHepBtn : EventTriggerEX
{
    [SerializeField]
    GameObject helpPanel;

    [SerializeField]
    bool isOn;

    void Start()
    {
        init();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");
        helpPanel.SetActive(isOn);
    }
}
