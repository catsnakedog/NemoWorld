using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkinSetEffectText : MonoBehaviour
{
    void Start()
    {
        
        SetEffectText();
    }

    private void SetEffectText()
    {
        GameObject[]  Texts = new GameObject[transform.childCount - 2];

        for (int i = 2; i < transform.childCount; i++)
        {
            Texts[i-2] = transform.GetChild(i).gameObject;
        }

        if (DataManager.Single.Data.inGameData.itemList.IsCommonSkinSetComplete())
        {
            Texts[0].GetComponent<TMP_Text>().fontStyle = FontStyles.Bold;
            Texts[1].GetComponent<TMP_Text>().fontStyle = FontStyles.Bold;
            Texts[1].GetComponent<TMP_Text>().color = new Color32(3, 142, 28, 255);
            Texts[2].SetActive(false);
        }
        if (DataManager.Single.Data.inGameData.itemList.IsEpicSkinSetComplete())
        {
            Texts[3].GetComponent<TMP_Text>().fontStyle = FontStyles.Bold;
            Texts[4].GetComponent<TMP_Text>().fontStyle = FontStyles.Bold;
            Texts[4].GetComponent<TMP_Text>().color = new Color32(3, 142, 28, 255);
            Texts[5].SetActive(false);
        }
        if (DataManager.Single.Data.inGameData.itemList.IsLegendSkinSetComplete())
        {
            Texts[6].GetComponent<TMP_Text>().fontStyle = FontStyles.Bold;
            Texts[7].GetComponent<TMP_Text>().fontStyle = FontStyles.Bold;
            Texts[7].GetComponent<TMP_Text>().color = new Color32(3, 142, 28, 255);
            Texts[8].SetActive(false);
        }
    }
}
