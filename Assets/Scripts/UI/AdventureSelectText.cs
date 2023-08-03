using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using UnityEngine.UI;

public class AdventureSelectText : MonoBehaviour
{
    protected void Start()
    {
        QuestInfoTextSet();
        SetRewardImage();
    }

    void QuestInfoTextSet()
    {
        string info = "error";
        for (int i = 0; i < DataManager.Single.Data.questData.questInfo.Count; i++)
        {
            if (DataManager.Single.Data.questData.questInfo[i].stage == DataManager.Single.Data.inGameData.stage)
            {
                if (DataManager.Single.Data.questData.questInfo[i].gameMode == DataManager.Single.Data.inGameData.gameMode)
                {
                    QuestCopy(i);
                    break;
                }
            }
        }
    }

    void QuestCopy(int i)
    {
        DataManager.Single.Data.inGameData.crruentQuest.stage = DataManager.Single.Data.questData.questInfo[i].stage;
        DataManager.Single.Data.inGameData.crruentQuest.gameMode = DataManager.Single.Data.questData.questInfo[i].gameMode;
        DataManager.Single.Data.inGameData.crruentQuest.info = DataManager.Single.Data.questData.questInfo[i].info;
        DataManager.Single.Data.inGameData.crruentQuest.time = DataManager.Single.Data.questData.questInfo[i].time;
    }

    void SetRewardImage()
    {
        Image rewardImage = GameObject.Find("RewardTicket").GetComponent<Image>();

        switch (DataManager.Single.Data.inGameData.stage)
        {
            case 1:
                rewardImage.sprite = MainController.main.resource.sprite[Define.SpriteDict.HeadTicket.ToString()];
                break;
            case 2:
                rewardImage.sprite = MainController.main.resource.sprite[Define.SpriteDict.ClothTicket.ToString()];
                break;
            case 3:
                rewardImage.sprite = MainController.main.resource.sprite[Define.SpriteDict.WingTicket.ToString()];
                break;
        }
    }
}