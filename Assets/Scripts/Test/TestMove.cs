using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    Action mapAction;
    [SerializeField]
    public int speed;

    private void FixedUpdate()
    {
        mapAction?.Invoke();
    }

    void Start()
    {
        init();
    }

    void init()
    {
        mapAction += PlayerMove;
    }

    void PlayerMove()
    {
        gameObject.transform.Translate(-speed * Time.deltaTime, 0f, 0f);
    }
}