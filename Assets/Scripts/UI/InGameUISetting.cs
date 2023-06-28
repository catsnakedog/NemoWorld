using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUISetting : MonoBehaviour
{
    protected void Start()
    {
        if (DataManager.Single.Data.inGameData.gameMode == "easy") transform.GetChild(1).gameObject.SetActive(true);
        if (DataManager.Single.Data.inGameData.gameMode == "hard") transform.GetChild(2).gameObject.SetActive(true);
    }
}
