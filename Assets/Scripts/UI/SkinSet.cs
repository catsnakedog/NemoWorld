using System;
using UnityEngine;
using UnityEngine.UI;

public class SkinSet : MonoBehaviour
{
    public static Action<string, string> UISet;
    GameObject head, cloth, wing;

    private void Awake()
    {
        head = transform.Find("Head").gameObject;
        cloth = transform.Find("Cloth").gameObject;
        wing = transform.Find("Wing").gameObject;

        UISet += skin_change_set;
    }

    void skin_change_set(string type, string skin)
    {
        switch (type)
        {
            case "Head":
                DataManager.Single.Data.inGameData.ch.head = skin;
                break;
            case "Cloth":
                DataManager.Single.Data.inGameData.ch.cloth = skin;
                break;
            case "Wing":
                DataManager.Single.Data.inGameData.ch.wing = skin;
                break;
        }

        if (!skin.Equals(""))
        {
            switch (type)
            {
                case "Head": 
                    head.SetActive(true);
                    head.GetComponent<Image>().sprite = MainController.main.resource.head_skin_sprite[DataManager.Single.Data.inGameData.ch.head];
                    return;
                case "Cloth":
                    cloth.SetActive(true);
                    cloth.GetComponent<Image>().sprite = MainController.main.resource.cloth_skin_sprite[DataManager.Single.Data.inGameData.ch.cloth];
                    return;
                case "Wing":
                    wing.SetActive(true);
                    wing.GetComponent<Image>().sprite = MainController.main.resource.wing_skin_sprite[DataManager.Single.Data.inGameData.ch.wing];
                    return;
            };
        }
        else
        {
            switch (type)
            {
                case "Head":
                    head.SetActive(false);
                    return;
                case "Cloth":
                    cloth.SetActive(false);
                    return;
                case "Wing":
                    wing.SetActive(false);
                    return;
            }
        }
    }

    private void OnDestroy()
    {
        UISet -= skin_change_set;
    }
}
