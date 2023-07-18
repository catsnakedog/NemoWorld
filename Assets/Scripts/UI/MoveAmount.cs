using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveAmount : MonoBehaviour
{
    Slider slider;
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = (DataManager.Single.Data.inGameData.moveAmount / DataManager.Single.Data.inGameData.maxX) * 100;
    }
}
