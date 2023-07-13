using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    int energyTime;
    private void Start()
    {
        energyTime = 5;

        TimeSpan timespan;
        DateTime userIndate;
        DateTime now;

        now = DateTime.Now;
        userIndate = Convert.ToDateTime(DataManager.Single.Data.timeData.beforeTime);

        timespan = now - userIndate;

        DataManager.Single.Data.inGameData.cost.energy += (int)(timespan.TotalMinutes / energyTime);

        TimeSpan after = new TimeSpan(0, (int)(timespan.TotalMinutes % energyTime), 0);
        after = now - DateTime.Parse(after.ToString());
        DataManager.Single.Data.timeData.beforeTime = DateTime.Parse(after.ToString()).ToString();

        DataManager.Single.Save();
    }
}
