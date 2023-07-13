using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerResult : MonoBehaviour
{
    Action playerAction;

    private void Start()
    {
        playerAction += IsFall;
        playerAction += IsTimeOut;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Door")
        {
            Invoke("Clear", 1f);
            playerAction = null;
        }
    }

    void IsFall()
    {
        if (gameObject.transform.position.y < -4f)
        {
            if(DataManager.Single.Data.inGameData.inGameItem.saveItem)
            {
                DataManager.Single.Data.inGameData.inGameItem.saveItem = false;
                playerAction -= IsFall;
                StartCoroutine(FallSave());
            }
            else
            {
                Die();
            }
        }
    }

    IEnumerator FallSave()
    {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        DataManager.Single.Data.inGameData.speed = 0;
        yield return new WaitForSeconds(2f);
        gameObject.transform.position = new Vector3(-5.5f, 2f, 0f);

        bool flag = true;

        for(int i = 0; i<5; i++)
        {
            float a;
            if (flag)
                a = 1f;
            else
                a = 0.3f;

            yield return new WaitForSeconds(0.2f);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, a);
            flag = !flag;
        }

        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        DataManager.Single.Data.inGameData.speed = 4;
        playerAction += IsFall;
    }

    void IsTimeOut()
    {
        if (DataManager.Single.Data.inGameData.crruentQuest.time <= 0)
        {
            Die();
        }
    }

    void Clear()
    {
        bool isCutToon = false;
        StringBuilder sb = new StringBuilder("stage");
        sb.Append(DataManager.Single.Data.inGameData.crruentQuest.stage);

        if(DataManager.Single.Data.inGameData.crruentQuest.gameMode == "easy")
        {
            if (!DataManager.Single.Data.inGameData.storyClearList.Contains(sb.ToString()))
            {
                DataManager.Single.Data.inGameData.storyClearList.Add(sb.ToString());
                sb.Append("EasyCutToon");
                DataManager.Single.Data.inGameData.cutToonName = sb.ToString();
                isCutToon = true;
            }
        }
        if (DataManager.Single.Data.inGameData.crruentQuest.gameMode == "hard")
        {
            if (!DataManager.Single.Data.inGameData.adventureClearList.Contains(sb.ToString()))
            {
                DataManager.Single.Data.inGameData.adventureClearList.Add(sb.ToString());
                sb.Append("HardCutToon");
                DataManager.Single.Data.inGameData.cutToonName = sb.ToString();
                isCutToon = true;
            }
        }

        DataManager.Single.Data.inGameData.result = "clear";
        Destroy(GameObject.FindWithTag("Level2").transform.GetChild(0).gameObject);
        Transform[] transforms = GameObject.FindWithTag("Map").GetComponentsInChildren<Transform>();
        for (int i = 1; i < transforms.Length; i++)
        {
            Destroy(transforms[i].gameObject);
        }
        Destroy(GameObject.FindWithTag("Ch").transform.GetChild(0).gameObject);

        if (isCutToon)
        {
            MainController.main.UI.UIsetting(Define.UIlevel.Level2, Define.UItype.CutToon);
        }
        else
            MainController.main.UI.UIsetting(Define.UIlevel.Level2, Define.UItype.GameResult);
    }

    void Die()
    {
        DataManager.Single.Data.inGameData.result = "die";
        Destroy(GameObject.FindWithTag("Level2").transform.GetChild(0).gameObject);
        Transform[] transforms = GameObject.FindWithTag("Map").GetComponentsInChildren<Transform>();
        for (int i = 1; i < transforms.Length; i++)
        {
            Destroy(transforms[i].gameObject);
        }
        Destroy(GameObject.FindWithTag("Ch").transform.GetChild(0).gameObject);

        MainController.main.UI.UIsetting(Define.UIlevel.Level2, Define.UItype.GameResult);
    }
    void Update()
    {
        playerAction?.Invoke();
    }
}
