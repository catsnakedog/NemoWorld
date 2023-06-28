using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    Action mapAction;
    [SerializeField]
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
        speed = DataManager.Single.Data.inGameData.speed;
        mapAction += PlayerMove;
    }

    void PlayerMove()
    {
        gameObject.transform.Translate(-speed * Time.deltaTime, 0f, 0f);
    }
}