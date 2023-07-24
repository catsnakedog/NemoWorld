using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCh : MonoBehaviour
{
    GameObject ch;
    Fever chFever;
    void Start()
    {
        Invoke("Init", 1f);
    }

    void Init()
    {
        ch = GameObject.FindWithTag("Ch").transform.GetChild(0).gameObject;
        chFever = ch.GetComponent<Fever>();
    }

    public void FeverStart()
    {
        if (chFever == null) return;
        chFever.FeverCheck();
    }
}