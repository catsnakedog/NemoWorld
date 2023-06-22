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

    public Cost(int gold, int energy)
    {
        this.gold = gold;
        this.energy = energy;
    }

    public Cost()
    {
        gold = 0;
        energy = 0;
    }
}

#endregion