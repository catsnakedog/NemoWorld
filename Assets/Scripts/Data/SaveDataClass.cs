using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class SaveDataClass
{
    public InGameData inGameData;
    public OptionData optionData;
    public QuestData questData;
    public SaveDataClass(InGameData inGameData, OptionData optionData, QuestData questData)
    {
        this.inGameData = inGameData;
        this.optionData = optionData;
        this.questData = questData;
    }
    public SaveDataClass()
    {
        inGameData = new InGameData();
        optionData = new OptionData();
        questData = new QuestData();
    }
}

#region InGameData

[System.Serializable]
public class InGameData
{
    public Cost cost;
    public ItemList itemList;
    public Ch ch;
    public List<string> storyClearList;
    public List<string> adventureClearList;
    public int stage;
    public string gameMode;
    public Dictionary<int, int> adventureModeHighScore;
    public QuestInfo crruentQuest;

    public InGameData(Cost cost, ItemList itemList, Ch ch, List<string> storyClearList, List<string> adventureClearList, int stage, string gameMode, Dictionary<int, int> adventureModeHighScore, QuestInfo crruentQuest)
    {
        this.cost = cost;
        this.itemList = itemList;
        this.ch = ch;
        this.storyClearList = storyClearList;
        this.adventureClearList = adventureClearList;
        this.stage = stage;
        this.gameMode = gameMode;
        this.adventureModeHighScore = adventureModeHighScore;
        this.crruentQuest = crruentQuest;
    }

    public InGameData()
    {
        cost = new Cost();
        itemList = new ItemList();
        ch = new Ch();
        storyClearList = new List<string>();
        adventureClearList = new List<string>();
        stage = 0;
        gameMode = "";
        adventureModeHighScore = new Dictionary<int, int>();
        crruentQuest = new QuestInfo();
    }
}

[System.Serializable]
public class Cost
{
    public int gold;
    public int energy;
    public int test1;
    public int test2;

    public Cost(int gold, int energy, int test1, int test2)
    {
        this.gold = gold;
        this.energy = energy;
        this.test1 = test1;
        this.test2 = test2;
    }

    public Cost()
    {
        gold = 0;
        energy = 0;
        test1 = 0;
        test2 = 0;
    }
}

[System.Serializable]
public class ItemList
{
    public List<string> headItem;
    public List<string> clothItem;
    public List<string> wingItem;

    public ItemList(List<string> headItem, List<string> clothItem, List<string> wingItem)
    {
        this.headItem = headItem;
        this.clothItem = clothItem;
        this.wingItem = wingItem;
    }

    public ItemList()
    {
        headItem = new List<string>();
        clothItem = new List<string>();
        wingItem = new List<string>();
    }
}

[System.Serializable]
public class Ch
{
    public string head;
    public string cloth;
    public string wing;

    public Ch(string head, string cloth, string wing)
    {
        this.head = head;
        this.cloth = cloth;
        this.wing = wing;
    }

    public Ch()
    {
        head = "";
        cloth = "";
        wing = "";
    }
}

#endregion

#region OptionData

[System.Serializable]
public class OptionData
{
    public float volumeBGM;
    public float volumeSFX;

    public OptionData( float volumeBGM, float volumeSFX )
    {
        this.volumeBGM = volumeBGM;
        this.volumeSFX = volumeSFX;
    }

    public OptionData()
    {
        volumeBGM = 0f;
        volumeSFX = 0f;
    }
}

#endregion

#region QuestData

[System.Serializable]
public class QuestData
{
    public List<QuestInfo> questInfo;

    public QuestData(List<QuestInfo> questInfo)
    {
        this.questInfo = questInfo;
    }

    public QuestData()
    {
        questInfo = new List<QuestInfo>();
    }
}

[System.Serializable]
public class QuestInfo
{
    public int stage;
    public string gameMode;
    public string info;
    public int type1;
    public int type2;
    public int type3;
    public int type4;
    public int type5;

    public QuestInfo(int stage, string gameMode, string info, int type1, int type2, int type3, int type4, int type5)
    {
        this.stage = stage;
        this.gameMode = gameMode;
        this.info = info;
        this.type1 = type1;
        this.type2 = type2;
        this.type3 = type3;
        this.type4 = type4;
        this.type5 = type4;
    }

    public QuestInfo()
    {
        stage = 0;
        gameMode = "";
        info = "";
        type1 = 0;
        type2 = 0;
        type3 = 0;
        type4 = 0;
        type5 = 0;
    }
}

#endregion