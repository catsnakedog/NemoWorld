using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjManager : MonoBehaviour
{
    private void Update()
    {
        if(DataManager.Single.Data.inGameData.crruentQuest.gameMode == "easy")
        {
            return;
        }

        for(int i = 0; i < DataManager.Single.Data.inGameData.mapObj.Count; i++)
        {
            if (transform.position.x >= DataManager.Single.Data.inGameData.mapObj[i].x)
            {
                if (DataManager.Single.Data.inGameData.mapObj[i].map.activeSelf == false)
                {
                    DataManager.Single.Data.inGameData.mapObj[i].map.SetActive(true);
                }
                else
                {
                    DataManager.Single.Data.inGameData.mapObj[i].map.SetActive(false);
                }
                DataManager.Single.Data.inGameData.mapObj.RemoveAt(i);
                break;
            }
        }
    }
}