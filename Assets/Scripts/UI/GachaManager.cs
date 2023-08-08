using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GachaManager : MonoBehaviour
{
    public static Action PageMove;
    public static Action<string, int> Gacha;//string : cost, int : count(1 or 10)


    public static int page;


    //Gacha Page
    private TMP_Text GachaName;
    private Image BoxImage, BtnImage1, BtnImage10;
    private GameObject LeftBtn, RightBtn;
    //Gacha Result
    private GameObject OneResultPanel, TenResultPanel;


    private float GetGachaPercent(int i)
    {
        switch (i)
        {
            case 0: return 27f;
            case 1: return 29.25f;
            case 2: return 30f;
            case 3: return 40f;
            case 4: return 50f;
            case 5: return 60f;
            case 6: return 70f;
            case 7: return 80f;
            case 8: return 95f;
            default: return 100f;
        }
    }
    private int GetLength() { return 10; }

    public static int[] Results;


    void Start()
    {
        //Gacha Setting
        page = 1;
        GachaName = transform.Find("GachaInfo").transform.Find("GachaText").GetComponent<TMP_Text>();
        GachaName.text = "¸ðÀÚ »Ì±â";
        BoxImage = transform.Find("GachaInfo").transform.Find("GachaImage").GetComponent<Image>();
        BoxImage.sprite = MainController.main.resource.sprite[Define.SpriteDict.HeadBox.ToString()];

        //Gacha Button Setting
        BtnImage1 = transform.Find("1_Ticket").transform.Find("Image").GetComponent<Image>();
        BtnImage1.sprite = MainController.main.resource.sprite[Define.SpriteDict.HeadTicket.ToString()];
        BtnImage10 = transform.Find("10_Ticket").transform.Find("Image").GetComponent<Image>();
        BtnImage10.sprite = MainController.main.resource.sprite[Define.SpriteDict.HeadTicket.ToString()];
        LeftBtn = transform.Find("Left").gameObject;
        LeftBtn.SetActive(false);
        RightBtn = transform.Find("Right").gameObject;

        //Result Panel Setting
        Results = new int[11];
        OneResultPanel = transform.Find("1Result").gameObject;
        TenResultPanel = transform.Find("10Result").gameObject;

        //Action Set
        PageMove += SetGachaType;
        Gacha += gacha;
    }

    public void SetGachaType()
    {
        if(GachaName == null || BoxImage == null)
        {
            GachaName = transform.Find("GachaInfo").transform.Find("GachaText").GetComponent<TMP_Text>();
            BoxImage = transform.Find("GachaInfo").transform.Find("GachaImage").GetComponent<Image>();
            BtnImage1 = transform.Find("1_Ticket").transform.Find("Image").GetComponent<Image>();
            BtnImage10 = transform.Find("10_Ticket").transform.Find("Image").GetComponent<Image>();
            LeftBtn = transform.Find("Left").gameObject;
            RightBtn = transform.Find("Right").gameObject;
        }

        switch (page)
        {
            case 1:
                GachaName.text = "¸ðÀÚ »Ì±â";
                BoxImage.sprite = MainController.main.resource.sprite[Define.SpriteDict.HeadBox.ToString()];
                BtnImage1.sprite = MainController.main.resource.sprite[Define.SpriteDict.HeadTicket.ToString()];
                BtnImage10.sprite = MainController.main.resource.sprite[Define.SpriteDict.HeadTicket.ToString()];
                LeftBtn.SetActive(false);
                RightBtn.SetActive(true);
                break;
            case 2:
                GachaName.text = "ÀÇ»ó »Ì±â";
                BoxImage.sprite = MainController.main.resource.sprite[Define.SpriteDict.ClothBox.ToString()];
                BtnImage1.sprite = MainController.main.resource.sprite[Define.SpriteDict.ClothTicket.ToString()];
                BtnImage10.sprite = MainController.main.resource.sprite[Define.SpriteDict.ClothTicket.ToString()];
                LeftBtn.SetActive(true);
                RightBtn.SetActive(true);
                break;
            case 3: 
                GachaName.text = "³¯°³ »Ì±â";
                BoxImage.sprite = MainController.main.resource.sprite[Define.SpriteDict.WingBox.ToString()];
                BtnImage1.sprite = MainController.main.resource.sprite[Define.SpriteDict.WingTicket.ToString()];
                BtnImage10.sprite = MainController.main.resource.sprite[Define.SpriteDict.WingTicket.ToString()];
                LeftBtn.SetActive(true);
                RightBtn.SetActive(false);
                break;
        }
    }

    public void SetGachaResult()
    {

    }
    public void gacha(string cost, int count)
    {
        //ÆÇ³Ú¸¸ ¶ç¿ì±â
        //ÆÇ³Ú ¾ÈÀÇ GachaResult.cs¿¡¼­ È®·ü °è»ê ÈÄ ÀÌ¹ÌÁö ¼Â
        float rand;

        if (count == 10) count++; // 10 + 1

        for(int i = 0; i < count; i++)
        {
            rand = UnityEngine.Random.Range(0f, 100f);
            for(int j=0; j < GetLength(); j++)
            {
                if (rand < GetGachaPercent(j))
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
