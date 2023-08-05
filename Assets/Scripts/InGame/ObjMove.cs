using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ObjMove : MonoBehaviour
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

    float time = 0;

    private void Start()
    {
        ch = GameObject.FindWithTag("Ch").transform.GetChild(0).gameObject;

        Init();
    }

    public void Init()
    {
        time = 0;
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
        if((transform.position.x - ch.transform.position.x) <= whatDistanceItStart)
        {
            ObjAction -= ObjStart;
            ObjFixedAction += Move;
            ObjAction += TimeCheck;
        }
    }

    void TimeCheck()
    {
        time += Time.deltaTime;
        if(time >= distance / speed)
        {
            time = 0;
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
        }
    }
}