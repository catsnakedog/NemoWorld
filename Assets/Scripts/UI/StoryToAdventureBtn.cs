using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryToAdventureBtn : MonoBehaviour
{
    void Start()
    {
        if(DataManager.Single.Data.inGameData.storyClearList.Count > 0)
        {
            gameObject.SetActive(false);
        }
    }
}
