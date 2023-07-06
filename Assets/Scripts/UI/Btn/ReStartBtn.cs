using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class ReStartBtn : EventTriggerEX
{
    [SerializeField]
    List<GameObject> map;
    private void Start()
    {
        init();
    }

    void MapSetting()
    {
        int size;
        size = 0;

        List<int> mapList = DataManager.Single.Data.inGameData.mapList;
        GameObject temp = Instantiate(map[0], new Vector3(size, 0f, 0f), Quaternion.identity);
        temp.transform.SetParent(GameObject.FindWithTag("Map").transform, false);
        temp.AddComponent<MapMove>();
        size += temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().size.x;
        for (int i = 0; i < 3; i++)
        {
            temp = Instantiate(map[mapList[i]], new Vector3(size, 0f, 0f), Quaternion.identity);
            temp.transform.SetParent(GameObject.FindWithTag("Map").transform, false);
            temp.AddComponent<MapMove>();
            size += temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().size.x;
        }
        temp = Instantiate(map[4], new Vector3(size, 0f, 0f), Quaternion.identity);
        temp.transform.SetParent(GameObject.FindWithTag("Map").transform, false);
        temp.AddComponent<MapMove>();
        size += temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().size.x;
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
        QuestInfoTextSet();
        if(DataManager.Single.Data.inGameData.gameMode == "easy")
        {
            GameObject temp = Instantiate(MainController.main.resource.Map[DataManager.Single.Data.inGameData.crruentQuest.stage - 1], new Vector3(0f, 0f, 0f), Quaternion.identity);
            temp.transform.SetParent(GameObject.FindWithTag("Map").transform, false);
            temp.AddComponent<MapMove>();
            GameObject ch = Instantiate(MainController.main.resource.ch, new Vector3(-5.5f, -0.5f, 0f), Quaternion.identity);
            ch.transform.SetParent(GameObject.FindWithTag("Ch").transform, false);
            MainController.main.UI.UIsetting(Define.UIlevel.Level1, Define.UItype.InGameBG);
            MainController.main.UI.UIsetting(Define.UIlevel.Level2, Define.UItype.InGameUI);
        }
        else
        {
            GameObject ch = Instantiate(MainController.main.resource.ch, new Vector3(-5.5f, -0.5f, 0f), Quaternion.identity);
            ch.transform.SetParent(GameObject.FindWithTag("Ch").transform, false);
            MainController.main.UI.UIsetting(Define.UIlevel.Level1, Define.UItype.InGameBG);
            MainController.main.UI.UIsetting(Define.UIlevel.Level2, Define.UItype.InGameUI);
            MapTypeSetting();
        }
    }

    void QuestInfoTextSet()
    {
        string info = "error";
        for (int i = 0; i < DataManager.Single.Data.questData.questInfo.Count; i++)
        {
            if (DataManager.Single.Data.questData.questInfo[i].stage == DataManager.Single.Data.inGameData.stage)
            {
                if (DataManager.Single.Data.questData.questInfo[i].gameMode == DataManager.Single.Data.inGameData.gameMode)
                {
                    QuestCopy(i);
                    break;
                }
            }
        }
    }

    void QuestCopy(int i)
    {
        DataManager.Single.Data.inGameData.crruentQuest.stage = DataManager.Single.Data.questData.questInfo[i].stage;
        DataManager.Single.Data.inGameData.crruentQuest.gameMode = DataManager.Single.Data.questData.questInfo[i].gameMode;
        DataManager.Single.Data.inGameData.crruentQuest.info = DataManager.Single.Data.questData.questInfo[i].info;
        DataManager.Single.Data.inGameData.crruentQuest.time = DataManager.Single.Data.questData.questInfo[i].time;
    }
}