using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    Slider BGMSlider;
    Slider SFXSlider;

    protected void Start()
    {
        BGMSlider = gameObject.transform.GetChild(0).GetComponent<Slider>();
        SFXSlider = gameObject.transform.GetChild(1).GetComponent<Slider>();

        BGMSlider.value = DataManager.Single.Data.optionData.volumeBGM;
        SFXSlider.value = DataManager.Single.Data.optionData.volumeSFX;

        BGMSlider.onValueChanged.AddListener(volumeBGMChange);
        SFXSlider.onValueChanged.AddListener(volumeSFXChange);
    }

    void volumeBGMChange(float value)
    {
        DataManager.Single.Data.optionData.volumeBGM = value;
    }

    void volumeSFXChange(float value)
    {
        DataManager.Single.Data.optionData.volumeSFX = value;
    }
}