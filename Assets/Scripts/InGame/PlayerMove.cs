using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float jumpPower;
    [SerializeField]
    int jumpMaxCount;

    int jumpCount;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Land")
        {
            jumpCount = 0;
        }
    }

    void init()
    {

    }

    public void Jump()
    {
        if(jumpCount < jumpMaxCount)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpPower, 0);
            jumpCount++;
        }
    }
}