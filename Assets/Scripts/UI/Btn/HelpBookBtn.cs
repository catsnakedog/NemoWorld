using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HelpBookBtn : EventTriggerEX
{
    [SerializeField]
    int number;

    [SerializeField]
    GameObject middle;
    [SerializeField]
    GameObject right;

    void Start()
    {
        init();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");
        right.transform.GetChild(0).gameObject.SetActive(false);
        right.transform.GetChild(1).gameObject.SetActive(false);
        right.transform.GetChild(2).gameObject.SetActive(false);
        right.transform.GetChild(3).gameObject.SetActive(false);
        right.transform.GetChild(4).gameObject.SetActive(false);

        right.transform.GetChild(number).gameObject.SetActive(true);

        StringBuilder sb = new StringBuilder("Book");
        sb.Append(number);

        middle.transform.GetChild(0).GetComponent<Image>().sprite = MainController.main.resource.sprite[sb.ToString()];
    }
}