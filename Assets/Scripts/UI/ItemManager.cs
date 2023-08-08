using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public static Action<string> ItemCount;
    public static Action ItemBuy;

    public static string selectItem { get; set; }
    

    private Image Up;
    private Image Down;
    private TMP_Text Count;
    private TMP_Text Price;
    private bool up = true;
    private bool down = false; 
    private int count = 1;
    private int price = 0;


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
        //Item Count Reset
        Count = transform.Find("Count").transform.GetChild(0).GetComponent<TMP_Text>();
        Count.text = "1";

        //Item Price Reset
        Price = transform.Find("BuyBtn").transform.Find("ItemPrice").GetComponent<TMP_Text>();
        if ((int)Enum.Parse(typeof(Define.ItemShop), selectItem) < 3)
            price = 10;
        else
            price = 20;
        Price.text = (price).ToString();

        //Up Down Button Set
        Up = transform.Find("Up").GetComponent<Image>();
        Down = transform.Find("Down").GetComponent<Image>();
        Down.sprite = MainController.main.resource.sprite[Define.SpriteDict.ButtonCircleGrey.ToString()];

        //Item Info Set
        transform.Find("ItemImage").GetComponent<Image>().sprite = MainController.main.resource.sprite[selectItem];
        transform.Find("ItemName").GetComponent<TMP_Text>().text = GetItemName();
        transform.Find("ItemExplain").GetComponent<TMP_Text>().text = GetItemExplain();
        
        //if Ticket
        if((int)Enum.Parse(typeof(Define.ItemShop),selectItem) < 3)
            transform.Find("BuyBtn").GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.sprite["GachaPiece"];

        //Action
        ItemCount += ItemCountFunc;
        ItemBuy += ItemBuyFunc;
    }

    void ItemCountFunc(string btnName)
    {
        if(Up == null || Down == null)
        {
            Up = transform.Find("Up").GetComponent<Image>();
            Down = transform.Find("Down").GetComponent<Image>();
        }

        int max = 0;
        switch (selectItem)
        {
            case "HeadTicket": case "ClothTicket": case "WingTicket":
                max = DataManager.Single.Data.inGameData.cost.gachaPiece / 10;
                break;
            default:
                max = DataManager.Single.Data.inGameData.cost.gold / 20;
                break;
        }

        if (btnName.Equals("Up") && up)
        {
            count++;
            TextSet();

            if (count == max)
            {
                Up.sprite = MainController.main.resource.sprite[Define.SpriteDict.ButtonCircleGrey.ToString()];
                up = false;
            }

            if (!down)
            {
                Down.sprite = MainController.main.resource.sprite[Define.SpriteDict.ButtonCircleYellow.ToString()];
                down = true;
            }
        }
        else if(btnName.Equals("Down") && down)
        {
            count--;
            TextSet();

            if(count == 1)
            {
                Down.sprite = MainController.main.resource.sprite[Define.SpriteDict.ButtonCircleGrey.ToString()];
                down = false;
            }

            if (!up)
            {
                Up.sprite = MainController.main.resource.sprite[Define.SpriteDict.ButtonCircleYellow.ToString()];
                up = true;
            }
        }
    }

    private void TextSet()
    {
        if(Count == null || Price == null)
        {
            Count = transform.Find("Count").transform.GetChild(0).GetComponent<TMP_Text>();
            Price = transform.Find("ItemPrice").GetComponent<TMP_Text>();
        }

        Count.text = count.ToString();
        Price.text = (count * price).ToString();
    }


    public void ItemBuyFunc()
    {
        switch (selectItem)
        {
            case "HeadTicket":
                DataManager.Single.Data.inGameData.cost.gachaPiece -= count * price;
                DataManager.Single.Data.inGameData.cost.headTicket += count;
                break;
            case "ClothTicket":
                DataManager.Single.Data.inGameData.cost.gachaPiece -= count * price;
                DataManager.Single.Data.inGameData.cost.clothTicket += count;
                break;
            case "WingTicket":
                DataManager.Single.Data.inGameData.cost.gachaPiece -= count * price;
                DataManager.Single.Data.inGameData.cost.wingTicket += count;
                break;
            case "Gold":
                DataManager.Single.Data.inGameData.cost.gold -= count * price;
                DataManager.Single.Data.inGameData.inGameItem.coinItemAmount += count;
                break;
            case "Time":
                DataManager.Single.Data.inGameData.cost.gold -= count * price;
                DataManager.Single.Data.inGameData.inGameItem.timeItemAmount += count;
                break;
            case "Shield":
                DataManager.Single.Data.inGameData.cost.gold -= count * price;
                DataManager.Single.Data.inGameData.inGameItem.shieldItemAmount += count;
                break;
            case "Save":
                DataManager.Single.Data.inGameData.cost.gold -= count * price;
                DataManager.Single.Data.inGameData.inGameItem.saveItemAmount += count;
                break;
            case "StartBooster":
                DataManager.Single.Data.inGameData.cost.gold -= count * price;
                DataManager.Single.Data.inGameData.inGameItem.boostItemAmount += count;
                break;
        }

        Destroy(GameObject.FindWithTag("Level3").transform.GetChild(0).gameObject);
    }
    private void OnDestroy()
    {
        ItemCount -= ItemCountFunc;
    }
}
