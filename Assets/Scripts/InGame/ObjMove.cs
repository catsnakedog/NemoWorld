using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMove : MonoBehaviour
{
    Coroutine ObjCoroutine;

    [SerializeField]
    string direction;
    [SerializeField]
    float distance;
    [SerializeField]
    float time;
    [SerializeField]
    int number = 60;

    float xPlus;
    float yPlus;

    private void Start()
    {
        ObjCoroutine = StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        float waitTime = time / number;

        if (direction == "Up")
        {
            xPlus = 0;
            yPlus = distance / number;
        }
        else if (direction == "Down")
        {
            xPlus = 0;
            yPlus = - distance / number;
        }
        else if (direction == "Left")
        {
            xPlus = - distance / number;
            yPlus = 0;
        }
        else if (direction == "Right")
        {
            xPlus = distance / number;
            yPlus = 0;
        }

        for (int i = 0; i < number; i++)
        {
            yield return new WaitForSeconds(waitTime);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + xPlus, gameObject.transform.position.y + yPlus, gameObject.transform.position.z);
        }


        if (direction == "Up")
        {
            direction = "Down";
        }
        else if (direction == "Down")
        {
            direction = "Up";
        }
        else if (direction == "Left")
        {
            direction = "Right";
        }
        else if (direction == "Right")
        {
            direction = "Left";
        }

        ObjCoroutine = StartCoroutine(Move());
    }
}