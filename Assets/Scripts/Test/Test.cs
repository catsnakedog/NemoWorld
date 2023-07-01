using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    string stageName;
    [SerializeField]
    int speed;
    void Start()
    {
        Invoke("TestPart", 2f);
    }

    void TestPart()
    {
        GameObject temp = Instantiate(Resources.Load<GameObject>("Prefabs/Map/Hard/Stage1/" + stageName), new Vector3(6f, 0f, 0f), Quaternion.identity);
        temp.transform.SetParent(transform.GetChild(0), false);
        transform.GetChild(0).GetChild(0).gameObject.AddComponent<TestMove>().speed = speed;
    }
}