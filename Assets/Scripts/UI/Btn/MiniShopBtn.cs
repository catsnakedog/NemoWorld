using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MiniShopBtn : EventTriggerEX
{
    protected void Start()
    {
        init();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");

        if (gameObject.name.Equals("Gacha"))
        {
            MainController.main.UI.UIsetting(Define.UIlevel.Level1, Define.UItype.Gacha);
        }
        else
        {
            MainController.main.UI.UIsetting(Define.UIlevel.Level1, Define.UItype.Item);
        }

    }
}
