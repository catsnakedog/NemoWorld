using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapSize : MonoBehaviour
{
    Tilemap tile;
    void Start()
    {
        tile = gameObject.GetComponent<Tilemap>();
        tile.CompressBounds();
    }
}