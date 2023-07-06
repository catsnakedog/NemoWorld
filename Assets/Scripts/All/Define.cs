using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum UIlevel
    {
        Level1,
        Level2,
        Level3,
        MaxCount 
    }

    public enum UItype
    {
        MainLobby,
        Option,
        Help,
        Story,
        Adventure,
        Skin,
        StorySelect,
        InGameUI,
        InGameBG,
        Pause,
        Gacha,
        Shop,
        GameResult,
        MaxCount
    }

    public enum Map
    {
        Stage1,
        Stage2,
        Stage3,
        MaxCount
    }

    public enum hardMap
    {
        Start,
        Part1,
        Part2,
        Part3,
        End,
        MaxCount
    }

    public enum SpriteDict
    {
        HeadTest1,
        ClothTest1,
        WingTest1,
        BG1_1,
        BG1_2,
        BG1_3,
        BG1_4,
        MaxCount
    }

    public enum BGM
    {
        MaxCount
    }

    public enum SFX
    {
        MaxCount
    }

    public enum PlayerAnim
    {
        Blink,
        Run,
        Jump,
        CoinGet,
        Hit
    }
}