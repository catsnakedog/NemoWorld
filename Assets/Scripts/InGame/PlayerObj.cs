using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PlayerObj : MonoBehaviour
{
    [SerializeField]
    int redSpeed;
    [SerializeField]
    int greenSpeed;

    Action playerAction;
    Coroutine[] playerCoroutine;

    string itemType;
    string[] items = { "ItemRed", "ItemOrange", "ItemYellow", "ItemGreen", "ItemBlue", "ItemNavy", "ItemPurple" };
    string[] colorObjs = { "Red", "Orange", "Yellow", "Green", "Blue", "Navy", "Purple" };

    GameObject shield;
    SpriteRenderer effect;

    Animator playerAnimation;

    public InGameUISetting gameUISetting;

    bool isBoost;

    private void Start()
    {
        playerCoroutine = new Coroutine[items.Length];
        playerAnimation = GetComponent<Animator>();
        shield = transform.GetChild(1).gameObject;
        effect = transform.GetChild(2).GetComponent<SpriteRenderer>();

        DataManager.Single.Data.inGameData.inGameItem.shieldItem = DataManager.Single.Data.inGameData.inGameItem.isUseShieldItem;
        DataManager.Single.Data.inGameData.inGameItem.saveItem = DataManager.Single.Data.inGameData.inGameItem.isUseSaveItem;
        DataManager.Single.Data.inGameData.inGameItem.coinItem = DataManager.Single.Data.inGameData.inGameItem.isUseCoinItem;
        DataManager.Single.Data.inGameData.inGameItem.timeItem = DataManager.Single.Data.inGameData.inGameItem.isUseTimeItem;
        DataManager.Single.Data.inGameData.inGameItem.boostItem = DataManager.Single.Data.inGameData.inGameItem.isUseBoostItem;

        DataManager.Single.Data.inGameData.isGreenItem = false;
        DataManager.Single.Data.inGameData.isRedItem = false;
        DataManager.Single.Data.inGameData.speed = 4;
        DataManager.Single.Data.inGameData.color = "default";
        DataManager.Single.Data.inGameData.isGod = false;
        DataManager.Single.Data.inGameData.isPurple = false;
        DataManager.Single.Data.inGameData.isItem = false;
        isBoost = false;
        if (DataManager.Single.Data.inGameData.inGameItem.shieldItem)
        {
            DataManager.Single.Data.inGameData.isShield = true;
            shield.SetActive(true);
        }
        else
        {
            DataManager.Single.Data.inGameData.isShield = false;
        }
        if (DataManager.Single.Data.inGameData.inGameItem.timeItem)
        {
            DataManager.Single.Data.inGameData.crruentQuest.time += 15;
        }
        if (DataManager.Single.Data.inGameData.inGameItem.boostItem)
        {
            isBoost = true;
            StartCoroutine(Boost());
        }
        DataManager.Single.Data.inGameData.isFever = false;
        DataManager.Single.Data.inGameData.isHit = false;
        DataManager.Single.Data.inGameData.fever = 0;
        DataManager.Single.Data.inGameData.jumpMaxCount = 2;
        DataManager.Single.Data.inGameData.coinGetAmount = 0;

        if(DataManager.Single.Data.inGameData.itemList.IsCommonSkinSetComplete())
        {
            DataManager.Single.Data.inGameData.crruentQuest.time += 5;
        }

        if (DataManager.Single.Data.inGameData.itemList.IsLegendSkinSetComplete())
        {
            DataManager.Single.Data.inGameData.crruentQuest.time += 15;
        }
    }

    IEnumerator Boost()
    {
        effect.gameObject.SetActive(true);
        effect.GetComponent<SpriteRenderer>().sprite = MainController.main.resource.sprite["EffectFever"];
        DataManager.Single.Data.inGameData.speed = 6f;
        yield return new WaitForSeconds(10f);
        DataManager.Single.Data.inGameData.speed = 4f;
        isBoost = false;
        effect.GetComponent<SpriteRenderer>().sprite = null;
    }


    private void FixedUpdate()
    {
        DataManager.Single.Data.inGameData.moveAmount += DataManager.Single.Data.inGameData.speed * Time.deltaTime;
        playerAction?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D Obj)
    {
        if (items.Contains(Obj.name))
        {
            if(isBoost)
            {
                if(Obj.name == "ItemRed" || Obj.name == "ItemGreen")
                {
                    return;
                }
            }
            itemType = Obj.name;
            Obj.gameObject.SetActive(false);
            PlayerGetItem();
        }
        else if (colorObjs.Contains(Obj.name))
        {
            if (isBoost)
            {
                return;
            }
            if (Obj.name != DataManager.Single.Data.inGameData.color)
                PlayerHurt();
        }
        else if (Obj.name == "Obj")
        {
            if (isBoost)
            {
                return;
            }
            PlayerHurt();
        }
        else if (Obj.name == "GoldCoin")
        {
            GoldCoinGet();
            Obj.gameObject.SetActive(false);
        }
        else if (Obj.name == "SilverCoin")
        {
            SilverCoinGet();
            Obj.gameObject.SetActive(false);
        }
    }

    void SilverCoinGet()
    {
        MainController.main.sound.Play("coinSFX");
        //Get Coin Animation
        playerAnimation.SetTrigger(Define.PlayerAnim.CoinGet.ToString());
        if(DataManager.Single.Data.inGameData.isPurple)
        {
            DataManager.Single.Data.inGameData.coinGetAmount += 2;
        }
        else
        {
            DataManager.Single.Data.inGameData.coinGetAmount += 1;
        }
        DataManager.Single.Data.missionData.silverCoinCount++;
        gameUISetting.CoinUI();
    }

    void GoldCoinGet()
    {
        MainController.main.sound.Play("coinSFX");
        //Get Coin Animation
        playerAnimation.SetTrigger(Define.PlayerAnim.CoinGet.ToString());
        if (DataManager.Single.Data.inGameData.isPurple)
        {
            DataManager.Single.Data.inGameData.coinGetAmount += 10;
        }
        else
        {
            DataManager.Single.Data.inGameData.coinGetAmount += 5;
        }
        gameUISetting.CoinUI();
    }

    void PlayerHurt()
    {
        if (DataManager.Single.Data.inGameData.isGod) return;
        if (DataManager.Single.Data.inGameData.isHit) return;
        if (DataManager.Single.Data.inGameData.isShield)
        {
            MainController.main.sound.Play("shieldBreakSFX");
            DataManager.Single.Data.inGameData.isShield = false;
            shield.SetActive(false);
            return;
        }

        DataManager.Single.Data.missionData.hitCount++;
        DataManager.Single.Data.inGameData.isTimeDown = true;

        MainController.main.sound.Play("hitSFX");

        DataManager.Single.Data.inGameData.crruentQuest.time -= 5;
        DataManager.Single.Data.inGameData.speed -= 1;
        StartCoroutine(SpeedUp());
        StartCoroutine(HitEffect());
    }

    void PlayerGetItem()
    {
        MainController.main.sound.Play("itemSFX");
        if (playerCoroutine[Array.IndexOf(items, itemType)] != null)
        {
            StopCoroutine(playerCoroutine[Array.IndexOf(items, itemType)]);


            if (itemType == "ItemRed")
            {
                DataManager.Single.Data.inGameData.isRedItem = false;
                if (playerCoroutine[Array.IndexOf(items, "ItemGreen")] != null)
                {
                    StopCoroutine(playerCoroutine[Array.IndexOf(items, "ItemGreen")]);
                    DataManager.Single.Data.inGameData.isGreenItem = false;
                }
            }
            if (itemType == "ItemGreen")
            {
                DataManager.Single.Data.inGameData.isGreenItem = false;
                if (playerCoroutine[Array.IndexOf(items, "ItemRed")] != null)
                {
                    StopCoroutine(playerCoroutine[Array.IndexOf(items, "ItemRed")]);
                    DataManager.Single.Data.inGameData.isRedItem = false;
                }
            }
        }
        //Get Item Animation
        playerAnimation.SetTrigger(Define.PlayerAnim.CoinGet.ToString());

        StringBuilder sb = new StringBuilder(itemType);
        sb.Remove(0, 4);
        DataManager.Single.Data.inGameData.color = sb.ToString();

        sb.Clear();
        sb.Append("Effect");
        sb.Append(DataManager.Single.Data.inGameData.color.ToString());
        if(!DataManager.Single.Data.inGameData.isFever)
        {
            effect.sprite = MainController.main.resource.sprite[sb.ToString()];
        }
        effect.gameObject.SetActive(true);

        playerCoroutine[Array.IndexOf(items, itemType)] = StartCoroutine(itemType);
    }

    IEnumerator SpeedUp()
    {
        for(int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.1f);
            DataManager.Single.Data.inGameData.speed += 0.1f;
        }

        if(DataManager.Single.Data.inGameData.isRedItem)
            DataManager.Single.Data.inGameData.speed = 6f;
        else if (DataManager.Single.Data.inGameData.isGreenItem)
            DataManager.Single.Data.inGameData.speed = 2f;
        else
            DataManager.Single.Data.inGameData.speed = 4f;
    }

    IEnumerator HitEffect()
    {
        bool flag = false;
        DataManager.Single.Data.inGameData.isHit = true;
        for (int i = 0; i < 5; i++)
        {
            float a;
            if (flag)
                a = 0.3f;
            else
                a = 1f;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(gameObject.GetComponent<SpriteRenderer>().color.r, gameObject.GetComponent<SpriteRenderer>().color.g, gameObject.GetComponent<SpriteRenderer>().color.b, a);
            yield return new WaitForSeconds(0.2f);
            flag = !flag;
        }
        DataManager.Single.Data.inGameData.isHit = false;
    }

    #region item

    IEnumerator ItemRed()
    {
        DataManager.Single.Data.inGameData.isRedItem = true;
        DataManager.Single.Data.inGameData.speed = redSpeed;
        yield return new WaitForSeconds(5f);
        DataManager.Single.Data.inGameData.speed = 4;
        DataManager.Single.Data.inGameData.isRedItem = false;
    }
    IEnumerator ItemOrange()
    {
        DataManager.Single.Data.inGameData.isItem = true;
        DataManager.Single.Data.inGameData.jumpMaxCount = 3;
        yield return new WaitForSeconds(5f);
        DataManager.Single.Data.inGameData.jumpMaxCount = 2;
    }
    IEnumerator ItemYellow()
    {
        DataManager.Single.Data.inGameData.isTimeUp = true;
        DataManager.Single.Data.inGameData.crruentQuest.time += 5;
        yield return new WaitForSeconds(0f);
    }
    IEnumerator ItemGreen()
    {
        DataManager.Single.Data.inGameData.isGreenItem = true;
        DataManager.Single.Data.inGameData.speed = greenSpeed;
        yield return new WaitForSeconds(5f);
        DataManager.Single.Data.inGameData.speed = 4;
        DataManager.Single.Data.inGameData.isGreenItem = false;
    }
    IEnumerator ItemBlue()
    {
        DataManager.Single.Data.inGameData.isShield = true;
        shield.SetActive(true);
        yield return new WaitForSeconds(0f);
    }
    IEnumerator ItemNavy()
    {
        DataManager.Single.Data.inGameData.isItem = true;
        for (int i=0;i < 10; i++)
        {
            DataManager.Single.Data.inGameData.isGod = true;
            yield return new WaitForSeconds(0.5f);
        }
        DataManager.Single.Data.inGameData.isGod = false;
    }
    IEnumerator ItemPurple()
    {
        DataManager.Single.Data.inGameData.isItem = true;
        DataManager.Single.Data.inGameData.isPurple = true;
        yield return new WaitForSeconds(5f);
        DataManager.Single.Data.inGameData.isPurple = false;
    }

    #endregion
}
