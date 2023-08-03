using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeverBtnUI : MonoBehaviour
{
    Image image;
    Image textImage;

    void Start()
    {
        image = gameObject.GetComponent<Image>();
        textImage = transform.GetChild(0).GetComponent<Image>();
    }
    void Update()
    {
        if(DataManager.Single.Data.inGameData.fever >= 20f)
        {
            image.sprite = MainController.main.resource.sprite["FeverOn"];
            textImage.sprite = MainController.main.resource.sprite["Button_Fever_able"];
        }
        else if (DataManager.Single.Data.inGameData.fever <= 0f)
        {
            image.sprite = MainController.main.resource.sprite["FeverOff"];
            textImage.sprite = MainController.main.resource.sprite["Button_Fever_unable"];
        }

        image.fillAmount = (DataManager.Single.Data.inGameData.fever / 20f);
    }
}
