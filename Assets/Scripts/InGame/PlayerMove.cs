using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float jumpPower;

    int jumpCount;

    private void Start()
    {
        DataManager.Single.Data.inGameData.jumpMaxCount = 2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Land")
        {
            jumpCount = 0;
        }
    }

    public void Jump()
    {
        if(jumpCount < DataManager.Single.Data.inGameData.jumpMaxCount)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpPower, 0);
            jumpCount++;
        }
    }
}