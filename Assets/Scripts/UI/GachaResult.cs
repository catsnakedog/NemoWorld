using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaResult : MonoBehaviour
{
    [SerializeField] private int count;
    
    
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


    private int[] Results;
    List<Image> results = new List<Image>();

    private void Start()
    {
        if (GachaManager.count == count)
        {
            if(results.Count == 0)
            {
                Init();
            }

            OnGacha();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void Init()
    {
        GameObject resultlist = transform.GetChild(1).gameObject;

        for (int i = 0; i < resultlist.transform.childCount; i++)
        {
            results.Add(resultlist.transform.GetChild(i).GetChild(0).GetComponent<Image>());
        }

        Results = new int[results.Count];
    }


    private void OnGacha()
    {
        float rand;

        if (count == 10) count++; // 10 + 1

        for (int i = 0; i < count; i++)
        {
            rand = Random.Range(0f, 100f);
            for (int j = 0; j < GetLength(); j++)
            {
                if (rand < GetGachaPercent(j))
                {
                    Results[i] = j;
                    break;
                }
            }
        }

        SetResultUI(count); 
    }
    public void SetResultUI(int cnt)
    {
        for (int i=0; i < cnt; i++)
        {
            switch (Results[i])
            {
                case 0: case 1: case 2://Skin
                    SetSkin(i, Results[i]);
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

        switch (GachaManager.page)
        {
            case 1:
                if (DataManager.Single.Data.inGameData.itemList.headItem.Contains(((Define.HeadSkin)r).ToString()))
                {
                    DataManager.Single.Data.inGameData.cost.gachaPiece += grade;
                    Debug.Log("GachaPiece" + grade.ToString());
                    results[index].sprite = MainController.main.resource.sprite["GachaPiece" + grade.ToString()];
                }
                else
                {
                    DataManager.Single.Data.inGameData.itemList.headItem.Add(((Define.HeadSkin)r).ToString());
                    results[index].sprite = MainController.main.resource.head_skin_sprite[((Define.HeadSkin)r).ToString()];
                } 
                break;
            case 2:
                if (DataManager.Single.Data.inGameData.itemList.clothItem.Contains(((Define.ClothSkin)r).ToString()))
                {
                    DataManager.Single.Data.inGameData.cost.gachaPiece += grade;
                    results[index].sprite = MainController.main.resource.sprite["GachaPiece" + grade.ToString()];
                }
                else
                {
                    DataManager.Single.Data.inGameData.itemList.clothItem.Add(((Define.ClothSkin)r).ToString());
                    results[index].sprite = MainController.main.resource.cloth_skin_sprite[((Define.ClothSkin)r).ToString()];
                }
                break;
            case 3:
                if (DataManager.Single.Data.inGameData.itemList.wingItem.Contains(((Define.WingSkin)r).ToString()))
                {
                    DataManager.Single.Data.inGameData.cost.gachaPiece += grade;
                    results[index].sprite = MainController.main.resource.sprite["GachaPiece" + grade.ToString()];
                }
                else
                {
                    DataManager.Single.Data.inGameData.itemList.wingItem.Add(((Define.WingSkin)r).ToString());
                    results[index].sprite = MainController.main.resource.wing_skin_sprite[((Define.WingSkin)r).ToString()];
                }
                break;
        }
    }
    private void SetGoldItem(int index)
    {
        results[index].sprite = MainController.main.resource.sprite["Gold"];
        DataManager.Single.Data.inGameData.inGameItem.coinItemAmount++;
    }
    private void SetTimeItem(int index)
    {
        results[index].sprite = MainController.main.resource.sprite["Time"];
        DataManager.Single.Data.inGameData.inGameItem.timeItemAmount++;
    }
    private void SetShieldItem(int index)
    {
        results[index].sprite = MainController.main.resource.sprite["Shield"];
        DataManager.Single.Data.inGameData.inGameItem.shieldItemAmount++;
    }
    private void SetSaveItem(int index)
    {
        results[index].sprite = MainController.main.resource.sprite["Save"];
        DataManager.Single.Data.inGameData.inGameItem.saveItemAmount++;
    }
    private void SetStartBoosterItem(int index)
    {
        results[index].sprite = MainController.main.resource.sprite["StartBooster"];
        DataManager.Single.Data.inGameData.inGameItem.boostItemAmount++;
    }
    private void SetGachaPiece3Item(int index)
    {
        results[index].sprite = MainController.main.resource.sprite["GachaPiece3"];
        DataManager.Single.Data.inGameData.cost.gachaPiece += 3;
    }
    private void SetGachaPiece5Item(int index)
    {
        results[index].sprite = MainController.main.resource.sprite["GachaPiece5"];
        DataManager.Single.Data.inGameData.cost.gachaPiece += 5;
    }

}
