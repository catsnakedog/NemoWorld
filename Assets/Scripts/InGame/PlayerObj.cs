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

    Animator playerAnimation;

    private void Start()
    {
        playerCoroutine = new Coroutine[items.Length];
        playerAnimation = GetComponent<Animator>();
        shield = transform.GetChild(0).GetChild(3).gameObject;

        DataManager.Single.Data.inGameData.inGameItem.shieldItem = DataManager.Single.Data.inGameData.inGameItem.isUseShieldItem;
        DataManager.Single.Data.inGameData.inGameItem.saveItem = DataManager.Single.Data.inGameData.inGameItem.isUseSaveItem;
        DataManager.Single.Data.inGameData.inGameItem.coinItem = DataManager.Single.Data.inGameData.inGameItem.isUseCoinItem;

        DataManager.Single.Data.inGameData.speed = 4;
        DataManager.Single.Data.inGameData.color = "default";
        DataManager.Single.Data.inGameData.isGod = false;
        DataManager.Single.Data.inGameData.isPurple = false;
        if(DataManager.Single.Data.inGameData.inGameItem.shieldItem)
        {
            DataManager.Single.Data.inGameData.isShield = true;
            shield.SetActive(true);
        }
        else
        {
            DataManager.Single.Data.inGameData.isShield = false;
        }
        DataManager.Single.Data.inGameData.isFever = false;
        DataManager.Single.Data.inGameData.isHit = false;
        DataManager.Single.Data.inGameData.fever = 0;
        DataManager.Single.Data.inGameData.jumpMaxCount = 2;
        DataManager.Single.Data.inGameData.coinGetAmount = 0;
    }

    private void FixedUpdate()
    {
        playerAction?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D Obj)
    {
        if (items.Contains(Obj.name))
        {
            itemType = Obj.name;
            PlayerGetItem();
        }
        else if (colorObjs.Contains(Obj.name))
        {
            if (Obj.name != DataManager.Single.Data.inGameData.color)
                PlayerHurt();
        }
        else if (Obj.name == "Obj")
        {
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
        playerAnimation.SetTrigger(Define.PlayerAnim.CoinGet.ToString());
        DataManager.Single.Data.inGameData.coinGetAmount += 1;
        DataManager.Single.Data.missionData.silverCoinCount++;
    }

    void GoldCoinGet()
    {
        playerAnimation.SetTrigger(Define.PlayerAnim.CoinGet.ToString());
        DataManager.Single.Data.inGameData.coinGetAmount += 5;
    }

    void PlayerHurt()
    {
        if (DataManager.Single.Data.inGameData.isGod) return;
        if (DataManager.Single.Data.inGameData.isHit) return;
        if (DataManager.Single.Data.inGameData.isShield)
        {
            DataManager.Single.Data.inGameData.isShield = false;
            shield.SetActive(false);
            return;
        }

        DataManager.Single.Data.missionData.hitCount++;
        // 플레이어 장애물 충돌
        playerAnimation.SetTrigger(Define.PlayerAnim.Hit.ToString());

        DataManager.Single.Data.inGameData.crruentQuest.time -= 5;
        DataManager.Single.Data.inGameData.speed -= 1;
        StartCoroutine(SpeedUp());
        StartCoroutine(HitEffect());
    }

    void PlayerGetItem()
    {
        if(playerCoroutine[Array.IndexOf(items, itemType)] != null)
        {
            StopCoroutine(playerCoroutine[Array.IndexOf(items, itemType)]);

            if (itemType == "ItemRed")
            {
                if (playerCoroutine[Array.IndexOf(items, "ItemGreen")] != null)
                    StopCoroutine(playerCoroutine[Array.IndexOf(items, "ItemGreen")]);
            }
            if (itemType == "ItemGreen")
            {
                if (playerCoroutine[Array.IndexOf(items, "ItemRed")] != null)
                    StopCoroutine(playerCoroutine[Array.IndexOf(items, "ItemRed")]);
            }
        }
        // 아이템 흭득 이펙트
        playerAnimation.SetTrigger(Define.PlayerAnim.CoinGet.ToString());

        StringBuilder sb = new StringBuilder(itemType);
        sb.Remove(0, 4);
        DataManager.Single.Data.inGameData.color = sb.ToString();
        playerCoroutine[Array.IndexOf(items, itemType)] = StartCoroutine(itemType);
    }

    IEnumerator SpeedUp()
    {
        for(int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.1f);
            DataManager.Single.Data.inGameData.speed += 0.1f;
        }
        if (DataManager.Single.Data.inGameData.speed >= 4f)
        {
            DataManager.Single.Data.inGameData.speed = 4f;
        }
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
        DataManager.Single.Data.inGameData.speed = redSpeed;
        yield return new WaitForSeconds(5f);
        DataManager.Single.Data.inGameData.speed = 4;
    }
    IEnumerator ItemOrange()
    {
        DataManager.Single.Data.inGameData.jumpMaxCount = 3;
        yield return new WaitForSeconds(5f);
        DataManager.Single.Data.inGameData.jumpMaxCount = 2;
    }
    IEnumerator ItemYellow()
    {
        DataManager.Single.Data.inGameData.crruentQuest.time += 5;
        yield return new WaitForSeconds(0f);
    }
    IEnumerator ItemGreen()
    {
        DataManager.Single.Data.inGameData.speed = greenSpeed;
        yield return new WaitForSeconds(5f);
        DataManager.Single.Data.inGameData.speed = 4;
    }
    IEnumerator ItemBlue()
    {
        DataManager.Single.Data.inGameData.isShield = true;
        shield.SetActive(true);
        yield return new WaitForSeconds(0f);
    }
    IEnumerator ItemNavy()
    {
        DataManager.Single.Data.inGameData.isGod = true;
        yield return new WaitForSeconds(5f);
        DataManager.Single.Data.inGameData.isGod = false;
    }
    IEnumerator ItemPurple()
    {
        DataManager.Single.Data.inGameData.isPurple = true;
        yield return new WaitForSeconds(5f);
        DataManager.Single.Data.inGameData.isPurple = false;
    }

    #endregion
}
