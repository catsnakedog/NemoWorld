using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankAward : MonoBehaviour
{
    [SerializeField]
    int type;
    void Start()
    {
        
    }

    public void GetAward()
    {
        MainController.main.sound.Play("buttonSFX");
        switch (type)
        {
            case 1:
                DataManager.Single.Data.inGameData.isRankAward = false;
                DataManager.Single.Data.inGameData.cost.hatGacha += 10;
                DataManager.Single.Data.inGameData.cost.wingGacha += 10;
                DataManager.Single.Data.inGameData.cost.clothGacha += 10;
                DataManager.Single.Data.inGameData.cost.gold += 1500;
                Destroy(GameObject.FindWithTag("Level3").transform.GetChild(0).gameObject);
                return;
            case 2:
                DataManager.Single.Data.inGameData.isRankAward = false;
                DataManager.Single.Data.inGameData.cost.hatGacha += 5;
                DataManager.Single.Data.inGameData.cost.wingGacha += 5;
                DataManager.Single.Data.inGameData.cost.clothGacha += 5;
                DataManager.Single.Data.inGameData.cost.gold += 900;
                Destroy(GameObject.FindWithTag("Level3").transform.GetChild(0).gameObject);
                return;
            case 3:
                DataManager.Single.Data.inGameData.isRankAward = false;
                DataManager.Single.Data.inGameData.cost.hatGacha += 3;
                DataManager.Single.Data.inGameData.cost.wingGacha += 3;
                DataManager.Single.Data.inGameData.cost.clothGacha += 3;
                DataManager.Single.Data.inGameData.cost.gold += 600;
                Destroy(GameObject.FindWithTag("Level3").transform.GetChild(0).gameObject);
                return;
            case 4:
                DataManager.Single.Data.inGameData.isRankAward = false;
                DataManager.Single.Data.inGameData.cost.hatGacha += 1;
                DataManager.Single.Data.inGameData.cost.wingGacha += 1;
                DataManager.Single.Data.inGameData.cost.clothGacha += 1;
                DataManager.Single.Data.inGameData.cost.gold += 300;
                Destroy(GameObject.FindWithTag("Level3").transform.GetChild(0).gameObject);
                return;
            case 5:
                DataManager.Single.Data.inGameData.isRankAward = false;
                DataManager.Single.Data.inGameData.cost.gold += 200;
                Destroy(GameObject.FindWithTag("Level3").transform.GetChild(0).gameObject);
                return;
        }
    }
}
