using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMove2 : MonoBehaviour
{
    Action ObjAction;
    Action ObjFixedAction;
    GameObject ch;
    Coroutine ObjCoroutine;

    [SerializeField]
    string direction;
    [SerializeField]
    float distance;
    [SerializeField]
    float speed;
    [SerializeField]
    float whatDistanceItStart;
    [SerializeField]
    int number = 60;

    private void Start()
    {
        DataManager.Single.Data.inGameData.ObjList.Add(gameObject);

        ch = GameObject.FindWithTag("Ch").transform.GetChild(0).gameObject;

        gameObject.SetActive(false);
    }

    public void Init()
    {
        ObjAction += ObjStart;
    }

    private void Update()
    {
        ObjAction?.Invoke();
    }

    private void FixedUpdate()
    {
        ObjFixedAction?.Invoke();
    }

    void Move()
    {
        if (direction == "Up")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + Time.deltaTime * speed, 0);
        }
        else if (direction == "Down")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - Time.deltaTime * speed, 0);
        }
        else if (direction == "Left")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - Time.deltaTime * speed, gameObject.transform.position.y, 0);
        }
        else if (direction == "Right")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + Time.deltaTime * speed, gameObject.transform.position.y, 0);
        }
    }

    void ObjStart()
    {
        if ((transform.position.x - ch.transform.position.x) <= whatDistanceItStart)
        {
            ObjAction -= ObjStart;
            ObjFixedAction += Move;
        }
    }
}