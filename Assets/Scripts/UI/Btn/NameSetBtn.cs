using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System;

public class NameSetBtn : MonoBehaviour
{
    TMP_InputField name;
    GameObject warning;

    void Start()
    {
        name = transform.GetChild(3).GetComponent<TMP_InputField>();
        warning = transform.GetChild(5).gameObject;
    }

    public void NameCheck()
    {
        CheckNickName();
    }

    public void CheckNickName()
    {
        MainController.main.sound.Play("buttonSFX");
        string idChecker = Regex.Replace(name.text, @"[ ^0-9a-zA-Z°¡-ÆR\& ]{1,10}", "", RegexOptions.Singleline);
        if ((idChecker != "") || name.text.Contains(" "))
        {
            name.text.Remove(0, name.text.Length);
            name.text = "";
            warning.SetActive(true);
            return;
        }

        DataManager.Single.Data.inGameData.name = name.text;
        // DataManager.Single.Data.inGameData.isFirst = false;
        MainController.main.UI.UIsetting(Define.UIlevel.Level1, Define.UItype.MainLobby);
    }
}
