using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemGage : MonoBehaviour
{
    GameObject ch;
    Coroutine effect;
    Action action;
    Slider slider;

    void Start()
    {
        ch = GameObject.Find("Ch").transform.GetChild(0).gameObject;
        ch.GetComponent<PlayerMove>().slider = gameObject.GetComponent<Slider>();
        gameObject.SetActive(false);
    }
}
