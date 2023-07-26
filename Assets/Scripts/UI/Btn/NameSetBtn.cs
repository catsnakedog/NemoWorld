using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;

public class NameSetBtn : MonoBehaviour
{
    TMP_InputField name;
    GameObject warning;
    bool flag;

    void Start()
    {
        flag = false;
        name = transform.GetChild(3).GetComponent<TMP_InputField>();
        warning = transform.GetChild(5).gameObject;
    }

    public void NameCheck()
    {
        CheckNickName();
    }

    public void CheckNickName()
    {
        if (flag) return;
        flag = true;
        MainController.main.sound.Play("buttonSFX");
        string idChecker = Regex.Replace(name.text, @"[ ^0-9a-zA-Z°¡-ÆR\& ]{1,10}", "", RegexOptions.Singleline);
        if ((idChecker != "") || name.text.Contains(" "))
        {
            name.text.Remove(0, name.text.Length);
            name.text = "";
            warning.GetComponent<TMP_Text>().text = "Æ¯¼ö¹®ÀÚ°¡ ¶Ç´Â °ø¹éÀº »ç¿ëÀÌ ºÒ°¡´ÉÇÕ´Ï´Ù.";
            flag = false;
            return;
        }

        DataManager.Single.Data.inGameData.name = name.text;
        StartCoroutine(DataPost());
    }

    const string URL = "https://script.google.com/macros/s/AKfycbzD6pKj5-JGVICcb4Jkl39AzsJkjyhxYZ2-SKk__8G5RDpS6xUpna0tBm1tYQ4MFHo/exec";

    IEnumerator DataPost()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", DataManager.Single.Data.inGameData.name);
        form.AddField("type", "nameCheck");

        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.isDone) NameDataCheck(www.downloadHandler.text);
            else StartCoroutine(DataPost());
        }
    }

    void NameDataCheck(string text)
    {
        Debug.Log(text);
        if(text == "wrong")
        {
            flag = false;
            warning.GetComponent<TMP_Text>().text = "Áßº¹µÈ ´Ð³×ÀÓÀÔ´Ï´Ù.";
        }
        else
        {
            // ´Ð³×ÀÓ »ý¼º ¿Ï·á
            DataManager.Single.Data.inGameData.isFirst = false;
            MainController.main.UI.UIsetting(Define.UIlevel.Level1, Define.UItype.MainLobby);
        }
    }
}