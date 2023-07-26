using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstStory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(1).GetComponent<Image>().sprite = MainController.main.resource.sprite["StoryHelp" + DataManager.Single.Data.inGameData.crruentQuest.stage];
    }
}
