using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemCountBtn : EventTriggerEX
{
    TMP_Text count_text, price_text;
    Image image;
    private bool clickcheck;


    private void Start()
    {
        init();

        //Item Count Reset
        ItemManager.count = 1;
        count_text = GameObject.Find("Count").transform.GetChild(0).GetComponent<TMP_Text>();
        count_text.text = ItemManager.count.ToString();

        //Item Price Reset
        price_text = GameObject.Find("ItemPrice").GetComponent<TMP_Text>();
        if ((int)Enum.Parse(typeof(Define.ItemShop), ItemManager.selectItem) < 3)
            ItemManager.price = 10;
        else
            ItemManager.price = 20;
        price_text.text = (ItemManager.count * ItemManager.price).ToString();

        //Count Button Reset
        image = GetComponent<Image>();
        if (gameObject.name.Equals("Up"))
            clickcheck = true;
        else
        {
            clickcheck = false;
            image.sprite = MainController.main.resource.sprite[Define.SpriteDict.ButtonCircleGrey.ToString()];
        }

        ItemManager.ItemCount += ChangeSet;
    }

    
    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");

        if (gameObject.name.Equals("Up"))
        {
            ItemManager.count++;
            ItemManager.ItemCount(gameObject.name);
        }
        else if (gameObject.name.Equals("Down"))
        {
            ItemManager.count--;
            ItemManager.ItemCount(gameObject.name);
        }
    }

    public  void ChangeSet(string name)
    {
        if(gameObject.name.Equals(name))
            if (!clickcheck)
            {
                if (name.Equals("Up")) ItemManager.count--;
                else ItemManager.count++;
                return;
            }

        
            if (gameObject.name.Equals("Up"))
            {
                if ((ItemManager.count + 1) * ItemManager.price > DataManager.Single.Data.inGameData.cost.gold)
                {
                    image.sprite = MainController.main.resource.sprite[Define.SpriteDict.ButtonCircleGrey.ToString()];
                    clickcheck = false;
                }
                else
                {
                    image.sprite = MainController.main.resource.sprite[Define.SpriteDict.ButtonCircleYellow.ToString()];
                    clickcheck = true;
                }
            }
            else if (gameObject.name.Equals("Down"))
            {
                if (ItemManager.count == 1)
                {
                    image.sprite = MainController.main.resource.sprite[Define.SpriteDict.ButtonCircleGrey.ToString()];
                    clickcheck = false;
                }
                else
                {
                    image.sprite = MainController.main.resource.sprite[Define.SpriteDict.ButtonCircleYellow.ToString()];
                    clickcheck = true;
                }
            }
        

        count_text.text = ItemManager.count.ToString();
        price_text.text = (ItemManager.count * ItemManager.price).ToString();
    }

    private void OnDestroy()
    {
        ItemManager.ItemCount -= ChangeSet;
    }
}
