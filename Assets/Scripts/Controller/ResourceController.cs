using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class ResourceController : MonoBehaviour
{

    public GameObject ch { get; set; }
    public List<GameObject> UItype { get; set; }
    public List<Material> EffectType { get; set; }
    public Dictionary<string, Sprite> sprite { get; set; }
    public Dictionary<string, Sprite> head_skin_sprite { get; set; }
    public Dictionary<string, Sprite> cloth_skin_sprite { get; set; }
    public Dictionary<string, Sprite> wing_skin_sprite { get; set; }

    public void init()
    {
        UItypeSetting();
        SpriteSetting();
        ChSetting();
    }

    void UItypeSetting()
    {
        UItype = new List<GameObject>();
        for (int i = 0; i < (int)Define.UItype.MaxCount; i++)
        {
            UItype.Add(Resources.Load<GameObject>("Prefabs/UI/" + Enum.GetName(typeof(Define.UItype), i)));
        }
    }

    void ChSetting()
    {
        ch = Resources.Load<GameObject>("Prefabs/Ch/Ch");
    }
    void SpriteSetting()
    {
        sprite = new Dictionary<string, Sprite>();
        head_skin_sprite = new Dictionary<string, Sprite>();
        cloth_skin_sprite = new Dictionary<string, Sprite>();
        wing_skin_sprite = new Dictionary<string, Sprite>();

        for (int i = 0; i < (int)Define.SpriteDict.MaxCount; i++)
        {
            sprite.Add(Enum.GetName(typeof(Define.SpriteDict), i), Resources.Load<Sprite>("Sprite/" + Enum.GetName(typeof(Define.SpriteDict), i)));
        }

        for(int i = 0; i < (int)Define.HeadSkin.MaxCount; i++)
        {
            head_skin_sprite.Add(Enum.GetName(typeof(Define.HeadSkin), i), Resources.Load<Sprite>("Sprite/Skin/Head/" + Enum.GetName(typeof(Define.HeadSkin), i)));
        }

        for (int i = 0; i < (int)Define.ClothSkin.MaxCount; i++)
        {
            cloth_skin_sprite.Add(Enum.GetName(typeof(Define.ClothSkin), i), Resources.Load<Sprite>("Sprite/Skin/Cloth/" + Enum.GetName(typeof(Define.ClothSkin), i)));
        }

        for (int i = 0; i < (int)Define.WingSkin.MaxCount; i++)
        {
            wing_skin_sprite.Add(Enum.GetName(typeof(Define.WingSkin), i), Resources.Load<Sprite>("Sprite/Skin/Wing/" + Enum.GetName(typeof(Define.WingSkin), i)));
        }
    }
}