using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float jumpPower;

    int jumpCount;
    Rigidbody2D rb;
    Animator playerAnimation;

    private void Start()
    {
        DataManager.Single.Data.inGameData.jumpMaxCount = 2;
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Land")
        {
            jumpCount = 0;
            playerAnimation.SetBool(Define.PlayerAnim.Jump.ToString(), false);
        }
    }

    public void Jump()
    {
        if(jumpCount < DataManager.Single.Data.inGameData.jumpMaxCount)
        {
            playerAnimation.SetBool(Define.PlayerAnim.Jump.ToString(), true);
            rb.velocity = new Vector3(0, jumpPower, 0);
            jumpCount++;
            DataManager.Single.Data.missionData.jumpCount++;
            if (!DataManager.Single.Data.inGameData.isFever)
                DataManager.Single.Data.inGameData.fever++;
        }
    }
}