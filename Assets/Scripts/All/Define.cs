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
        FirstUI,
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
        Up,
        Down,
        MaxCount
    }

    public enum BGM
    {
        storyBGM,
        mainBGM,
        rankingBGM,
        adventureBGM,
        MaxCount
    }

    public enum SFX
    {
        buttonSFX,
        clearSFX,
        coinSFX,
        deathSFX,
        gachaSFX,
        hitSFX,
        itemSFX,
        jumpSFX,
        shieldBreakSFX,
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

    public enum HeadSkin
    {
        Normal_BlueCap,
        Normal_DevilHorn,
        Normal_Duck,
        Normal_Mario,
        Normal_OrangeCap,
        Normal_Rio,
        Normal_Santa,
        Normal_Straw,
        Epic_Crown,
        Epic_Pororo,
        Epic_Rabbit,
        Epic_Satgat,
        Epic_Sunbigat,
        Legend_Angel,
        Legend_Devil,
        Legend_Wizard,
        MaxCount
    }
    public enum ClothSkin
    {
        Normal_BlackOveralls,
        Normal_BluePants,
        Normal_Chick,
        Normal_GreenPants,
        Normal_PinkOveralls,
        Normal_RedOveralls,
        Normal_Wound,
        Normal_YellowOveralls,
        Epic_BlackCape1,
        Epic_BlackCape2,
        Epic_BlueCape,
        Epic_Dress,
        Epic_Mermaid,
        Legend_Angel,
        Legend_DemonWeapon,
        Legend_Wizard,
        MaxCount
    }
    public enum WingSkin
    {
        Normal_Blue,
        Normal_BlueButterfly,
        Normal_Cloud,
        Normal_Cute,
        Normal_GreenFairy,
        Normal_PinkButterfly,
        Normal_Purple,
        Normal_PurpleButterfly,
        Epic_Blue,
        Epic_BlueClearButterfly,
        Epic_Golden,
        Epic_PinkAngel,
        Epic_PinkClearButterfly,
        Legend_Angel,
        Legend_Devil,
        Legend_Wizard,
        MaxCount
    }
}