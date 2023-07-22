using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class SkinTypeSelectBtn : EventTriggerEX
{
    [SerializeField]
    string type;
    
    GameObject skin_prefab;

    protected void Start()
    {
        init();

        skin_prefab = Resources.Load<GameObject>("Prefabs/UI/SkinPrefab");

        if (type != "Head") return;

        Debug.Log(skin_prefab);
        Transform parent = GameObject.Find("Content").transform;
        for (int i = -1; i < DataManager.Single.Data.inGameData.itemList.headItem.Count; i++)
        {
            GameObject skin_temp = Instantiate(skin_prefab);
            skin_temp.transform.parent = parent;
            SkinSelectBtn temp;
            temp = skin_temp.AddComponent<SkinSelectBtn>();

            if(i < 0)
            {
                temp.type = "Head";
                temp.SetUI = "";
            }
            else
            {
                temp.type = "Head";
                temp.SetUI = DataManager.Single.Data.inGameData.itemList.headItem[i];
            }
        }
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");

        int cnt = 0;
        GameObject[] skin_transforms = GameObject.FindGameObjectsWithTag("Skin");
        Transform parent = GameObject.Find("Content").transform;

        if (type.Equals("Head")) cnt = DataManager.Single.Data.inGameData.itemList.headItem.Count + 1;
        else if (type.Equals("Cloth")) cnt = DataManager.Single.Data.inGameData.itemList.clothItem.Count + 1;
        else if (type.Equals("Wing")) cnt = DataManager.Single.Data.inGameData.itemList.wingItem.Count + 1;

        skin_transforms[0].GetComponent<SkinSelectBtn>().type = type;

        for (int i = 1; i < cnt; i++)
        {
            SkinSelectBtn temp;

            if (i < skin_transforms.Length)
            {
                temp = skin_transforms[i].GetComponent<SkinSelectBtn>();
            }
            else
            {
                GameObject skin_temp = Instantiate(skin_prefab);
                skin_temp.transform.parent = parent;
                temp = skin_temp.AddComponent<SkinSelectBtn>();
            }

            temp.type = type;
            if (type.Equals("Head")) temp.SetUI = DataManager.Single.Data.inGameData.itemList.headItem[i - 1];
            else if (type.Equals("Cloth")) temp.SetUI = DataManager.Single.Data.inGameData.itemList.clothItem[i - 1];
            else if (type.Equals("Wing")) temp.SetUI = DataManager.Single.Data.inGameData.itemList.wingItem[i - 1];
        }

        if(cnt < skin_transforms.Length)
        {
            for(int i = cnt; i < skin_transforms.Length; i++)
            {
                Destroy(skin_transforms[i]);
            }
        }
    }
}