using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    JsonManager jsonManager; // json���� ���� �о���ų� �����ϴ� JsonManager
    public SaveDataClass saveData; // �����͸� �����ϴ� ������ SaveDataClass
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

        saveData = new SaveDataClass();
        jsonManager = new JsonManager();

        Load();
    }
    public void Save() // saveData�� ��ϵ� �����͵��� json�� �����Ѵ�
    {
        jsonManager.SaveJson(saveData);
    }

    public void Load() // json�� ��ϵ��ִ� �����͵��� saveData�� �����´�
    {
        saveData = jsonManager.LoadSaveData();
    }
}