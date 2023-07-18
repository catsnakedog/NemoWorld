using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour
{
    void Start()
    {
        StoryBtnSet();
    }

    void StoryBtnSet()
    {
        transform.GetChild(3).gameObject.SetActive(true);
        if (DataManager.Single.Data.inGameData.storyClearList.Contains("stage1"))
        {
            transform.GetChild(4).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(true);
        }
        if (DataManager.Single.Data.inGameData.storyClearList.Contains("stage2"))
        {
            transform.GetChild(5).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
        }
        if (DataManager.Single.Data.inGameData.storyClearList.Contains("stage3"))
        {
            transform.GetChild(2).gameObject.SetActive(true);
        }
    }
}