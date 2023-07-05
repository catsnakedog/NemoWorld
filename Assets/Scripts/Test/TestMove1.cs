using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove1 : MonoBehaviour
{
    [SerializeField]
    float jumpPower;

    int jumpCount;
    int jumpMaxCount;
    Rigidbody2D rb;

    private void Start()
    {
        jumpMaxCount = 2;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Land")
        {
            jumpCount = 0;
        }
    }

    public void Jump()
    {
        if (jumpCount < jumpMaxCount)
        {
            // 점프 에니메이션
            rb.velocity = new Vector3(0, jumpPower, 0);
            jumpCount++;
        }
    }
}