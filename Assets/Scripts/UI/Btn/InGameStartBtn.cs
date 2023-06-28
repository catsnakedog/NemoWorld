using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

public class InGameStartBtn : EventTriggerEX
{
    protected void Start()
    {
        init();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        StringBuilder sb = new StringBuilder("Stage");
        sb.Append("1");
        GameObject temp = Instantiate(MainController.main.resource.Map[0], new Vector3(0f, 0f, 0f), Quaternion.identity);
        temp.transform.SetParent(GameObject.FindWithTag("Map").transform, false);
        Destroy(GameObject.FindWithTag("Level1").transform.GetChild(0).gameObject);
        Destroy(GameObject.FindWithTag("Level2").transform.GetChild(0).gameObject);
        MainController.main.UI.UIsetting(Define.UIlevel.Level2, Define.UItype.InGameUI);
    }
}
