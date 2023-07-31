using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public static Action<string> ItemCount;
    public static string selectItem { get; set; }
    public static int count { get; set; }
    public static int price { get; set; }

    private string GetItemExplain()
    {
        switch (selectItem)
        {
            case "HeadTicket":
                return "모자를 뽑을 때 사용할 수 있는 뽑기권";
                break;
            case "ClothTicket":
                return "옷을 뽑을 때 사용할 수 있는 뽑기권";
                break;
            case "WingTicket":
                return "날개를 뽑을 때 사용할 수 있는 뽑기권";
                break;
            case "Gold":
                return "해당 스테이지 클리어 후 골드를 40% 추가 획득할 수 있습니다.";
                break;
            case "Time":
                return "해당 스테이지를 시작할 때 플레이 시간이 15초 추가됩니다.";
                break;
            case "Shield":
                return "해당 스테이지를 시작할 때 기본 쉴드가 한 번 적용됩니다.";
                break;
            case "Save":
                return "해당 스테이지를 플레이할 때 낙사 시 한 번 다시 살아납니다.";
                break;
            case "StartBooster":
                return "해당 스테이지를 시작할 때 시작 10초 동안 질주를 하며 무적이 됩니다.";
                break;
            default:
                return "";
        }
    }

    private string GetItemName()
    {
        switch (selectItem)
        {
            case "HeadTicket":
                return "모자 뽑기권";
                break;
            case "ClothTicket":
                return "옷 뽑기권";
                break;
            case "WingTicket":
                return "날개 뽑기권";
                break;
            case "Gold":
                return "골드 40% 추가 획득";
                break;
            case "Time":
                return "플레이 시간 15초 증가";
                break;
            case "Shield":
                return "실드 1회";
                break;
            case "Save":
                return "낙사 1회 구출";
                break;
            case "StartBooster":
                return "스타트 질주";
                break;
            default:
                return "";
        }
    }

    private void Start()
    {
        count = 1;
        price = 0;

        transform.Find("ItemImage").GetComponent<Image>().sprite = MainController.main.resource.sprite[selectItem];
        transform.Find("ItemName").GetComponent<TMP_Text>().text = GetItemName();
        transform.Find("ItemExplain").GetComponent<TMP_Text>().text = GetItemExplain();

        if((int)Enum.Parse(typeof(Define.ItemShop),selectItem) < 3)
        transform.Find("BuyBtn").GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.sprite["GachaPiece"];
    }
}
