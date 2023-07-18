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
            if(!IsOnGround())
            {
                return;
            }
            jumpCount = 0;
            playerAnimation.SetBool(Define.PlayerAnim.Jump.ToString(), false);
        }
    }

    public void Jump()
    {
        if(jumpCount < DataManager.Single.Data.inGameData.jumpMaxCount)
        {
            MainController.main.sound.Play("jumpSFX");
            playerAnimation.SetBool(Define.PlayerAnim.Jump.ToString(), true);
            rb.velocity = new Vector3(0, jumpPower, 0);
            jumpCount++;
            DataManager.Single.Data.missionData.jumpCount++;
            if (!DataManager.Single.Data.inGameData.isFever)
                DataManager.Single.Data.inGameData.fever++;
        }
    }

    private Vector2 boxCastSize = new Vector2(0.55f, 0.05f);
    private float boxCastMaxDistance = 0.55f;

    private bool IsOnGround()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(transform.position, boxCastSize, 0f, Vector2.down, boxCastMaxDistance, LayerMask.GetMask("Ground"));
        return (raycastHit.collider != null);
    }

    void OnDrawGizmos()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(transform.position, boxCastSize, 0f, Vector2.down, boxCastMaxDistance, LayerMask.GetMask("Ground"));

        Gizmos.color = Color.red;
        if (raycastHit.collider != null)
        {
            Gizmos.DrawRay(transform.position, Vector2.down * raycastHit.distance);
            Gizmos.DrawWireCube(transform.position + Vector3.down * raycastHit.distance, boxCastSize);
        }
        else
        {
            Gizmos.DrawRay(transform.position, Vector2.down * boxCastMaxDistance);
        }
    }
}