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
        CutToon,
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
        BG2_1,
        BG2_2,
        BG2_3,
        BG2_4,
        BG3_1,
        BG3_2,
        BG3_3,
        BG3_4,
        stage1EasyCutToon,
        stage2EasyCutToon,
        stage3EasyCutToon,
        stage1HardCutToon,
        stage2HardCutToon,
        stage3HardCutToon,
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