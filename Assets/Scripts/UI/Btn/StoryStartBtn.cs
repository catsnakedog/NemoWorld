using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

public class StoryStartBtn : EventTriggerEX
{
    protected void Start()
    {
        init();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        GameObject temp = Instantiate(MainController.main.resource.Map[DataManager.Single.Data.inGameData.crruentQuest.stage-1], new Vector3(0f, 0f, 0f), Quaternion.identity);
        temp.transform.SetParent(GameObject.FindWithTag("Map").transform, false);
        temp.AddComponent<MapMove>();
        GameObject ch = Instantiate(MainController.main.resource.ch, new Vector3(-5.5f, -0.5f, 0f), Quaternion.identity);
        ch.transform.SetParent(GameObject.FindWithTag("Ch").transform, false);
        MainController.main.UI.UIsetting(Define.UIlevel.Level1, Define.UItype.InGameBG);
        MainController.main.UI.UIsetting(Define.UIlevel.Level2, Define.UItype.InGameUI);
    }
}
