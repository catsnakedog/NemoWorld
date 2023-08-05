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
        
        if (DataManager.Single.Data.optionData.muteBGM)
        {
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(3).gameObject.SetActive(false);
        }
        if (DataManager.Single.Data.optionData.muteSFX)
        {
            transform.GetChild(4).gameObject.SetActive(false);
            transform.GetChild(5).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(4).gameObject.SetActive(true);
            transform.GetChild(5).gameObject.SetActive(false);
        }

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

    public void MuteOnBGM()
    {
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(true);
        DataManager.Single.Data.optionData.muteBGM = true;
    }

    public void MuteOffBGM()
    {
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(3).gameObject.SetActive(false);
        DataManager.Single.Data.optionData.muteBGM = false;
    }

    public void MuteOnSFX()
    {
        transform.GetChild(4).gameObject.SetActive(false);
        transform.GetChild(5).gameObject.SetActive(true);
        DataManager.Single.Data.optionData.muteSFX = true;
    }

    public void MuteOffSFX()
    {
        transform.GetChild(4).gameObject.SetActive(true);
        transform.GetChild(5).gameObject.SetActive(false);
        DataManager.Single.Data.optionData.muteSFX = false;
    }
}