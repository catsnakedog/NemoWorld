using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjManager : MonoBehaviour
{
    List<int> DList;

    [SerializeField]
    List<GameObject> ObjList2;

    void Start()
    {
        DList = new List<int> ();
        ObjList2 = new List<GameObject>();
    }

    void Update()
    {
        List<GameObject> objs = DataManager.Single.Data.inGameData.ObjList;

        for (int i = 0; i < DataManager.Single.Data.inGameData.ObjList.Count; i++)
        {
            if (objs[i].transform.position.x < transform.position.x + 14f)
            {
                objs[i].SetActive(true);
                if(objs[i].GetComponent<ObjMove>() != null)
                {
                    objs[i].GetComponent<ObjMove>().Init();
                }
                if (objs[i].GetComponent<ObjMove2>() != null)
                {
                    objs[i].GetComponent<ObjMove2>().Init();
                }

                ObjList2.Add(objs[i]);
                DList.Add(i);
            }
        }

        DList.Sort(new Comparison<int>((n1, n2) => n2.CompareTo(n1)));

        foreach (int a in DList)
        {
            DataManager.Single.Data.inGameData.ObjList.RemoveAt(a);
        }

        DList.Clear();

        for (int i = 0; i < ObjList2.Count; i++)
        {
            if (ObjList2[i].transform.position.x < transform.position.x -14f)
            {
                ObjList2[i].SetActive(false);
                DList.Add(i);
            }
        }

        DList.Sort(new Comparison<int>((n1, n2) => n2.CompareTo(n1)));

        foreach (int a in DList)
        {
            ObjList2.RemoveAt(a);
        }

        DList.Clear();
    }
}
