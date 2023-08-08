using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GachaManager : MonoBehaviour
{
    public static Action PageMove;


    public static int page;
    public static int count;

    //Gacha Page
    private TMP_Text GachaName;
    private Image BoxImage, BtnImage1, BtnImage10;
    private GameObject LeftBtn, RightBtn;
    

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

        //Action Set
        PageMove += SetGachaType;
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


    private void OnDestroy()
    {
        PageMove -= SetGachaType;
    }
}
