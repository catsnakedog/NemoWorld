using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class BGChange : MonoBehaviour
{
    int time;
    void Start()
    {
        if (DataManager.Single.Data.inGameData.crruentQuest.gameMode == "easy")
        {
            time = 20;
        }
        else
        {
            time = 60;
        }
        StartCoroutine(Change());
    }

    IEnumerator Change()
    {
        StringBuilder sb = new StringBuilder("BG");
        int cnt = 1;
        sb.Append(DataManager.Single.Data.inGameData.crruentQuest.stage);
        sb.Append("_");

        for(int i = 0; i < 4; i++)
        {
            sb.Append(cnt.ToString());
            gameObject.GetComponent<Image>().sprite = MainController.main.resource.sprite[sb.ToString()];
            sb.Remove(4, 1);
            cnt++;
            yield return new WaitForSeconds(time);
        }
    }
}
