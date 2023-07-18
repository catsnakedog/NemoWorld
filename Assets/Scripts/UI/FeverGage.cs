using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeverGage : MonoBehaviour
{
    Slider slider;
    Image image;

    private void Update()
    {
        slider = gameObject.GetComponent<Slider>();
        image = transform.GetChild(1).GetChild(0).GetComponent<Image>();
        FeverGageSet();
    }

    void FeverGageSet()
    {
        slider.value = DataManager.Single.Data.inGameData.fever;

        if (DataManager.Single.Data.inGameData.isFever)
        {
            if (DataManager.Single.Data.inGameData.fever <= 6)
                image.color = Color.red;
        }
        else
            image.color = Color.blue;
    }
}