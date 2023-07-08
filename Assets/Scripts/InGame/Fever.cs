using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fever : MonoBehaviour
{
    [SerializeField]
    float feverTime;

    Action feverAction;
    void Update()
    {
        feverAction?.Invoke();
    }

    private void Start()
    {
        feverAction += FeverCheck;
    }

    void FeverCheck()
    {
        if(DataManager.Single.Data.inGameData.fever >= 20)
        {
            feverAction -= FeverCheck;
            StartCoroutine(FeverStart());
        }
    }

    IEnumerator FeverStart()
    {
        DataManager.Single.Data.inGameData.isFever = true;
        DataManager.Single.Data.inGameData.isGod = true;
        for(int i= 0; i < 20; i++)
        {
            yield return new WaitForSeconds(feverTime / 20);
            DataManager.Single.Data.inGameData.fever--;
        }
        DataManager.Single.Data.inGameData.fever = 0;
        DataManager.Single.Data.inGameData.isGod = false;
        feverAction += FeverCheck;
        DataManager.Single.Data.inGameData.isFever = false;
    }
}