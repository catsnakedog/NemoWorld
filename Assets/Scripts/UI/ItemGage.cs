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
        slider = gameObject.GetComponent<Slider>();
    }

    void Update()
    {
        if(DataManager.Single.Data.inGameData.isItem)
        {
            if(effect != null)
            {
                StopCoroutine(effect);
            }
            action = null;

            effect = StartCoroutine(Effect());
            DataManager.Single.Data.inGameData.isItem = false;
        }

        action?.Invoke();
    }

    void Follow()
    {
        transform.position = ch.transform.position + new Vector3(0f, 0.5f, 0f);
    }

    IEnumerator Effect()
    {
        action += Follow;

        for(int i = 0; i < 50; i++)
        {
            slider.value = 50 - i;
            yield return new WaitForSeconds(0.1f);
        }

        action -= Follow;
        transform.position = new Vector3(0, 15f, 0);
    }
}
