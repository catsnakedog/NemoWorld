using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaResult : MonoBehaviour
{
    List<Image> reults = new List<Image>();
    [SerializeField] GameObject resultlist;

    public void SetResult(int cnt)
    {
        if (reults.Count == 0)
        {
            for (int i = 0; i < resultlist.transform.childCount; i++)
            {
                reults.Add(resultlist.transform.GetChild(i).GetChild(0).GetComponent<Image>());
            }
        }

        for (int i=0; i < cnt; i++)
        {
            switch (GachaManager.Results[i])
            {
                case 0: case 1: case 2://Skin
                    SetSkin(i, GachaManager.Results[i]);
                    break;
                case 3://Gold
                    SetGoldItem(i);
                    break;
                case 4://Time
                    SetTimeItem(i);
                    break;
                case 5://Shield
                    SetShieldItem(i);
                    break;
                case 6://Save
                    SetSaveItem(i);
                    break;
                case 7://StartBooster
                    SetStartBoosterItem(i);
                    break;
                case 8://GachaPiece3
                    SetGachaPiece3Item(i);
                    break;
                case 9://GachaPiece5
                    SetGachaPiece5Item(i);
                    break;
            }
        }
    }

    private void SetSkin(int index, int grade)
    {
        int r = 0;

        if (grade == 0)//Normal
        {
            r = Random.Range(0, 8);
            grade = 3;
        }
        else if (grade == 1)//Epic
        {
            r = Random.Range(8, 13);
            grade = 5;
        }
        else//Legend
        {
            r = Random.Range(13, 16);
            grade = 10;
        }

        switch (GachaManager.GachaType)
        {
            case "Head":
                if (DataManager.Single.Data.inGameData.itemList.headItem.Contains(((Define.HeadSkin)r).ToString()))
                {
                    DataManager.Single.Data.inGameData.cost.gachaPiece += grade;
                    reults[index].sprite = MainController.main.resource.sprite["GachaPiece" + grade.ToString()];
                }
                else
                {
                    DataManager.Single.Data.inGameData.itemList.headItem.Add(((Define.HeadSkin)r).ToString());
                    reults[index].sprite = MainController.main.resource.head_skin_sprite[((Define.HeadSkin)r).ToString()];
                } 
                break;
            case "Cloth":
                if (DataManager.Single.Data.inGameData.itemList.clothItem.Contains(((Define.ClothSkin)r).ToString()))
                {
                    DataManager.Single.Data.inGameData.cost.gachaPiece += grade;
                    reults[index].sprite = MainController.main.resource.sprite["GachaPiece" + grade.ToString()];
                }
                else
                {
                    DataManager.Single.Data.inGameData.itemList.clothItem.Add(((Define.ClothSkin)r).ToString());
                    reults[index].sprite = MainController.main.resource.cloth_skin_sprite[((Define.ClothSkin)r).ToString()];
                }
                break;
            case "Wing":
                if (DataManager.Single.Data.inGameData.itemList.wingItem.Contains(((Define.WingSkin)r).ToString()))
                {
                    DataManager.Single.Data.inGameData.cost.gachaPiece += grade;
                    reults[index].sprite = MainController.main.resource.sprite["GachaPiece" + grade.ToString()];
                }
                else
                {
                    DataManager.Single.Data.inGameData.itemList.wingItem.Add(((Define.WingSkin)r).ToString());
                    reults[index].sprite = MainController.main.resource.wing_skin_sprite[((Define.WingSkin)r).ToString()];
                }
                break;
        }
    }
    private void SetGoldItem(int index)
    {
        reults[index].sprite = MainController.main.resource.sprite["Gold"];
        DataManager.Single.Data.inGameData.inGameItem.coinItemAmount++;
    }
    private void SetTimeItem(int index)
    {
        reults[index].sprite = MainController.main.resource.sprite["Time"];
        DataManager.Single.Data.inGameData.inGameItem.timeItemAmount++;
    }
    private void SetShieldItem(int index)
    {
        reults[index].sprite = MainController.main.resource.sprite["Shield"];
        DataManager.Single.Data.inGameData.inGameItem.shieldItemAmount++;
    }
    private void SetSaveItem(int index)
    {
        reults[index].sprite = MainController.main.resource.sprite["Save"];
        DataManager.Single.Data.inGameData.inGameItem.saveItemAmount++;
    }
    private void SetStartBoosterItem(int index)
    {
        reults[index].sprite = MainController.main.resource.sprite["StartBooster"];
        DataManager.Single.Data.inGameData.inGameItem.boostItemAmount++;
    }
    private void SetGachaPiece3Item(int index)
    {
        reults[index].sprite = MainController.main.resource.sprite["GachaPiece3"];
        DataManager.Single.Data.inGameData.cost.gachaPiece += 3;
    }
    private void SetGachaPiece5Item(int index)
    {
        reults[index].sprite = MainController.main.resource.sprite["GachaPiece5"];
        DataManager.Single.Data.inGameData.cost.gachaPiece += 5;
    }
}
