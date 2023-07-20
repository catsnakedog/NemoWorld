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
    /// ��Ų ���� �� ����ó�� �ؾ���
    /// </summary>
    /// <param name="type"></param>
    /// <param name="number"></param>
    void setskin(string type, int number)
    {
        if(transform != null)
        {
            switch (type)
            {
                case "Head":
                    if (number < DataManager.Single.Data.inGameData.itemList.headItem.Count)
                    {
                        DataManager.Single.Data.inGameData.ch.head = DataManager.Single.Data.inGameData.itemList.headItem[number];
                        transform.Find("Head").gameObject.SetActive(true);
                        transform.Find("Head").gameObject.GetComponent<Image>().sprite = MainController.main.resource.head_skin_sprite[DataManager.Single.Data.inGameData.ch.head];
                    }
                    return;
                case "Cloth":
                    if (number < DataManager.Single.Data.inGameData.itemList.clothItem.Count)
                    {
                        DataManager.Single.Data.inGameData.ch.cloth = DataManager.Single.Data.inGameData.itemList.clothItem[number];
                        transform.Find("Cloth").gameObject.SetActive(true);
                        transform.Find("Cloth").gameObject.GetComponent<Image>().sprite = MainController.main.resource.cloth_skin_sprite[DataManager.Single.Data.inGameData.ch.cloth];
                    }
                    return;
                case "Wing":
                    if (number < DataManager.Single.Data.inGameData.itemList.wingItem.Count)
                    {
                        DataManager.Single.Data.inGameData.ch.wing = DataManager.Single.Data.inGameData.itemList.wingItem[number];
                        transform.Find("Wing").gameObject.SetActive(true);
                        transform.Find("Wing").gameObject.GetComponent<Image>().sprite = MainController.main.resource.wing_skin_sprite[DataManager.Single.Data.inGameData.ch.wing];
                    }
                    return;
            }
        }
    }

    private void OnDestroy()
    {
        SetSkin -= (str, num) => setskin(str, num);
    }
}
