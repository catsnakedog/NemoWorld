using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class SkinTypeSelectBtn : EventTriggerEX
{
    [SerializeField]
    string type;
    Transform[] transforms;

    protected void Start()
    {
        init();

        transforms = GameObject.FindWithTag("Skin").GetComponentsInChildren<Transform>();
        if (type != "Head") return;
        int cnt = 0;
        for(int i = 0; i < transforms.Length; i++ )
        {
            if (transforms[i].name == "Content" || transforms[i].name == "Image") continue;
            SkinSelectBtn temp;
            temp = transforms[i].gameObject.AddComponent<SkinSelectBtn>();
            temp.type = "Head";
            temp.SetUI = cnt;
            cnt++;
        }
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");
        int cnt = 0;
        for (int i = 1; i < transforms.Length; i++)
        {
            if (transforms[i].name == "Content" || transforms[i].name == "Image") continue;
            SkinSelectBtn temp = transforms[i].GetComponent<SkinSelectBtn>();
            temp.type = type;
            temp.SetUI = cnt;
            cnt++;
        }
    }
}