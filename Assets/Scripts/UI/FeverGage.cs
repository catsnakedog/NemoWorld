using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeverGage : MonoBehaviour
{
    private void Update()
    {
        FeverGageSet();
    }

    void FeverGageSet()
    {
        gameObject.GetComponent<Slider>().value = DataManager.Single.Data.inGameData.fever;
    }
}
