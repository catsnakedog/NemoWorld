using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GachaBuyBtn : EventTriggerEX
{
    //코드 너무 더러움 진짜;;
    //꼭 수정하기;;

    [SerializeField]
    int number;
    [SerializeField]
    int price;
    [SerializeField]
    float[] gachaPercent = new float[] {27f, 2.25f, 0.75f, 10f, 10f, 10f, 10f, 10f, 15f, 5f};

    List<GameObject> ResultImage;
    GameObject one, ten, def;
    StringBuilder index, type;
    int grade = 0;

    void Start()
    {
        init();
        
        ResultImage = new List<GameObject>();
        one = GameObject.Find("1_Gacha").gameObject;
        ten = GameObject.Find("10_Gacha").gameObject;
        def = GameObject.Find("Default").gameObject;
        for (int i=0; i < number; i++)
        {
            ResultImage.Add(GameObject.Find(number.ToString() + "_Gacha").transform.GetChild(i).gameObject);
        }
        index = new StringBuilder();
        type = new StringBuilder();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");

        def.SetActive(false);
        if (number == 1)
        {
            ten.SetActive(false);
            one.SetActive(true);
        }
        else
        {
            ten.SetActive(true);
            one.SetActive(false);
        }

        if (DataManager.Single.Data.inGameData.cost.gold >= price)
        {
            DataManager.Single.Data.inGameData.cost.gold -= price;

            int result;
            for (int i = 0; i < number; i++)
            {
                result = Gacha();
                ResultImage[i].SetActive(true);

                if (result < 3)
                {
                    //스킨
                    int rand = 0;
                    index.Clear();
                    type.Clear();

                    //index set 
                    switch (result)
                    {
                        case 0://Normal Skin
                            rand = Random.Range(0, 24);

                            if(rand < 8)
                            {
                                index.Append(((Define.HeadSkin)rand).ToString());
                                type.Append("Head");
                            }
                            else if(rand < 16)
                            {
                                index.Append(((Define.ClothSkin)(rand - 8)).ToString());
                                type.Append("Cloth");
                            }
                            else
                            {
                                index.Append(((Define.WingSkin)(rand - 16)).ToString());
                                type.Append("Wing");
                            }

                            grade = 1;

                            break;
                        case 1://EpicSkin
                            rand = Random.Range(0, 15);

                            if (rand < 5)
                            {
                                index.Append(((Define.HeadSkin)(rand + 8)).ToString());
                                type.Append("Head");
                            }
                            else if (rand < 10)
                            {
                                index.Append(((Define.ClothSkin)(rand - 5 + 8)).ToString());
                                type.Append("Cloth");
                            }
                            else
                            {
                                index.Append(((Define.WingSkin)(rand - 10 + 8)).ToString());
                                type.Append("Wing");
                            }

                            grade = 5;

                            break;
                        case 2://LegendSkin
                            rand = Random.Range(0, 9);

                            if (rand < 3)
                            {
                                index.Append(((Define.HeadSkin)(rand + 8)).ToString());
                                type.Append("Head");
                            }
                            else if (rand < 6)
                            {
                                index.Append(((Define.ClothSkin)(rand - 3 + 13)).ToString());
                                type.Append("Cloth");
                            }
                            else
                            {
                                index.Append(((Define.WingSkin)(rand - 6 + 13)).ToString());
                                type.Append("Wing");
                            }

                            grade = 10;
                            break;
                    }

                    //이미지 설정 > 수정 필요
                    switch (type.ToString())
                    {
                        case "Head":

                            ResultImage[i].transform.GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.head_skin_sprite[index.ToString()];

                            if (DataManager.Single.Data.inGameData.itemList.headItem.Contains(index.ToString()))
                                DataManager.Single.Data.inGameData.cost.gachaPiece += grade;
                            else
                                DataManager.Single.Data.inGameData.itemList.headItem.Add(index.ToString());

                            break;
                        case "Cloth":

                            ResultImage[i].transform.GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.cloth_skin_sprite[index.ToString()];

                            if (DataManager.Single.Data.inGameData.itemList.clothItem.Contains(index.ToString()))
                                DataManager.Single.Data.inGameData.cost.gachaPiece += grade;
                            else
                                DataManager.Single.Data.inGameData.itemList.clothItem.Add(index.ToString());

                            break;
                        case "Wing":

                            ResultImage[i].transform.GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.wing_skin_sprite[index.ToString()];

                            if (DataManager.Single.Data.inGameData.itemList.wingItem.Contains(index.ToString()))
                                DataManager.Single.Data.inGameData.cost.gachaPiece += grade;
                            else
                                DataManager.Single.Data.inGameData.itemList.wingItem.Add(index.ToString());

                            break;
                    }
                }
                else if(result < 8)
                {
                    ResultImage[i].transform.GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.sprite[((Define.GachaShop)result).ToString()];

                    switch (result)
                    {
                        case 3:
                            DataManager.Single.Data.inGameData.inGameItem.coinItemAmount++;
                            break;
                        case 4:
                            DataManager.Single.Data.inGameData.inGameItem.timeItemAmount++;
                            break;
                        case 5:
                            DataManager.Single.Data.inGameData.inGameItem.shieldItemAmount++;
                            break;
                        case 6:
                            DataManager.Single.Data.inGameData.inGameItem.saveItemAmount++;
                            break;
                        case 7:
                            DataManager.Single.Data.inGameData.inGameItem.boostItemAmount++;
                            break;
                    }
                }
                else
                {
                    ResultImage[i].transform.GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.sprite[((Define.GachaShop)result).ToString()];

                    if (result == 8)
                        DataManager.Single.Data.inGameData.cost.gachaPiece += 3;
                    else
                        DataManager.Single.Data.inGameData.cost.gachaPiece += 5;
                }
            }

            
        }
    }

    int Gacha()
    {
        float rand = Random.Range(0.0f, 100.0f);
        float cnt = 0f;

        for(int i=0; i < gachaPercent.Length; i++)
        {
            cnt += gachaPercent[i];
            if (cnt >= rand)
                return i;
        }

        return Random.Range(0, 10);
    }
}
