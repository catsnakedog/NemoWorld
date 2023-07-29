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
    Animator playerAnimation, armAnimation;
    GameObject cam;

    private void Start()
    {
        DataManager.Single.Data.inGameData.jumpMaxCount = 2;
        DataManager.Single.Data.inGameData.moveAmount = 0;
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        armAnimation = transform.Find("arm").gameObject.GetComponent<Animator>();
        cam = GameObject.FindWithTag("MainCamera");
        cam.transform.position = new Vector3(0f, 0.6f, -10f);
    }

    private void Update()
    {
        cam.transform.position = new Vector3(transform.position.x + 5.5f, 0.6f, -10f);
    }

    private void FixedUpdate()
    {
        gameObject.transform.Translate(DataManager.Single.Data.inGameData.speed * Time.deltaTime, 0f, 0f);
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

            //Run Animation
            playerAnimation.SetBool(Define.PlayerAnim.Jump.ToString(), false);
            armAnimation.SetBool(Define.PlayerAnim.Jump.ToString(), false);
        }
    }

    public void Jump()
    {
        if(jumpCount < DataManager.Single.Data.inGameData.jumpMaxCount)
        {
            MainController.main.sound.Play("jumpSFX");

            //Jump Animation
            playerAnimation.SetBool(Define.PlayerAnim.Jump.ToString(), true);
            armAnimation.SetBool(Define.PlayerAnim.Jump.ToString(), true);

            rb.velocity = new Vector3(0, jumpPower, 0);
            jumpCount++;
            DataManager.Single.Data.missionData.jumpCount++;
            if (!DataManager.Single.Data.inGameData.isFever)
                DataManager.Single.Data.inGameData.fever++;
        }
    }

    private Vector2 boxCastSize = new Vector2(0.9f, 0.05f);
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