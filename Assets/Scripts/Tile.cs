using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject TileVisual;
    public Position Position;
    public List<Tile> Adjacent;

    public void OnCreate(Position Position)
    {
        Adjacent = new List<Tile>();
        this.Position = Position;
        SetPosition();
    }    

    void SetPosition()
    {
        this.transform.position = new Vector3(Position.x * 2f, 0, (Position.y) * 1.5f * Globals.Map_Tile_Scale);
        if(Position.y % 2 != 0)
        {
            this.transform.position += new Vector3(1, 0, 0);
        }
        TileVisual.transform.localScale = new Vector3(TileVisual.transform.localScale.x * Globals.Map_Tile_Scale, Position.z, TileVisual.transform.localScale.y * Globals.Map_Tile_Scale);
        TileVisual.transform.position += new Vector3( 0, (Position.z - 1) / 2f, 0);
    }
}
