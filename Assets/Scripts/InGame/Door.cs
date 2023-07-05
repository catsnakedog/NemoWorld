using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField]
    Sprite open;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ch(Clone)")
        {
            DataManager.Single.Data.inGameData.speed = 0f;
            Invoke("ImageChange", 0.5f);
        }
    }

    void ImageChange()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = open;
    }
}
