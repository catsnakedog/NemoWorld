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
        if (DataManager.Single.Data.inGameData.missionClearList.Contains("stage1"))
        {
            transform.GetChild(3).gameObject.SetActive(true);
        }
        if (DataManager.Single.Data.inGameData.missionClearList.Contains("stage2"))
        {
            transform.GetChild(4).gameObject.SetActive(true);
        }
        if (DataManager.Single.Data.inGameData.missionClearList.Contains("stage3"))
        {
            transform.GetChild(5).gameObject.SetActive(true);
        }

        if (DataManager.Single.Data.inGameData.adventureClearList.Contains("stage1"))
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        if (DataManager.Single.Data.inGameData.adventureClearList.Contains("stage2"))
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
        if (DataManager.Single.Data.inGameData.adventureClearList.Contains("stage3"))
        {
            transform.GetChild(2).gameObject.SetActive(true);
        }
    }
}