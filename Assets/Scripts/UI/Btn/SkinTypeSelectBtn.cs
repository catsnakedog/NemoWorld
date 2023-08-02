using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkinTypeSelectBtn : EventTriggerEX
{
    [SerializeField]
    string type;
    
    GameObject skin_prefab;

    protected void Start()
    {
        init();

        skin_prefab = Resources.Load<GameObject>("Prefabs/UI/SkinPrefab");

        if (type != "Head") return;

        Transform parent = GameObject.Find("Content").transform;
        for (int i = -1; i < (int)Define.HeadSkin.MaxCount; i++)
        {
            GameObject skin_temp = Instantiate(skin_prefab);
            skin_temp.transform.parent = parent;
            SkinSelectBtn temp;
            temp = skin_temp.AddComponent<SkinSelectBtn>();

            if(i < 0)
            {
                temp.type = "Head";
                temp.SetUI = "";
            }
            else
            {
                temp.type = "Head";
                temp.SetUI = ((Define.HeadSkin)i).ToString();
            }
        }
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");

        int cnt = 0;
        GameObject[] skin_transforms = GameObject.FindGameObjectsWithTag("Skin");
        Transform parent = GameObject.Find("Content").transform;

        if (type.Equals("Head")) cnt = (int)Define.HeadSkin.MaxCount + 1;
        else if (type.Equals("Cloth")) cnt = (int)Define.ClothSkin.MaxCount + 1;
        else if (type.Equals("Wing")) cnt = (int)Define.WingSkin.MaxCount + 1;

        skin_transforms[0].GetComponent<SkinSelectBtn>().type = type;

        for (int i = 1; i < cnt; i++)
        {
            SkinSelectBtn temp;

            if (i < skin_transforms.Length)
            {
                temp = skin_transforms[i].GetComponent<SkinSelectBtn>();
            }
            else
            {
                GameObject skin_temp = Instantiate(skin_prefab);
                skin_temp.transform.parent = parent;
                temp = skin_temp.AddComponent<SkinSelectBtn>();
            }

            temp.type = type;
            if (type.Equals("Head")) temp.SetUI = ((Define.HeadSkin)(i -1)).ToString();
            else if (type.Equals("Cloth")) temp.SetUI = ((Define.ClothSkin)(i - 1)).ToString();
            else if (type.Equals("Wing")) temp.SetUI = ((Define.WingSkin)(i - 1)).ToString();
        }

        if(cnt < skin_transforms.Length)
        {
            for(int i = cnt; i < skin_transforms.Length; i++)
            {
                Destroy(skin_transforms[i]);
            }
        }
    }
}