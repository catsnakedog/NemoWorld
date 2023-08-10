using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBG : MonoBehaviour
{
    float Speed, mult, posX;
    RectTransform rt;
    GameObject ch;
    
    public void Init(float m, float s)
    {
        mult = m;
        Speed = s;

        rt = GetComponent<RectTransform>();
        ch = GameObject.FindWithTag("Ch").transform.GetChild(0).gameObject;
        posX = (Camera.main.orthographicSize * Camera.main.aspect) * 2;
    }

    // Update is called once per frame
    void Update()
    {
        //if(!DataManager.Single.Data.inGameData.result.Equals("clear") && !DataManager.Single.Data.inGameData.result.Equals("die"))
        if (Time.timeScale != 0)
        {
            if (ch != null)
            {
                if (rt.position.x < ch.transform.position.x - posX)
                {
                    rt.position = new Vector3(ch.transform.position.x + posX * 2, rt.position.y, rt.position.z);
                }
                rt.Translate(new Vector3(-(mult * Speed * DataManager.Single.Data.inGameData.speed) * Time.deltaTime, 0, 0));
            }
        }
    }
}
