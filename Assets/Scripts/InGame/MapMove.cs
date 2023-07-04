using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    Action mapAction;
    public int speed { get; set; }

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
        gameObject.transform.Translate(-DataManager.Single.Data.inGameData.speed * Time.deltaTime, 0f, 0f);
    }
}