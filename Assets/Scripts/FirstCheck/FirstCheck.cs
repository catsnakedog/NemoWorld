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
            MainController.main.UI.UIsetting(Define.UIlevel.Level1, Define.UItype.FirstUI);
        }
        else
        {
            MainController.main.UI.UIsetting(Define.UIlevel.Level1, Define.UItype.MainLobby);
        }
    }
}
