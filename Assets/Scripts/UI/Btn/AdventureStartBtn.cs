using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class AdventureStartBtn : EventTriggerEX
{
    [SerializeField]
    List<GameObject> map;

    [SerializeField]
    int mapNumber;
    private void Start()
    {
        init();
    }

    void MapSetting()
    {
        int size;
        size = 0;

        List<int> partList = new List<int>() { 1, 2, 3 };
        List<int> mapList = new List<int>();

        /*
        for (int i = 0; i < 3; i++)
        {
            int randomNum = UnityEngine.Random.Range(0, partList.Count);
            mapList.Add(partList[randomNum]);
            partList.RemoveAt(randomNum);
        }
        */ // 일단 테스트를 위해서 비활성화 (맵 랜덤리스트 생성 부분)

        mapList.Add(mapNumber);
        mapList.Add(mapNumber);
        mapList.Add(mapNumber);

        GameObject temp = Instantiate(map[0], new Vector3(size, 0f, 0f), Quaternion.identity);
        temp.transform.SetParent(GameObject.FindWithTag("Map").transform, false);
        temp.AddComponent<MapMove>();
        temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().CompressBounds();
        size += temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().size.x;
        for (int i = 0; i < 3; i++)
        {
            temp = Instantiate(map[mapList[i]], new Vector3(size, 0f, 0f), Quaternion.identity);
            temp.transform.SetParent(GameObject.FindWithTag("Map").transform, false);
            temp.AddComponent<MapMove>();
            temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().CompressBounds();
            size += temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().size.x;
        }
        temp = Instantiate(map[4], new Vector3(size, 0f, 0f), Quaternion.identity);
        temp.transform.SetParent(GameObject.FindWithTag("Map").transform, false);
        temp.AddComponent<MapMove>();
        temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().CompressBounds();
        size += temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().size.x;

        DataManager.Single.Data.inGameData.mapList = mapList;
    }

    void MapTypeSetting()
    {
        map = new List<GameObject>();
        for (int i = 0; i < (int)Define.hardMap.MaxCount; i++)
        {
            map.Add(Resources.Load<GameObject>("Prefabs/Map/Hard/Stage" + DataManager.Single.Data.inGameData.crruentQuest.stage.ToString() + "/" + Enum.GetName(typeof(Define.hardMap), i)));
        }
        MapSetting();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MapTypeSetting();
        GameObject ch = Instantiate(MainController.main.resource.ch, new Vector3(-5.5f, -0.5f, 0f), Quaternion.identity);
        ch.transform.SetParent(GameObject.FindWithTag("Ch").transform, false);
        MainController.main.UI.UIsetting(Define.UIlevel.Level1, Define.UItype.InGameBG);
        MainController.main.UI.UIsetting(Define.UIlevel.Level2, Define.UItype.InGameUI);
    }
}