using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Fever : MonoBehaviour
{
    [SerializeField]
    float feverTime;

    GameObject effect;
    Action feverAction;

    bool isFever;
    void Update()
    {
        feverAction?.Invoke();
    }

    private void Start()
    {
        isFever = false;
        effect = transform.GetChild(2).gameObject;
        StartCoroutine(EffectFever());
    }

    public void FeverCheck()
    {
        if (isFever) return;
        if(DataManager.Single.Data.inGameData.fever >= 20)
        {
            isFever = true;
            StartCoroutine(FeverStart());
        }
    }

    IEnumerator FeverStart()
    {
        feverTime = 2;
        if (DataManager.Single.Data.inGameData.itemList.IsEpicSkinSetComplete())
        {
            feverTime = 3;
        }

        effect.GetComponent<SpriteRenderer>().sprite = MainController.main.resource.sprite["EffectFever"];
        DataManager.Single.Data.inGameData.isFever = true;
        DataManager.Single.Data.inGameData.isGod = true;
        for(int i= 0; i < 20; i++)
        {
            yield return new WaitForSeconds(feverTime / 20);
            DataManager.Single.Data.inGameData.fever--;
        }
        StringBuilder sb = new StringBuilder("Effect");
        sb.Append(DataManager.Single.Data.inGameData.color);
        DataManager.Single.Data.inGameData.fever = 0;
        DataManager.Single.Data.inGameData.isGod = false;
        DataManager.Single.Data.inGameData.isFever = false;
        effect.transform.localRotation = Quaternion.identity;
        effect.GetComponent<SpriteRenderer>().sprite = MainController.main.resource.sprite[sb.ToString()];
        isFever = false;
    }

    IEnumerator EffectFever()
    {
        float a = 0f;
        while(true)
        {
            effect.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, a));
            yield return new WaitForSeconds(feverTime / 60f);
            a += 4f;
        }
    }
}