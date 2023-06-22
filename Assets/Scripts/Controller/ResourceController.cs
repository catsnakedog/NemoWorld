using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class ResourceController : MonoBehaviour
{
    DataManager Single;
    MainController main;

    public List<GameObject> UItype { get; set; }
    public List<Material> EffectType { get; set; }

    public void init()
    {
        Single = DataManager.Single;
        main = MainController.main;
        UItypeSetting();
    }

    void UItypeSetting()
    {
        UItype = new List<GameObject>();
        for (int i = 0; i < (int)Define.UItype.MaxCount; i++)
        {
            UItype.Add(Resources.Load<GameObject>("Prefabs/UI/" + Enum.GetName(typeof(Define.UItype), i)));
        }
    }
}