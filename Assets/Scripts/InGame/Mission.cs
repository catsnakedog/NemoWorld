using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Mission : MonoBehaviour
{
    StringBuilder sb;
    // Start is called before the first frame update
    void Start()
    {
        sb = new StringBuilder("stage");
        sb.Append(DataManager.Single.Data.inGameData.crruentQuest.stage);

        if (DataManager.Single.Data.inGameData.crruentQuest.gameMode != "easy")
            return;
        Invoke(sb.ToString(), 0f);
    }

    void stage1()
    {
        if(DataManager.Single.Data.missionData.jumpCount >= 60)
        {
            if (!DataManager.Single.Data.inGameData.missionClearList.Contains(sb.ToString()))
            {
                DataManager.Single.Data.inGameData.missionClearList.Add("stage1");
            }
        }
    }

    void stage2()
    {
        if (DataManager.Single.Data.missionData.silverCoinCount >= 10)
        {
            if (!DataManager.Single.Data.inGameData.missionClearList.Contains(sb.ToString()))
            {
                DataManager.Single.Data.inGameData.missionClearList.Add("stage2");
            }
        }
    }

    void stage3()
    {
        if (DataManager.Single.Data.missionData.hitCount <= 2)
        {
            if (!DataManager.Single.Data.inGameData.missionClearList.Contains(sb.ToString()))
            {
                DataManager.Single.Data.inGameData.missionClearList.Add("stage3");
            }
        }
    }
}
