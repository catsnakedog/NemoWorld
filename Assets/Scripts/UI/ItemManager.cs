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
                return "���ڸ� ���� �� ����� �� �ִ� �̱��";
                break;
            case "ClothTicket":
                return "���� ���� �� ����� �� �ִ� �̱��";
                break;
            case "WingTicket":
                return "������ ���� �� ����� �� �ִ� �̱��";
                break;
            case "Gold":
                return "�ش� �������� Ŭ���� �� ��带 40% �߰� ȹ���� �� �ֽ��ϴ�.";
                break;
            case "Time":
                return "�ش� ���������� ������ �� �÷��� �ð��� 15�� �߰��˴ϴ�.";
                break;
            case "Shield":
                return "�ش� ���������� ������ �� �⺻ ���尡 �� �� ����˴ϴ�.";
                break;
            case "Save":
                return "�ش� ���������� �÷����� �� ���� �� �� �� �ٽ� ��Ƴ��ϴ�.";
                break;
            case "StartBooster":
                return "�ش� ���������� ������ �� ���� 10�� ���� ���ָ� �ϸ� ������ �˴ϴ�.";
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
                return "���� �̱��";
                break;
            case "ClothTicket":
                return "�� �̱��";
                break;
            case "WingTicket":
                return "���� �̱��";
                break;
            case "Gold":
                return "��� 40% �߰� ȹ��";
                break;
            case "Time":
                return "�÷��� �ð� 15�� ����";
                break;
            case "Shield":
                return "�ǵ� 1ȸ";
                break;
            case "Save":
                return "���� 1ȸ ����";
                break;
            case "StartBooster":
                return "��ŸƮ ����";
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
