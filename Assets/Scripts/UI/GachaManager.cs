using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GachaManager : MonoBehaviour
{
    //Gacha Box Type
    public static int page = 2;
    public static string GachaType = "Cloth";//Head or Cloth or Wing
    public static Action<string> PageMove;//string : Left or Right
    private TMP_Text GachaText;
    

    //Result
    private GameObject OneResultPanel, TenResultPanel;//ResultPanel
    public static Action<string, int> Gacha;//string : cost, int : count(1 or 10)
    public static int[] Results;


    private float[] Percent = new float[] { 27f, 29.25f, 30f, 40f, 50f, 60f, 70f, 80f, 95f, 100f };


    // Start is called before the first frame update
    void Start()
    {
        OneResultPanel = transform.Find("1Result").gameObject;
        TenResultPanel = transform.Find("10Result").gameObject;

        PageMove += SetGachaType;

        Results = new int[11];

        Gacha += gacha;
    }

    public void SetGachaType(string name)
    {
        GachaText = GameObject.Find("GachaText").GetComponent<TMP_Text>();

        switch (page)
        {
            case 1: 
                GachaType = "Head";
                GachaText.text = "¸ðÀÚ »Ì±â";
                break;
            case 2: GachaType = "Cloth";
                GachaText.text = "ÀÇ»ó »Ì±â"; 
                break;
            case 3: GachaType = "Wing";
                GachaText.text = "³¯°³ »Ì±â"; 
                break;
        }
    }

    public void gacha(string cost, int count)
    {
        float rand;

        if (count == 10) count++; // 10 + 1

        for(int i = 0; i < count; i++)
        {
            rand = UnityEngine.Random.Range(0f, 100f);
            for(int j=0; j < Percent.Length; j++)
            {
                if (rand < Percent[j])
                {
                    Results[i] = j;
                    break;
                }
            }
        }

        if(count == 1)
        {
            OneResultPanel.SetActive(true);
            OneResultPanel.GetComponent<GachaResult>().SetResult(count);
        }
        else
        {
            TenResultPanel.SetActive(true);
            TenResultPanel.GetComponent<GachaResult>().SetResult(count);
        }
    }

    public void Close()
    {
        MainController.main.sound.Play("buttonSFX");
        OneResultPanel.SetActive(false);
        TenResultPanel.SetActive(false);
    }

    private void OnDestroy()
    {
        PageMove -= SetGachaType;
        Gacha -= gacha;
    }
}
