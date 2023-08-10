using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLobbyBtnUI : MonoBehaviour
{
    void Start()
    {
        if(DataManager.Single.Data.inGameData.adventureClearList.Count > 2)
        {
            transform.GetChild(7).gameObject.SetActive(false);
        }
        if (DataManager.Single.Data.inGameData.storyClearList.Count > 2 )
        {
            transform.GetChild(6).gameObject.SetActive(false);
        }
    }
}
