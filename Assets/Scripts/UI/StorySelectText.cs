using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class StorySelectText : MonoBehaviour
{
    protected void Start()
    {
        StageTextSet();
        ModeTextSet();
        QuestInfoTextSet();
    }

    void StageTextSet()
    {
        StringBuilder sb = new StringBuilder("Stage");
        sb.Append(DataManager.Single.Data.inGameData.stage.ToString());
        transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = sb.ToString();
    }

    void ModeTextSet()
    {
        if(DataManager.Single.Data.inGameData.gameMode == "easy")
        {
            transform.GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = "하드 모드 해금 미션";
        }
        if (DataManager.Single.Data.inGameData.gameMode == "hard")
        {
            transform.GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = "high score";
            transform.GetChild(2).GetChild(1).GetComponent<TMP_Text>().text = "0"; // 임시값 수정 필요
        }
    }

    void QuestInfoTextSet()
    {
        string info = "error";
        for(int i = 0; i< DataManager.Single.Data.questData.questInfo.Count; i++)
        {
            if(DataManager.Single.Data.questData.questInfo[i].stage == DataManager.Single.Data.inGameData.stage)
            {
                if (DataManager.Single.Data.questData.questInfo[i].gameMode == DataManager.Single.Data.inGameData.gameMode)
                {
                    QuestCopy(i);
                    info = DataManager.Single.Data.questData.questInfo[i].info;
                    break;
                }
            }
        }
        transform.GetChild(2).GetChild(1).GetComponent<TMP_Text>().text = info;
    }

    void QuestCopy(int i)
    {
        DataManager.Single.Data.inGameData.crruentQuest.stage = DataManager.Single.Data.questData.questInfo[i].stage;
        DataManager.Single.Data.inGameData.crruentQuest.gameMode = DataManager.Single.Data.questData.questInfo[i].gameMode;
        DataManager.Single.Data.inGameData.crruentQuest.info = DataManager.Single.Data.questData.questInfo[i].info;
        DataManager.Single.Data.inGameData.crruentQuest.time = DataManager.Single.Data.questData.questInfo[i].time;
    }
}