using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class SaveDataClass
{
    public InGameData inGameData;
    public OptionData optionData;
    public SaveDataClass(InGameData inGameData, OptionData optionData)
    {
        this.inGameData = inGameData;
        this.optionData = optionData;
    }
    public SaveDataClass()
    {
        inGameData = new InGameData();
        optionData = new OptionData();
    }
}

#region InGameData

[System.Serializable]
public class InGameData
{
    public Cost cost;
    public ItemList itemList;
    public Ch ch;

    public InGameData(Cost cost, ItemList itemList, Ch ch)
    {
        this.cost = cost;
        this.itemList = itemList;
        this.ch = ch;
    }

    public InGameData()
    {
        cost = new Cost();
        itemList = new ItemList();
        ch = new Ch();
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