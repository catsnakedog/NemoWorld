using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        textDict["Energy"].text = Single.Data.inGameData.cost.energy.ToString() + "/15";
        textDict["HatGacha"].text = Single.Data.inGameData.cost.headTicket.ToString();
        textDict["ClothGacha"].text = Single.Data.inGameData.cost.clothTicket.ToString();
        textDict["WingGacha"].text = Single.Data.inGameData.cost.wingTicket.ToString();
        textDict["GachaPiece"].text = Single.Data.inGameData.cost.gachaPiece.ToString();
        transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = DataManager.Single.Data.inGameData.name;
    }
}