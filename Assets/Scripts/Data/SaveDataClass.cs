using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

[System.Serializable]
public class SaveDataClass
{
    public InGameData inGameData;
    public OptionData optionData;
    public QuestData questData;
    public TimeData timeData;
    public MissionData missionData;
    public SaveDataClass(InGameData inGameData, OptionData optionData, QuestData questData, TimeData timeData, MissionData missionData)
    {
        this.inGameData = inGameData;
        this.optionData = optionData;
        this.questData = questData;
        this.timeData = timeData;
        this.missionData = missionData;
    }
    public SaveDataClass()
    {
        inGameData = new InGameData();
        optionData = new OptionData();
        questData = new QuestData();
        timeData = new TimeData();
        missionData = new MissionData();
    }
}

#region InGameData

[System.Serializable]
public class InGameData
{
    public Cost cost;
    public ItemList itemList;
    public Ch ch;//캐릭터 스킨 착장
    public List<string> storyClearList;
    public List<string> adventureClearList;
    public int stage;
    public string gameMode;
    public Dictionary<int, int> adventureModeHighScore;
    public QuestInfo crruentQuest;
    public float speed;
    public string color;
    public bool isGod;
    public bool isPurple;
    public bool isShield;
    public int jumpMaxCount;
    public List<int> mapList;
    public string result;
    public int fever;
    public string cutToonName;
    public bool isFever;
    public bool isHit;

    public InGameData(Cost cost, ItemList itemList, Ch ch, List<string> storyClearList, List<string> adventureClearList, int stage, string gameMode, Dictionary<int, int> adventureModeHighScore, QuestInfo crruentQuest, float speed, string color, bool isGod, bool isPurple, bool isShield, int jumpMaxCount, List<int> mapList, string result, int fever, string cutToonName, bool isFever, bool isHit)
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
        this.speed = speed;
        this.color = color;
        this.isGod = isGod;
        this.isPurple = isPurple;
        this.isShield = isShield;
        this.jumpMaxCount = jumpMaxCount;
        this.mapList = mapList;
        this.result = result;
        this.fever = fever;
        this.cutToonName = cutToonName;
        this.isFever = isFever;
        this.isHit = isHit;
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
        speed = 0;
        color = "";
        isGod = false;
        isPurple = false;
        isShield = false;
        jumpMaxCount = 2;
        mapList = new List<int>();
        result = "";
        fever = 0;
        cutToonName = "";
        isFever = false;
        isHit = false;
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
    public int time;

    public QuestInfo(int stage, string gameMode, string info, int time)
    {
        this.stage = stage;
        this.gameMode = gameMode;
        this.info = info;
        this.time = time;
    }

    public QuestInfo()
    {
        stage = 0;
        gameMode = "";
        info = "";
        time = 0;
    }
}

#endregion

#region TimeData

[System.Serializable]
public class TimeData
{
    public string beforeTime;
    public string crruentTime;

    public TimeData(string beforeTime, string crruentTime)
    {
        this.beforeTime = beforeTime;
        this.crruentTime = crruentTime;
    }

    public TimeData()
    {
        this.beforeTime = "";
        this.crruentTime = "";
    }
}
#endregion

#region MissionData

[System.Serializable]
public class MissionData
{
    public int jumpCount;
    public int silverCoinCount;
    public int hitCount;

    public MissionData(int jumpCount, int silverCoinCount, int hitCount)
    {
        this.jumpCount = jumpCount;
        this.silverCoinCount = silverCoinCount;
        this.hitCount = hitCount;
    }

    public MissionData()
    {
        jumpCount = 0;
        silverCoinCount = 0;
        hitCount = 0;
    }
}

#endregion