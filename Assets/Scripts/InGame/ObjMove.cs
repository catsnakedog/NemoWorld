using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMove : MonoBehaviour
{
    Action ObjAction;
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

    float xPlus;
    float yPlus;

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

    IEnumerator Move()
    { 
        float waitTime = (float)(distance / speed) / (float)number;

        if (direction == "Up")
        {
            xPlus = 0;
            yPlus = distance / number;
        }
        else if (direction == "Down")
        {
            xPlus = 0;
            yPlus = - distance / number;
        }
        else if (direction == "Left")
        {
            xPlus = - distance / number;
            yPlus = 0;
        }
        else if (direction == "Right")
        {
            xPlus = distance / number;
            yPlus = 0;
        }

        for (int i = 0; i < number; i++)
        {
            yield return new WaitForSeconds(waitTime);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + xPlus, gameObject.transform.position.y + yPlus, gameObject.transform.position.z);
        }


        if (direction == "Up")
        {
            direction = "Down";
        }
        else if (direction == "Down")
        {
            direction = "Up";
        }
        else if (direction == "Left")
        {
            direction = "Right";
        }
        else if (direction == "Right")
        {
            direction = "Left";
        }

        ObjCoroutine = StartCoroutine(Move());
    }

    void ObjStart()
    {
        if((transform.position.x - ch.transform.position.x) <= whatDistanceItStart)
        {
            ObjCoroutine = StartCoroutine(Move());
            ObjAction -= ObjStart;
        }
    }
}