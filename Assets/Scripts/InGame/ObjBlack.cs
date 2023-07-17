using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjBlack : MonoBehaviour
{
    SpriteRenderer sr;
    bool isActive;

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(DataManager.Single.Data.inGameData.isPurple)
        {
            if(!isActive)
            {
                StartCoroutine(PurpleEffect());
                isActive = true;
            }
        }
    }

    IEnumerator PurpleEffect()
    {
        Sprite temp  = sr.sprite;
        sr.sprite = MainController.main.resource.sprite["EffectSaw"];
        yield return new WaitForSeconds(5f);
        sr.sprite = temp;
        isActive = false;
    }
}
