using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using static Define;

public class StoryStartBtn : EventTriggerEX
{
    [SerializeField]
    List<GameObject> map;

    protected void Start()
    {
        init();
    }

    void MapTypeSetting()
    {
        map = new List<GameObject>();
        for (int i = 0; i < (int)Define.easyMap.MaxCount; i++)
        {
            map.Add(Resources.Load<GameObject>("Prefabs/Map/Easy/Stage" + DataManager.Single.Data.inGameData.crruentQuest.stage.ToString() + "/" + Enum.GetName(typeof(Define.easyMap), i)));
        }
        MapSetting();
    }

    void MapSetting()
    {
        int size = 0;
        GameObject temp = Instantiate(map[0], new Vector3(size, 0f, 0f), Quaternion.identity);
        temp.transform.SetParent(GameObject.FindWithTag("Map").transform, false);
        temp.AddComponent<MapMove>();
        temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().CompressBounds();
        size += temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().size.x;

        temp = Instantiate(map[1], new Vector3(size, 0f, 0f), Quaternion.identity);
        temp.transform.SetParent(GameObject.FindWithTag("Map").transform, false);
        temp.AddComponent<MapMove>();
        temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().CompressBounds();
        size += temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().size.x;

        temp = Instantiate(map[2], new Vector3(size, 0f, 0f), Quaternion.identity);
        temp.transform.SetParent(GameObject.FindWithTag("Map").transform, false);
        temp.AddComponent<MapMove>();
        temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().CompressBounds();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        if (DataManager.Single.Data.inGameData.cost.energy <= 0)
        {
            // 에너지 부족!
            return;
        }

        if (DataManager.Single.Data.inGameData.inGameItem.isUseShieldItem)
            DataManager.Single.Data.inGameData.inGameItem.shieldItemAmount--;
        if (DataManager.Single.Data.inGameData.inGameItem.isUseSaveItem)
            DataManager.Single.Data.inGameData.inGameItem.saveItemAmount--;
        if (DataManager.Single.Data.inGameData.inGameItem.isUseCoinItem)
            DataManager.Single.Data.inGameData.inGameItem.coinItemAmount--;
        if (DataManager.Single.Data.inGameData.inGameItem.isUseTimeItem)
            DataManager.Single.Data.inGameData.inGameItem.timeItemAmount--;

        DataManager.Single.Data.inGameData.ObjList.Clear();

        DataManager.Single.Data.inGameData.cost.energy--;

        GameObject ch = Instantiate(MainController.main.resource.ch, new Vector3(-5.5f, -0.5f, 0f), Quaternion.identity);
        ch.transform.SetParent(GameObject.FindWithTag("Ch").transform, false);

        MapTypeSetting();
        MainController.main.UI.UIsetting(Define.UIlevel.Level1, Define.UItype.InGameBG);
        MainController.main.UI.UIsetting(Define.UIlevel.Level2, Define.UItype.InGameUI);
    }
}
