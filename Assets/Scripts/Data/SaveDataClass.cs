using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using System.Runtime.InteropServices;

[System.Serializable]
public class SaveDataClass
{
    public bool isFirst;
    public InGameData inGameData;
    public OptionData optionData;
    public QuestData questData;
    public TimeData timeData;
    public MissionData missionData;
    public SaveDataClass(bool isFirst,InGameData inGameData, OptionData optionData, QuestData questData, TimeData timeData, MissionData missionData)
    {
        this.isFirst = isFirst;
        this.inGameData = inGameData;
        this.optionData = optionData;
        this.questData = questData;
        this.timeData = timeData;
        this.missionData = missionData;
    }
    public SaveDataClass()
    {
        isFirst = false;
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
    public Cost cost; // 재화 관련
    public ItemList itemList;
    public Ch ch;//캐릭터 스킨 착장
    public List<string> storyClearList;
    public List<string> adventureClearList;
    public List<string> missionClearList;
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
    public int coinGetAmount;
    public InGameItem inGameItem; // 도전모드 아이템 관련
    public List<GameObject> ObjList;
    public bool isRedItem;
    public bool isGreenItem;
    public List<int> beforeMapList;
    public bool isFirst;
    public string name;

    public InGameData(Cost cost, ItemList itemList, Ch ch, List<string> storyClearList, List<string> adventureClearList, List<string> missionClearList, int stage, string gameMode, Dictionary<int, int> adventureModeHighScore, QuestInfo crruentQuest, float speed, string color, bool isGod, bool isPurple, bool isShield, int jumpMaxCount, List<int> mapList, string result, int fever, string cutToonName, bool isFever, bool isHit, int coinGetAmount, InGameItem inGameItem, List<GameObject> objList, bool isRedItem, bool isGreenItem, List<int> beforeMapList, bool isFirst, string name)
    {
        this.cost = cost;
        this.itemList = itemList;
        this.ch = ch;
        this.storyClearList = storyClearList;
        this.adventureClearList = adventureClearList;
        this.missionClearList = missionClearList;
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
        this.coinGetAmount = coinGetAmount;
        this.inGameItem = inGameItem;
        ObjList = objList;
        this.isRedItem = isRedItem;
        this.isGreenItem = isGreenItem;
        this.beforeMapList = beforeMapList;
        this.isFirst = isFirst;
        this.name = name;
    }

    public InGameData()
    {
        cost = new Cost();
        itemList = new ItemList();
        ch = new Ch();
        storyClearList = new List<string>();
        adventureClearList = new List<string>();
        missionClearList = new List<string>();
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
        coinGetAmount = 0;
        inGameItem = new InGameItem();
        ObjList = new List<GameObject>();
        isRedItem = false;
        isGreenItem = false;
        beforeMapList = new List<int>();
        isFirst = true;
        name = "";
    }
}

[System.Serializable]
public class InGameItem
{
    public bool shieldItem;
    public bool saveItem;
    public bool coinItem;
    public bool timeItem;
    public float goldIncreaseAmount;
    public bool isUseShieldItem;
    public bool isUseSaveItem;
    public bool isUseCoinItem;
    public bool isUseTimeItem;
    public int shieldItemAmount; // 플레이어가 보유중인 아이템 갯수
    public int saveItemAmount; // 플레이어가 보유중인 아이템 갯수
    public int coinItemAmount; // 플레이어가 보유중인 아이템 갯수
    public int timeItemAmount; // 플레이어가 보유중인 아이템 갯수

    public InGameItem(bool shieldItem, bool saveItem, bool coinItem, bool timeItem, float goldIncreaseAmount, bool isUseShieldItem, bool isUseSaveItem, bool isUseCoinItem, bool isUseTimeItem,int shieldItemAmount, int saveItemAmount, int coinItemAmount, int timeItemAmount)
    {
        this.shieldItem = shieldItem;
        this.saveItem = saveItem;
        this.coinItem = coinItem;
        this.timeItem = timeItem;
        this.goldIncreaseAmount = goldIncreaseAmount;
        this.isUseShieldItem = isUseShieldItem;
        this.isUseSaveItem = isUseSaveItem;
        this.isUseCoinItem = isUseCoinItem;
        this.isUseTimeItem = isUseTimeItem;
        this.shieldItemAmount = shieldItemAmount;
        this.saveItemAmount = saveItemAmount;
        this.coinItemAmount = coinItemAmount;
        this.timeItemAmount = timeItemAmount;
    }

    public InGameItem()
    {
        shieldItem = false;
        saveItem = false;
        coinItem = false;
        timeItem = false;
        goldIncreaseAmount = 0.4f;
        isUseShieldItem = false;
        isUseSaveItem = false;
        isUseCoinItem = false;
        isUseTimeItem = false;
        shieldItemAmount = 0;
        saveItemAmount = 0;
        coinItemAmount = 0;
        timeItemAmount = 0;
    }
}

[System.Serializable]
public class Cost
{
    public int gold; // 골드
    public int energy; // 에너지
    public int hatGacha; // 여기서부터는 마음대로 수정하셔서 사용하시면 됩니다.
    public int clothGacha;
    public int wingGacha;
    public int gachaPiece;

    public Cost(int gold, int energy, int hatGacha, int clothGacha, int wingGacha, int gachaPiece)
    {
        this.gold = gold;
        this.energy = energy;
        this.hatGacha = hatGacha;
        this.clothGacha = clothGacha;
        this.wingGacha = wingGacha;
        this.gachaPiece = gachaPiece;
    }

    public Cost()
    {
        gold = 0;
        energy = 0;
        hatGacha = 0;
        clothGacha = 0;
        wingGacha = 0;
        gachaPiece = 0;
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
    public bool muteBGM;
    public bool muteSFX;

    public OptionData( float volumeBGM, float volumeSFX, bool muteBGM, bool muteSFX)
    {
        this.volumeBGM = volumeBGM;
        this.volumeSFX = volumeSFX;
        this.muteBGM = muteBGM;
        this.muteSFX = muteSFX;
    }

    public OptionData()
    {
        volumeBGM = 0f;
        volumeSFX = 0f;
        muteBGM = false;
        muteSFX = false;
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
        this.beforeTime = "2023 - 07 - 13 PM 10:30:47";
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