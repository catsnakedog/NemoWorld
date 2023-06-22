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

[System.Serializable]
public class InGameData
{
}