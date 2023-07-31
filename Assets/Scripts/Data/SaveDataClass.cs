using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

[System.Serializable]
public class SaveDataClass
{
    public bool isFirst;
    public InGameData inGameData;
    public OptionData optionData;
    public QuestData questData;
    public TimeData timeData;
    public MissionData missionData;
    public RankingData rankingData;


    public SaveDataClass(bool isFirst,InGameData inGameData, OptionData optionData, QuestData questData, TimeData timeData, MissionData missionData, RankingData rankingData)
    {
        this.isFirst = isFirst;
        this.inGameData = inGameData;
        this.optionData = optionData;
        this.questData = questData;
        this.timeData = timeData;
        this.missionData = missionData;
        this.rankingData = rankingData;
    }
    public SaveDataClass()
    {
        isFirst = false;
        inGameData = new InGameData();
        optionData = new OptionData();
        questData = new QuestData();
        timeData = new TimeData();
        missionData = new MissionData();
        rankingData = new RankingData();
    }
}

#region InGameData

[System.Serializable]
public class InGameData
{
    public int playerNumber;
    public int score;
    public Cost cost; // 재화 관련
    public ItemList itemList;//보유 스킨
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
    public List<MapObj> mapObj;
    public bool isRedItem;
    public bool isGreenItem;
    public List<int> beforeMapList;
    public bool isFirst;
    public string name;
    public float maxX;
    public float moveAmount;
    public bool isTimeUp;
    public bool isTimeDown;
    public bool isItem;
    public bool isRankAward;
    public bool isFirstStage1;
    public bool isFirstStage2;
    public bool isFirstStage3;

    public InGameData(Cost cost, ItemList itemList, Ch ch, List<string> storyClearList, List<string> adventureClearList, List<string> missionClearList, int stage, string gameMode, Dictionary<int, int> adventureModeHighScore, QuestInfo crruentQuest, float speed, string color, bool isGod, bool isPurple, bool isShield, int jumpMaxCount, List<int> mapList, string result, int fever, string cutToonName, bool isFever, bool isHit, int coinGetAmount, InGameItem inGameItem, List<MapObj> mapObj, bool isRedItem, bool isGreenItem, List<int> beforeMapList, bool isFirst, string name, float maxX, float moveAmount, bool isTImeUp, bool isTimeDown, bool isItem, int playerNumber,bool isRankAward, bool isFirstStage1, bool isFirstStage2, bool isFirstStage3)
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
        this.mapObj = mapObj;
        this.isRedItem = isRedItem;
        this.isGreenItem = isGreenItem;
        this.beforeMapList = beforeMapList;
        this.isFirst = isFirst;
        this.name = name;
        this.maxX = maxX;
        this.moveAmount = moveAmount;
        this.isTimeUp = isTImeUp;
        this.isTimeDown = isTimeDown;
        this.isItem = isItem;
        this.playerNumber = playerNumber;
        this.isRankAward = isRankAward;
        this.isFirstStage1 = isFirstStage1;
        this.isFirstStage2 = isFirstStage2;
        this.isFirstStage3 = isFirstStage3;
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
        mapObj = new List<MapObj>();
        isRedItem = false;
        isGreenItem = false;
        beforeMapList = new List<int>();
        isFirst = true;
        name = "";
        maxX = 0;
        moveAmount = 0;
        isTimeUp = false;
        isTimeDown = false;
        isItem = false;
        playerNumber = 0;
        isRankAward = false;
        isFirstStage1 = true;
        isFirstStage2 = true;
        isFirstStage3 = true;
    }
}

[System.Serializable]
public class MapObj
{
    public float x;
    public GameObject map;

    public MapObj(float x, GameObject map)
    {
        this.x = x;
        this.map = map;
    }

    public MapObj()
    {
        x = 0;
        map = null;
    }
}


[System.Serializable]
public class InGameItem
{
    public bool shieldItem;
    public bool saveItem;
    public bool coinItem;
    public bool timeItem;
    public bool boostItem;
    public float goldIncreaseAmount;
    public bool isUseShieldItem;
    public bool isUseSaveItem;
    public bool isUseCoinItem;
    public bool isUseTimeItem;
    public bool isUseBoostItem;
    public int shieldItemAmount; // 플레이어가 보유중인 아이템 갯수
    public int saveItemAmount; // 플레이어가 보유중인 아이템 갯수
    public int coinItemAmount; // 플레이어가 보유중인 아이템 갯수
    public int timeItemAmount; // 플레이어가 보유중인 아이템 갯수
    public int boostItemAmount;

    public InGameItem(bool shieldItem, bool saveItem, bool coinItem, bool timeItem, float goldIncreaseAmount, bool isUseShieldItem, bool isUseSaveItem, bool isUseCoinItem, bool isUseTimeItem,int shieldItemAmount, int saveItemAmount, int coinItemAmount, int timeItemAmount, bool boostItem, bool isUseBoostItem, int boostItemAmount)
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
        this.boostItem = boostItem;
        this.isUseBoostItem = isUseBoostItem;
        this.boostItemAmount = boostItemAmount;
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
        boostItem = false;
        isUseBoostItem = false;
        isUseTimeItem = false;
    }
}

[System.Serializable]
public class Cost
{
    public int gold; // 골드
    public int energy; // 에너지
    public int headTicket; // 모자 뽑기권
    public int clothTicket; // 옷 뽑기권
    public int wingTicket; // 날개 뽑기권
    public int gachaPiece; // 뽑기권 조각

    public Cost(int gold, int energy, int headTicket, int clothTicket, int wingTicket, int gachaPiece)
    {
        this.gold = gold;
        this.energy = energy;
        this.headTicket = headTicket;
        this.clothTicket = clothTicket;
        this.wingTicket = wingTicket;
        this.gachaPiece = gachaPiece;
    }

    public Cost()
    {
        gold = 0;
        energy = 0;
        headTicket = 0;
        clothTicket = 0;
        wingTicket = 0;
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
    public int lastWeek;

    public TimeData(string beforeTime, string crruentTime, int lastWeek)
    {
        this.beforeTime = beforeTime;
        this.crruentTime = crruentTime;
        this.lastWeek = lastWeek;
    }

    public TimeData()
    {
        this.beforeTime = "2023 - 07 - 13 PM 10:30:47";
        this.crruentTime = "";
        lastWeek = 1;
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

#region RankingData

[System.Serializable]
public class RankingData
{
    public List<RankInfo> rankInfo = new List<RankInfo>();
    public int rank;
    public int awardType;
    public RankInfo playerRank;

    public RankingData(List<RankInfo> rankInfo, int rank, RankInfo playerRank, int awardType)
    {
        this.rankInfo = rankInfo;
        this.rank = rank;
        this.playerRank = playerRank;
        this.awardType = awardType;
    }

    public RankingData()
    {
        rankInfo = new List<RankInfo>();
        rank = 0;
        playerRank = new RankInfo();
        awardType = 0;
    }
}

[System.Serializable]
public class RankInfo
{
    public string name;
    public string score;

    public RankInfo(string name, string score)
    {
        this.name = name;
        this.score = score;
    }

    public RankInfo()
    {
        name = "";
        score = "";
    }
}

#endregion