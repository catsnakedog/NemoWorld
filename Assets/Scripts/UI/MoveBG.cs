using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBG : MonoBehaviour
{
    float Speed, mult, posX;
    RectTransform rt;
    
    public void Init(float m, float s)
    {
        mult = m;
        Speed = s;

        rt = GetComponent<RectTransform>();
        posX = (Camera.main.orthographicSize * Camera.main.aspect) * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (rt.position.x < -posX)
        {
            rt.position = new Vector3(posX * 2, rt.position.y, rt.position.z);
        }
        rt.Translate(new Vector3(-(mult * Speed * DataManager.Single.Data.inGameData.speed) * Time.deltaTime, 0, 0));
    }
}
