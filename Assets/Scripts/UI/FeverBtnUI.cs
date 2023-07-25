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
        image.fillAmount = (DataManager.Single.Data.inGameData.fever / 20f);
    }
}
