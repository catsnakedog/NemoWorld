using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjBlack : MonoBehaviour
{
    SpriteRenderer sr;

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(DataManager.Single.Data.inGameData.isPurple)
        {
            sr.color = Color.black;
        }
        else
        {
            sr.color = Color.white;
        }
    }
}
