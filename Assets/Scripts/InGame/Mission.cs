using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Mission : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StringBuilder sb = new StringBuilder("stage");
        sb.Append(DataManager.Single.Data.inGameData.crruentQuest.stage);

        Invoke(sb.ToString(), 0f);
    }

    void stage1()
    {
        if(DataManager.Single.Data.missionData.jumpCount >= 60)
        {
            DataManager.Single.Data.inGameData.adventureClearList.Add("stage1");
        }
    }

    void stage2()
    {
        if (DataManager.Single.Data.missionData.silverCoinCount >= 10)
        {
            DataManager.Single.Data.inGameData.adventureClearList.Add("stage2");
        }
    }

    void stage3()
    {
        if (DataManager.Single.Data.missionData.hitCount <= 2)
        {
            DataManager.Single.Data.inGameData.adventureClearList.Add("stage3");
        }
    }
}
