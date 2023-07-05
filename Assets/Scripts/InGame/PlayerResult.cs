using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResult : MonoBehaviour
{
    Action playerAction;

    private void Start()
    {
        playerAction += isFall;
        playerAction += isTimeOut;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Door")
        {
            Invoke("Clear", 1f);
            playerAction = null;
        }
    }

    void isFall()
    {
        if (gameObject.transform.position.y < -4f)
        {
            Die();
        }
    }

    void isTimeOut()
    {
        if (DataManager.Single.Data.inGameData.crruentQuest.time <= 0)
        {
            Die();
        }
    }

    void Clear()
    {
        DataManager.Single.Data.inGameData.result = "clear";
        Destroy(GameObject.FindWithTag("Level2").transform.GetChild(0).gameObject);
        Transform[] transforms = GameObject.FindWithTag("Map").GetComponentsInChildren<Transform>();
        for (int i = 1; i < transforms.Length; i++)
        {
            Destroy(transforms[i].gameObject);
        }
        Destroy(GameObject.FindWithTag("Ch").transform.GetChild(0).gameObject);

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