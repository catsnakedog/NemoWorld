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

        if (DataManager.Single.Data.inGameData.gameMode == "easy")
        {
            GameObject temp = Instantiate(map[0], new Vector3(size, 0f, 0f), Quaternion.identity);
            temp.transform.SetParent(GameObject.FindWithTag("Map").transform, false);
            temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().CompressBounds();
            size += temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().size.x;

            temp = Instantiate(map[1], new Vector3(size, 0f, 0f), Quaternion.identity);
            temp.transform.SetParent(GameObject.FindWithTag("Map").transform, false);
            temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().CompressBounds();
            size += temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().size.x;

            temp = Instantiate(map[2], new Vector3(size, 0f, 0f), Quaternion.identity);
            temp.transform.SetParent(GameObject.FindWithTag("Map").transform, false);
            temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().CompressBounds();
        }
        else if (DataManager.Single.Data.inGameData.gameMode == "hard")
        {
            List<int> mapList = DataManager.Single.Data.inGameData.mapList;
            GameObject temp = Instantiate(map[0], new Vector3(size, 0f, 0f), Quaternion.identity);
            temp.transform.SetParent(GameObject.FindWithTag("Map").transform, false);
            temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().CompressBounds();
            size += temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().size.x;
            for (int i = 0; i < 2; i++)
            {
                temp = Instantiate(map[mapList[i]], new Vector3(size, 0f, 0f), Quaternion.identity);
                temp.transform.SetParent(GameObject.FindWithTag("Map").transform, false);
                temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().CompressBounds();
                size += temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().size.x;
            }
            temp = Instantiate(map[4], new Vector3(size, 0f, 0f), Quaternion.identity);
            temp.transform.SetParent(GameObject.FindWithTag("Map").transform, false);
            temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().CompressBounds();
            size += temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().size.x;
        }
        else if (DataManager.Single.Data.inGameData.gameMode == "rank")
        {
            DataManager.Single.Data.inGameData.crruentQuest.stage = 1;
            DataManager.Single.Data.inGameData.crruentQuest.gameMode = "rank";
            DataManager.Single.Data.inGameData.crruentQuest.info = "랭크 모드입니다";
            DataManager.Single.Data.inGameData.crruentQuest.time = 190;

            List<int> mapList = DataManager.Single.Data.inGameData.mapList;
            GameObject temp = Instantiate(map[0], new Vector3(size, 0f, 0f), Quaternion.identity);
            temp.transform.SetParent(GameObject.FindWithTag("Map").transform, false);
            temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().CompressBounds();
            size += temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().size.x;
            for (int i = 0; i < 2; i++)
            {
                temp = Instantiate(map[mapList[i]], new Vector3(size, 0f, 0f), Quaternion.identity);
                temp.transform.SetParent(GameObject.FindWithTag("Map").transform, false);
                temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().CompressBounds();
                size += temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().size.x;
            }
            temp = Instantiate(map[13], new Vector3(size, 0f, 0f), Quaternion.identity);
            temp.transform.SetParent(GameObject.FindWithTag("Map").transform, false);
            temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().CompressBounds();
            size += temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().size.x;
        }

        DataManager.Single.Data.inGameData.maxX = size;
    }

    void MapTypeSetting()
    {
        if (DataManager.Single.Data.inGameData.gameMode == "easy")
        {
            map = new List<GameObject>();
            for (int i = 0; i < (int)Define.easyMap.MaxCount; i++)
            {
                map.Add(Resources.Load<GameObject>("Prefabs/Map/Easy/Stage" + DataManager.Single.Data.inGameData.crruentQuest.stage.ToString() + "/" + Enum.GetName(typeof(Define.easyMap), i)));
            }
        }
        else if (DataManager.Single.Data.inGameData.gameMode == "hard")
        {
            map = new List<GameObject>();
            for (int i = 0; i < (int)Define.hardMap.MaxCount; i++)
            {
                map.Add(Resources.Load<GameObject>("Prefabs/Map/Hard/Stage" + DataManager.Single.Data.inGameData.crruentQuest.stage.ToString() + "/" + Enum.GetName(typeof(Define.hardMap), i)));
            }
        }
        else if (DataManager.Single.Data.inGameData.gameMode == "rank")
        {
            map = new List<GameObject>();
            for (int i = 0; i < (int)Define.rankingMap.MaxCount; i++)
            {
                map.Add(Resources.Load<GameObject>("Prefabs/Map/Ranking/" + Enum.GetName(typeof(Define.rankingMap), i)));
            }
        }

        MapSetting();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");
        DataManager.Single.Data.inGameData.ObjList.Clear();

        QuestInfoTextSet();
        GameObject ch = Instantiate(MainController.main.resource.ch, new Vector3(-5.5f, -0.5f, 0f), Quaternion.identity);
        ch.transform.SetParent(GameObject.FindWithTag("Ch").transform, false);
        MainController.main.UI.UIsetting(Define.UIlevel.Level1, Define.UItype.InGameBG);
        MainController.main.UI.UIsetting(Define.UIlevel.Level2, Define.UItype.InGameUI);
        MapTypeSetting();
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