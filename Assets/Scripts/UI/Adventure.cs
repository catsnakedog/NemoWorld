using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventure : MonoBehaviour
{
    void Start()
    {
        AdventureBtnSet();
    }

    void AdventureBtnSet()
    {
        transform.GetChild(2).gameObject.SetActive(true);
        if (DataManager.Single.Data.inGameData.adventureClearList.Contains("stage1"))
        {
            transform.GetChild(3).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(true);
        }
        if (DataManager.Single.Data.inGameData.adventureClearList.Contains("stage2"))
        {
            transform.GetChild(4).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}