using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAward : MonoBehaviour
{
    void Start()
    {
        if(DataManager.Single.Data.inGameData.isRankAward)
        {
            switch(DataManager.Single.Data.rankingData.awardType)
            {
                case 1:
                    MainController.main.UI.UIsetting(Define.UIlevel.Level3, Define.UItype.Award1);
                    return;
                case 2:
                    MainController.main.UI.UIsetting(Define.UIlevel.Level3, Define.UItype.Award2);
                    return;
                case 3:
                    MainController.main.UI.UIsetting(Define.UIlevel.Level3, Define.UItype.Award3);
                    return;
                case 4:
                    MainController.main.UI.UIsetting(Define.UIlevel.Level3, Define.UItype.Award4);
                    return;
                case 5:
                    MainController.main.UI.UIsetting(Define.UIlevel.Level3, Define.UItype.Award5);
                    return;
                default:
                    return;
            }
        }
    }
}
