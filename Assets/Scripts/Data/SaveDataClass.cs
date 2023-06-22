using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class SaveDataClass
{
    public InGameData inGameData;
    public SaveDataClass(InGameData inGameData)
    {
        this.inGameData = inGameData;
    }
    public SaveDataClass()
    {
        inGameData = new InGameData();
    }
}

#region InGameData

[System.Serializable]
public class InGameData
{
    public Cost cost;

    public InGameData(Cost cost)
    {
        this.cost = cost;
    }

    public InGameData()
    {
        cost = new Cost();
    }
}

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

#endregion