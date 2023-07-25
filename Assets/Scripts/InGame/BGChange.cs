using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class BGChange : MonoBehaviour
{
    float time;

    [SerializeField] List<Image[]> bg;
    [SerializeField] float Speed;
    float[] speed;

    StringBuilder sb;

    void Start()
    {
        bg = new List<Image[]>();
        bg.Add(transform.GetChild(2).GetComponentsInChildren<Image>());
        bg.Add(transform.GetChild(1).GetComponentsInChildren<Image>());
        bg.Add(transform.GetChild(0).GetComponentsInChildren<Image>());

        //Speed Set
        Speed *= 0.01f;
        speed = new float[] { 3, 2, 1 };

        //UI Set
        sb = new StringBuilder();
        sb.Append(DataManager.Single.Data.inGameData.crruentQuest.gameMode);
        sb.Append("_bg_n_");
        GetComponent<Image>().sprite = MainController.main.resource.sprite[sb.Append("BG").ToString()];
        sb.Replace("BG", "0");

        for (int i = 0; i < bg.Count; i++)
        {
            for (int j = 0; j < bg[i].Length; j++)
            {
                bg[i][j].sprite = MainController.main.resource.sprite[sb.Replace(i.ToString(), (i + 1).ToString()).ToString()];
                bg[i][j].gameObject.AddComponent<MoveBG>().Init(speed[i], Speed);
            }
        }

        //Start UI Change Coroutine
        StartCoroutine("Change");
    }

    IEnumerator Change()
    {
        if (DataManager.Single.Data.inGameData.crruentQuest.gameMode.Equals("easy"))
        {
            time = 20f;
        }
        else if (DataManager.Single.Data.inGameData.crruentQuest.gameMode.Equals("hard"))
        {
            time = 40f;
        }
        else if (DataManager.Single.Data.inGameData.crruentQuest.gameMode.Equals("rank"))
        {
            time = 40f;
        }

        yield return new WaitForSeconds(time);

        sb.Replace("_n_","_c_");
        sb.Replace("3", "0");

        for (int i = 0; i < bg.Count; i++)
        {
            for (int j = 0; j < bg[i].Length; j++)
            {
                bg[i][j].sprite = MainController.main.resource.sprite[sb.Replace(i.ToString(), (i + 1).ToString()).ToString()];
            }

            if (i == 2)
            {
                GetComponent<Image>().sprite = MainController.main.resource.sprite[sb.Replace("3", "BG").ToString()];
            }
            yield return new WaitForSeconds(time);
        }

        yield return null;
    }

    private void OnDestroy()
    {
        StopCoroutine("Change");
    }
}
