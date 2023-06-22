using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public static MainController main;

    public UILevelController UI { get; set; }
    public ResourceController resource { get; set; }

    void Start()
    {
        init();
    }

    public void init()
    {
        main = this.GetComponent<MainController>();
        resource = gameObject.AddComponent<ResourceController>();
        UI = gameObject.AddComponent<UILevelController>();

        resource.init();
        UI.init();
    }
}