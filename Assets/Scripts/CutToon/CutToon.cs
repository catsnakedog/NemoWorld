using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutToon : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Image>().sprite = MainController.main.resource.sprite[DataManager.Single.Data.inGameData.cutToonName];
    }
}
