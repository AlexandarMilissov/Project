using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[ExecuteInEditMode]
public class Map : MonoBehaviour
{
    public GameObject TilePrefab;
    public int SizeX = 1;
    public int SizeY = 1;
    public int MinHeight = 1;
    public int MaxHeight = 1;

    Tile[,] TileMap;
    
    void Start()
    {
        if(TilePrefab == null)
        {
            return;
        }

        CreateMap(SizeX, SizeY, MinHeight, MaxHeight);
    }

    private void Awake()
    {
        CreateMap(SizeX, SizeY, MinHeight, MaxHeight);
    }

    void CreateMap(int sizeX, int sizeY, int minHeight, int maxHeight)
    {
        ClearChildren();
        TileMap = new Tile[SizeX, SizeY];

        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                Position position = new Position(i, j, Random.Range(minHeight, maxHeight));

                GameObject t = Instantiate(TilePrefab, this.transform.position, Quaternion.identity, this.transform);
                TileMap[i, j] = t.GetComponent<Tile>();
                TileMap[i, j].OnCreate(position);

                t.name = $"{position}";
            }
        }
    }

    void ClearChildren()
    {
        var tempList = transform.Cast<Transform>().ToList();
        foreach (var child in tempList)
        {
            if (Application.isPlaying)
            {
                Destroy(child.gameObject);
            }
            else if (Application.isEditor)
            {
                DestroyImmediate(child.gameObject, false);
            }
        }
    }
}
