using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartSetting : MonoBehaviour
{
    void Start()
    {
        if (DataManager.Single.Data.inGameData.gameMode == "hard")
            transform.GetChild(0).gameObject.AddComponent<AdventureStartBtn>();
        if (DataManager.Single.Data.inGameData.gameMode == "easy")
            transform.GetChild(0).gameObject.AddComponent<StoryStartBtn>();
    }
}
