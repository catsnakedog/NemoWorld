using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCutToonImageChange : MonoBehaviour
{
    public List<Sprite> cutToons;
    int num = 0;
    void Start()
    {
        num = 0;
    }

    public void Show()
    {
        MainController.main.sound.Play("buttonSFX");
        if (num == cutToons.Count)
        {
            gameObject.SetActive(false);
            return;
        }
        gameObject.GetComponent<Image>().sprite = cutToons[num];
        num++;
    }
}
