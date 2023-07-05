using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerObj : MonoBehaviour
{
    Action playerAction;
    Coroutine[] playerCoroutine;
    string itemType;
    string[] items = { "ItemRed", "ItemOrange", "ItemYellow", "ItemGreen", "ItemBlue", "ItemNavy", "ItemPurple" };
    string[] colorObjs = { "Red", "Orange", "Yellow", "Green", "Blue", "Navy", "Purple" };

    private void Start()
    {
        playerCoroutine = new Coroutine[items.Length];

        DataManager.Single.Data.inGameData.speed = 2;
        DataManager.Single.Data.inGameData.color = "default";
        DataManager.Single.Data.inGameData.isGod = false;
        DataManager.Single.Data.inGameData.isPurple = false;
        DataManager.Single.Data.inGameData.isShield = false;
        DataManager.Single.Data.inGameData.jumpMaxCount = 2;
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
    }

    void PlayerHurt()
    {
        if (DataManager.Single.Data.inGameData.isGod) return;
        if (DataManager.Single.Data.inGameData.isShield)
        {
            DataManager.Single.Data.inGameData.isShield = false;
            // ΩØµÂ ¿Ã∆Â∆Æ ¡¶∞≈
            return;
        }
        // «√∑π¿ÃæÓ ¿Âæ÷π∞ √Êµπ
        DataManager.Single.Data.inGameData.crruentQuest.time -= 5;
        DataManager.Single.Data.inGameData.speed -= 1;
        StartCoroutine(SpeedUp());
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
        // æ∆¿Ã≈€ ≈âµÊ ¿Ã∆Â∆Æ
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
            if (DataManager.Single.Data.inGameData.speed >= 3f)
            {
                DataManager.Single.Data.inGameData.speed = 3f;
                break;
            }
            DataManager.Single.Data.inGameData.speed += 0.1f;
        }
    }

    #region item

    IEnumerator ItemRed()
    {
        DataManager.Single.Data.inGameData.speed = 5;
        yield return new WaitForSeconds(5f);
        DataManager.Single.Data.inGameData.speed = 3;
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
        DataManager.Single.Data.inGameData.speed = 2;
        yield return new WaitForSeconds(5f);
        DataManager.Single.Data.inGameData.speed = 3;
    }
    IEnumerator ItemBlue()
    {
        DataManager.Single.Data.inGameData.isShield = true;
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
