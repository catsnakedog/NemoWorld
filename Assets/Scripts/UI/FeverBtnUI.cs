using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeverBtnUI : MonoBehaviour
{
    Image image;

    void Start()
    {
        image = gameObject.GetComponent<Image>();
    }
    void Update()
    {
        if(DataManager.Single.Data.inGameData.fever >= 20f)
        {
            image.sprite = MainController.main.resource.sprite["FeverOn"];
        }
        else if (DataManager.Single.Data.inGameData.fever <= 0f)
        {
            image.sprite = MainController.main.resource.sprite["FeverOff"];
        }

        image.fillAmount = (DataManager.Single.Data.inGameData.fever / 20f);
    }
}
