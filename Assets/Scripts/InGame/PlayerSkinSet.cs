using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinSet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!DataManager.Single.Data.inGameData.ch.head.Equals(""))
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = MainController.main.resource.head_skin_sprite[DataManager.Single.Data.inGameData.ch.head];
        }
        if (!DataManager.Single.Data.inGameData.ch.cloth.Equals(""))
        {
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = MainController.main.resource.cloth_skin_sprite[DataManager.Single.Data.inGameData.ch.cloth];
        }
        if (!DataManager.Single.Data.inGameData.ch.wing.Equals(""))
        {
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = MainController.main.resource.wing_skin_sprite[DataManager.Single.Data.inGameData.ch.wing];
        }
    }
}
