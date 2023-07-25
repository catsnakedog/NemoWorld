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
        AdventureSelect,
        InGameUI,
        InGameBG,
        Pause,
        Gacha,
        Shop,
        GameResult,
        CutToon,
        FirstUI,
        RankingMode,
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

    public enum rankingMap
    {
        Start,
        Part1,
        Part2,
        Part3,
        Part4,
        Part5,
        Part6,
        Part7,
        Part8,
        Part9,
        Part10,
        Part11,
        Part12,
        End,
        MaxCount
    }

    public enum SpriteDict
    {
        diePlayer,
        clearPlayer,
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
        skin_none,
        easy_bg_n_BG,
        easy_bg_n_1_1,
        easy_bg_n_1_2,
        easy_bg_n_2_1,
        easy_bg_n_2_2,
        easy_bg_n_3_1,
        easy_bg_n_3_2,
        easy_bg_c_BG,
        easy_bg_c_1_1,
        easy_bg_c_1_2,
        easy_bg_c_2_1,
        easy_bg_c_2_2,
        easy_bg_c_3_1,
        easy_bg_c_3_2,
        hard_bg_n_BG,
        hard_bg_n_1_1,
        hard_bg_n_1_2,
        hard_bg_n_2_1,
        hard_bg_n_2_2,
        hard_bg_n_3_1,
        hard_bg_n_3_2,
        hard_bg_c_BG,
        hard_bg_c_1_1,
        hard_bg_c_1_2,
        hard_bg_c_2_1,
        hard_bg_c_2_2,
        hard_bg_c_3_1,
        hard_bg_c_3_2,
        rank_bg_n_BG,
        rank_bg_n_1_1,
        rank_bg_n_1_2,
        rank_bg_n_2_1,
        rank_bg_n_2_2,
        rank_bg_n_3_1,
        rank_bg_n_3_2,
        rank_bg_c_BG,
        rank_bg_c_1_1,
        rank_bg_c_1_2,
        rank_bg_c_2_1,
        rank_bg_c_2_2,
        rank_bg_c_3_1,
        rank_bg_c_3_2,
        BG1_1,
        BG1_4,
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
        Epic_PurpleCape,
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
        Normal_Sky,
        Normal_Cloud,
        Normal_Cute,
        Normal_Green,
        Normal_Pink,
        Normal_Purple,
        Normal_Golden,
        Epic_BlueClearButterfly,
        Epic_PinkClearButterfly,
        Epic_PurpleButterfly,
        Epic_BlueButterfly,
        Epic_PinkAngel,
        Legend_Angel,
        Legend_Devil,
        Legend_Wizard,
        MaxCount
    }
}