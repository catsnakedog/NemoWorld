using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    JsonManager jsonManager; // json���� ���� �о���ų� �����ϴ� JsonManager
    public SaveDataClass Data; // �����͸� �����ϴ� ������ SaveDataClass
    public static DataManager Single;

    public ResourceManager resource;

    void Awake()
    {
        if (Single == null) // DataManager�� ���ϼ� ����
        {
            Single = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Data = new SaveDataClass();
        jsonManager = new JsonManager();

        Load();

        GameObject.FindWithTag("MainController").GetComponent<MainController>().init();
    }
    public void Save() // saveData�� ��ϵ� �����͵��� json�� �����Ѵ�
    {
        jsonManager.SaveJson(Data);
    }

    public void Load() // json�� ��ϵ��ִ� �����͵��� �ҷ��´�
    {
        Data = jsonManager.LoadSaveData();
    }
}