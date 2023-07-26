using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    int energyTime;
    int maxEnergy;
    private void Start()
    {
        energyTime = 5;
        maxEnergy = 15;

        Time.timeScale = 1;

        TimeSpan timespan;
        DateTime userIndate;
        DateTime now;

        now = DateTime.Now;
        userIndate = Convert.ToDateTime(DataManager.Single.Data.timeData.beforeTime);

        timespan = now - userIndate;

        DataManager.Single.Data.inGameData.cost.energy += (int)(timespan.TotalMinutes / energyTime);

        if(DataManager.Single.Data.inGameData.cost.energy > maxEnergy)
        {
            DataManager.Single.Data.inGameData.cost.energy = maxEnergy;
        }

        TimeSpan after = new TimeSpan(0, (int)(timespan.TotalMinutes % energyTime), 0);
        after = now - DateTime.Parse(after.ToString());
        DataManager.Single.Data.timeData.beforeTime = DateTime.Parse(after.ToString()).ToString();

        DataManager.Single.Save();
    }
}
