using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class RankingStartBtn : EventTriggerEX
{
    [SerializeField]
    List<GameObject> map;
    [SerializeField]
    int number;

    private void Start()
    {
        init();
    }

    void MapSetting()
    {
        int size;
        size = 0;

        List<int> partList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        List<int> mapList = new List<int>();

        
        for (int i = 0; i < 2; i++)
        {
            int randomNum = UnityEngine.Random.Range(0, partList.Count);
            mapList.Add(partList[randomNum]);
            partList.RemoveAt(randomNum);
        }
        


        while (DataManager.Single.Data.inGameData.beforeMapList == mapList)
        {
            mapList.Clear();
            for (int i = 0; i < 2; i++)
            {
                int randomNum = UnityEngine.Random.Range(0, partList.Count);
                mapList.Add(partList[randomNum]);
                partList.RemoveAt(randomNum);
            }
        }

        DataManager.Single.Data.inGameData.beforeMapList = mapList;


        MapObj temp2;

        DataManager.Single.Data.inGameData.mapObj.Clear();

        GameObject temp = Instantiate(map[0], new Vector3(size, 0f, 0f), Quaternion.identity);
        temp.transform.SetParent(GameObject.FindWithTag("Map").transform, false);
        temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().CompressBounds();
        size += temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().size.x;
        for (int i = 0; i < 2; i++)
        {
            temp = Instantiate(map[mapList[i]], new Vector3(size, 0f, 0f), Quaternion.identity);
            temp2 = new MapObj(size - 24f, temp);
            DataManager.Single.Data.inGameData.mapObj.Add(temp2);
            temp.transform.SetParent(GameObject.FindWithTag("Map").transform, false);
            temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().CompressBounds();
            size += temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().size.x;
            temp2 = new MapObj(size + 24f, temp);
            DataManager.Single.Data.inGameData.mapObj.Add(temp2);
            temp.SetActive(false);
        }
        temp = Instantiate(map[13], new Vector3(size, 0f, 0f), Quaternion.identity);
        temp2 = new MapObj(size - 24f, temp);
        DataManager.Single.Data.inGameData.mapObj.Add(temp2);
        temp.transform.SetParent(GameObject.FindWithTag("Map").transform, false);
        temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().CompressBounds();
        size += temp.transform.GetChild(0).GetChild(0).GetComponent<Tilemap>().size.x;
        temp2 = new MapObj(size + 24f, temp);
        DataManager.Single.Data.inGameData.mapObj.Add(temp2);
        temp.SetActive(false);

        DataManager.Single.Data.inGameData.maxX = size;
        DataManager.Single.Data.inGameData.mapList = mapList;
    }

    void MapTypeSetting()
    {
        map = new List<GameObject>();
        for (int i = 0; i < (int)Define.rankingMap.MaxCount; i++)
        {
            map.Add(Resources.Load<GameObject>("Prefabs/Map/Ranking/" + Enum.GetName(typeof(Define.rankingMap), i)));
        }
        MapSetting();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        DataManager.Single.Data.inGameData.crruentQuest.stage = 1;
        DataManager.Single.Data.inGameData.crruentQuest.gameMode = "rank";
        DataManager.Single.Data.inGameData.crruentQuest.info = "랭크 모드입니다";
        DataManager.Single.Data.inGameData.crruentQuest.time = 150;

        MainController.main.sound.Play("buttonSFX");
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
        if (DataManager.Single.Data.inGameData.inGameItem.isUseBoostItem)
            DataManager.Single.Data.inGameData.inGameItem.boostItemAmount--;

        DataManager.Single.Data.inGameData.cost.energy--;
        GameObject ch = Instantiate(MainController.main.resource.ch, new Vector3(-5.5f, -0.5f, 0f), Quaternion.identity);
        ch.transform.SetParent(GameObject.FindWithTag("Ch").transform, false);
        MapTypeSetting();
        MainController.main.UI.UIsetting(Define.UIlevel.Level1, Define.UItype.InGameBG);
        MainController.main.UI.UIsetting(Define.UIlevel.Level2, Define.UItype.InGameUI);
        MainController.main.sound.Play("adventureBGM");
    }
}