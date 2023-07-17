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

    public enum easyMap
    {
        Start,
        Stage,
        End,
        MaxCount
    }

    public enum hardMap
    {
        Start,
        Part1,
        Part2,
        Part3,
        Part4,
        End,
        MaxCount
    }

    public enum SpriteDict
    {
        HeadTest1,
        ClothTest1,
        WingTest1,
        diePlayer,
        clearPlayer,
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
        EffectRed,
        EffectOrange,
        EffectYellow,
        EffectGreen,
        EffectBlue,
        EffectNavy,
        EffectPurple,
        EffectFever,
        EffectSaw,
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

    /// <summary>
    /// TODO : 가격에 따라 분류
    /// </summary>
    public enum Head
    {
        Crown,
        PinkFlower,
        Wizard,
        YellowFlower
    }
    public enum Cloth
    {
        Angel,
        General,
        Straw,
        Wizard
    }
    public enum Wing
    {
        Angel,
        BlueButterfly,
        Butterfly,
        General,
        PinkAngel,
        PinkButterfly,
        PurpleButterfly
    }
}