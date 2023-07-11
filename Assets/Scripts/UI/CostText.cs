using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class CostText : MonoBehaviour
{
    DataManager Single;

    [SerializeField]
    List<TMP_Text> texts;
    Dictionary<string, TMP_Text> textDict;

    void Start()
    {
        Single = DataManager.Single;
        textDict = new Dictionary<string, TMP_Text>();

        foreach(TMP_Text text in texts)
        {
            textDict.Add(text.gameObject.name, text);
        }

        CostTextSetting();
    }

    void Update()
    {
        CostTextSetting();
    }

    void CostTextSetting()
    {
        textDict["Gold"].text = Single.Data.inGameData.cost.gold.ToString();
        textDict["Gold1"].text = Single.Data.inGameData.cost.gold.ToString();
        textDict["Energy"].text = Single.Data.inGameData.cost.energy.ToString();
        textDict["Energy1"].text = Single.Data.inGameData.cost.energy.ToString();
        textDict["Test1"].text = Single.Data.inGameData.cost.test1.ToString();
        textDict["Test2"].text = Single.Data.inGameData.cost.test2.ToString();
    }
}