using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMove2 : MonoBehaviour
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
        ch = GameObject.FindWithTag("Ch").transform.GetChild(0).gameObject;
        ObjAction += ObjStart;
    }

    private void Update()
    {
        ObjAction?.Invoke();
    }

    IEnumerator Move()
    {
        float waitTime = (distance / speed) / number;

        if (direction == "Up")
        {
            xPlus = 0;
            yPlus = distance / number;
        }
        else if (direction == "Down")
        {
            xPlus = 0;
            yPlus = -distance / number;
        }
        else if (direction == "Left")
        {
            xPlus = -distance / number;
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
    }

    void ObjStart()
    {
        if ((transform.position.x - ch.transform.position.x) <= whatDistanceItStart)
        {
            ObjCoroutine = StartCoroutine(Move());
            ObjAction -= ObjStart;
        }
    }
}