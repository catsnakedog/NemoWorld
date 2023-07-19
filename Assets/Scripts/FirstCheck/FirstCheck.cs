using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCheck : MonoBehaviour
{
    void Start()
    {
        MainController.main.sound.Play("mainBGM");
        if(DataManager.Single.Data.inGameData.isFirst)
        {
            DataManager.Single.Data.optionData.volumeBGM = 0.5f;
            DataManager.Single.Data.optionData.volumeSFX = 0.5f;
            DataManager.Single.Data.inGameData.adventureClearList.Add("stage1");
            DataManager.Single.Data.inGameData.adventureClearList.Add("stage2");
            DataManager.Single.Data.inGameData.adventureClearList.Add("stage3");
            DataManager.Single.Data.inGameData.missionClearList.Add("stage1");
            DataManager.Single.Data.inGameData.missionClearList.Add("stage2");
            DataManager.Single.Data.inGameData.missionClearList.Add("stage3");
            DataManager.Single.Data.inGameData.storyClearList.Add("stage1");
            DataManager.Single.Data.inGameData.storyClearList.Add("stage2");
            DataManager.Single.Data.inGameData.storyClearList.Add("stage3");
            MainController.main.UI.UIsetting(Define.UIlevel.Level1, Define.UItype.FirstUI);
        }
        else
        {
            MainController.main.UI.UIsetting(Define.UIlevel.Level1, Define.UItype.MainLobby);
        }
    }
}
