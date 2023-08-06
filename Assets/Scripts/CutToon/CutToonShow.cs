using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutToonShow : MonoBehaviour
{
    public List<Sprite> cutToons1;
    public List<Sprite> cutToons2;
    public List<Sprite> cutToons3;
    int num = 0;
    void Start()
    {
        num = 0;
        if(DataManager.Single.Data.inGameData.crruentQuest.stage == 1)
        {
            gameObject.GetComponent<Image>().sprite = cutToons1[num];
        }
        if (DataManager.Single.Data.inGameData.crruentQuest.stage == 2)
        {
            gameObject.GetComponent<Image>().sprite = cutToons2[num];
        }
        if (DataManager.Single.Data.inGameData.crruentQuest.stage == 3)
        {
            gameObject.GetComponent<Image>().sprite = cutToons3[num];
        }
        num = 1;
    }

    public void Show()
    {
        if (DataManager.Single.Data.inGameData.crruentQuest.stage == 1)
        {
            MainController.main.sound.Play("buttonSFX");
            if (num == cutToons1.Count)
            {
                MainController.main.sound.Play("buttonSFX");
                MainController.main.UI.UIsetting(Define.UIlevel.Level2, Define.UItype.GameResult);
                return;
            }
            gameObject.GetComponent<Image>().sprite = cutToons1[num];
            num++;
        }
        if (DataManager.Single.Data.inGameData.crruentQuest.stage == 2)
        {
            MainController.main.sound.Play("buttonSFX");
            if (num == cutToons2.Count)
            {
                MainController.main.sound.Play("buttonSFX");
                MainController.main.UI.UIsetting(Define.UIlevel.Level2, Define.UItype.GameResult);
                return;
            }
            gameObject.GetComponent<Image>().sprite = cutToons2[num];
            num++;
        }
        if (DataManager.Single.Data.inGameData.crruentQuest.stage == 3)
        {
            MainController.main.sound.Play("buttonSFX");
            if (num == cutToons3.Count)
            {
                MainController.main.sound.Play("buttonSFX");
                MainController.main.UI.UIsetting(Define.UIlevel.Level2, Define.UItype.GameResult);
                return;
            }
            gameObject.GetComponent<Image>().sprite = cutToons3[num];
            num++;
        }
    }
}
