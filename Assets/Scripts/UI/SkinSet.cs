using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SkinSet : MonoBehaviour
{
    public static Action<string, int> SetSkin;

    private void Awake()
    {
        SetSkin += (str, num) => setskin(str, num);
    }
    
    /// <summary>
    /// 스킨 없을 때 예외처리 해야함
    /// </summary>
    /// <param name="type"></param>
    /// <param name="number"></param>
    void setskin(string type, int number)
    {
        switch (type)
        {
            case "Head":
                if (number < DataManager.Single.Data.inGameData.itemList.headItem.Count)
                {
                    DataManager.Single.Data.inGameData.ch.head = DataManager.Single.Data.inGameData.itemList.headItem[number];
                    transform.FindChild("Head").gameObject.SetActive(true);
                    transform.FindChild("Head").gameObject.GetComponent<Image>().sprite = MainController.main.resource.head_skin_sprite[DataManager.Single.Data.inGameData.ch.head];
                }
                return;
            case "Cloth":
                if (number < DataManager.Single.Data.inGameData.itemList.clothItem.Count)
                {
                    DataManager.Single.Data.inGameData.ch.cloth = DataManager.Single.Data.inGameData.itemList.clothItem[number];
                    transform.FindChild("Cloth").gameObject.SetActive(true);
                    transform.FindChild("Cloth").gameObject.GetComponent<Image>().sprite = MainController.main.resource.cloth_skin_sprite[DataManager.Single.Data.inGameData.ch.cloth];
                }
                return;
            case "Wing":
                if (number < DataManager.Single.Data.inGameData.itemList.wingItem.Count)
                {
                    DataManager.Single.Data.inGameData.ch.wing = DataManager.Single.Data.inGameData.itemList.wingItem[number];
                    transform.FindChild("Wing").gameObject.SetActive(true);
                    transform.FindChild("Wing").gameObject.GetComponent<Image>().sprite = MainController.main.resource.wing_skin_sprite[DataManager.Single.Data.inGameData.ch.wing];
                }
                return;
        }
    }

}
