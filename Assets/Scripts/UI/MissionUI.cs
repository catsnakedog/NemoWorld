using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;
using System;

public class MissionUI : MonoBehaviour
{
    Action missionAction;
    TMP_Text missionText;
    StringBuilder sb;
    void Start()
    {
        missionText = transform.GetChild(0).GetComponent<TMP_Text>();
        sb = new StringBuilder();

        DataManager.Single.Data.missionData.jumpCount = 0;
        DataManager.Single.Data.missionData.silverCoinCount = 0;
        DataManager.Single.Data.missionData.hitCount = 0;

        Init();
    }

    void Init()
    {
        sb.Append("stage");
        sb.Append(DataManager.Single.Data.inGameData.crruentQuest.stage);
        if (DataManager.Single.Data.inGameData.missionClearList.Contains(sb.ToString()))
        {
            gameObject.SetActive(false);
        }

        sb.Clear();
        
        switch(DataManager.Single.Data.inGameData.crruentQuest.stage)
        {
            case 1:
                missionAction += Mission1;
                return;
            case 2:
                missionAction += Mission2;
                return;
            case 3:
                missionAction += Mission3;
                return;
        }
    }

    private void Update()
    {
        missionAction?.Invoke();
    }

    void Mission1()
    {
        sb.Clear();
        sb.Append("점프 60번 달성\n(");
        sb.Append(DataManager.Single.Data.missionData.jumpCount.ToString() + " / 60)");
        missionText.text = sb.ToString();
    }
    void Mission2()
    {
        sb.Clear();
        sb.Append("은화 코인\n10개 획득\n(");
        sb.Append(DataManager.Single.Data.missionData.silverCoinCount.ToString() + " / 10)");
        missionText.text = sb.ToString();
    }
    void Mission3()
    {
        sb.Clear();
        sb.Append("장애물에 2번 이하로\n부딪히기\n(");
        sb.Append(DataManager.Single.Data.missionData.hitCount.ToString());
        sb.Append("/2)");
        missionText.text = sb.ToString();
    }
}
